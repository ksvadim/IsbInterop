using IsbInterop.Accessory;
using IsbInterop.Properties;
using System;

namespace IsbInterop
{
  /// <summary>
  /// Менеджер приложения IS-Builder.
  /// </summary>
  /// <remarks>Кэширует экземпляр IApplication.</remarks>
  internal class IsbApplicationManager
  {
    #region Singleton

    private static readonly Lazy<IsbApplicationManager> instance =
      new Lazy<IsbApplicationManager>(() => new IsbApplicationManager(), true);

    /// <summary>
    /// Экземпляр одиночки.
    /// </summary>
    public static IsbApplicationManager Instance { get { return instance.Value; } }

    /// <summary>
    /// Приватный конструктор.
    /// </summary>
    private IsbApplicationManager() { }

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Объект блокировки.
    /// </summary>
    private static readonly object lockRoot = new object();

    /// <summary>
    /// Объект блокировки для получения LoginPoint.
    /// </summary>
    private static readonly object loginPointLocker = new object();

    /// <summary>
    /// Точка подключения.
    /// </summary>
    private ILoginPoint currentLoginPoint;

    /// <summary>
    /// Признак необходимости обновления текущей точки подключения.
    /// </summary>
    private static volatile bool needUpdateCurrentLoginPoint = false;

    #endregion

    #region Методы

    /// <summary>
    /// Получить RCW-объект приложения IS-Builder.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    /// <returns>RCW-объект приложения.</returns>
    /// <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
    internal object GetRcwApplication(string connectionParams, bool storeInCache)
    {
      if (connectionParams == null)
        throw new ArgumentNullException(nameof(connectionParams));

      if (this.currentLoginPoint != null)
      {
        try
        {
          int id = this.currentLoginPoint.PID;
        }
        catch (Exception)
        {
          bool lockedHere = false;

          lock (lockRoot)
          {
            if (!needUpdateCurrentLoginPoint)
            {
              needUpdateCurrentLoginPoint = true;
              lockedHere = true;
            }
          }

          if (lockedHere)
          {
            lock (loginPointLocker)
            {
              this.currentLoginPoint = LoginPoint.GetLoginPoint();
              needUpdateCurrentLoginPoint = false;
              return InternalGetNewIsbApplication(connectionParams, storeInCache, (LoginPoint)this.currentLoginPoint);
            }
          }
          else
          {
            lock (loginPointLocker)
            {
              return InternalGetNewIsbApplication(connectionParams, storeInCache, this.currentLoginPoint);
            }
          }
        }

        return InternalGetNewIsbApplication(connectionParams, storeInCache, this.currentLoginPoint);
      }
      else
      {
        lock (lockRoot)
        {
          if (this.currentLoginPoint == null)
            this.currentLoginPoint = LoginPoint.GetLoginPoint();

          return InternalGetNewIsbApplication(connectionParams, storeInCache, this.currentLoginPoint);
        }
      }
    }

    /// <summary>
    /// Получить новый объект приложения IS-Builder.
    /// </summary>
    /// <param name="currentLoginPoint">Текущая точка подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <returns>RCW-объект IAppliction.</returns>
    private static object InternalGetNewIsbApplication(string connectionParams, bool storeInCache, ILoginPoint currentLoginPoint)
    {
      int errorCode = 0;
      object rcwApplication;

      try
      {
        rcwApplication = storeInCache
          ? ((LoginPoint)currentLoginPoint).GetRcwApplication(connectionParams)
          : ((LoginPoint)currentLoginPoint).GetRcwApplicationEx(connectionParams, out errorCode);
      }
      catch (Exception ex)
      {
        throw new FatalIsbInteropException(Resources.CannotGetIsbApplication, ex);
      }

      if (rcwApplication == null)
      {
        if (storeInCache)
        {
          throw new FatalIsbInteropException(Resources.CannotGetIsbApplication);
        }
        else
        {
          throw new FatalIsbInteropException(string.Format(Resources.CannotGetIsbApplicationTemplate,
            string.Format(Resources.InternalErrorCodeStringTemplate, errorCode)));
        }
      }

      return rcwApplication;
    }

    #endregion
  }
}
