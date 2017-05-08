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

    /// <summary>
    /// Экземпляр одиночки.
    /// </summary>
    public static IsbApplicationManager Instance => _instance.Value;

    private static readonly Lazy<IsbApplicationManager> _instance =
      new Lazy<IsbApplicationManager>(() => new IsbApplicationManager(), true);

    /// <summary>
    /// Приватный конструктор.
    /// </summary>
    private IsbApplicationManager() { }

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Объект блокировки.
    /// </summary>
    private static readonly object LockRoot = new object();

    /// <summary>
    /// Объект блокировки для получения LoginPoint.
    /// </summary>
    private static readonly object LoginPointLocker = new object();

    /// <summary>
    /// Точка подключения.
    /// </summary>
    private ILoginPoint _currentLoginPoint;

    /// <summary>
    /// Признак необходимости обновления текущей точки подключения.
    /// </summary>
    private static volatile bool _needUpdateCurrentLoginPoint = false;

    #endregion

    #region Методы

    /// <summary>
    /// Получает RCW-объект приложения IS-Builder.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    /// <returns>RCW-объект приложения.</returns>
    /// <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
    internal object GetRcwApplication(string connectionParams, bool storeInCache)
    {
      if (connectionParams == null)
        throw new ArgumentNullException(nameof(connectionParams));

      if (_currentLoginPoint != null)
      {
        try
        {
          int id = _currentLoginPoint.PID;
        }
        catch (Exception)
        {
          bool lockedHere = false;

          lock (LockRoot)
          {
            if (!_needUpdateCurrentLoginPoint)
            {
              _needUpdateCurrentLoginPoint = true;
              lockedHere = true;
            }
          }

          if (lockedHere)
          {
            lock (LoginPointLocker)
            {
              _currentLoginPoint = LoginPoint.GetLoginPoint();
              _needUpdateCurrentLoginPoint = false;
              return InternalGetNewIsbApplication(connectionParams, storeInCache, (LoginPoint)_currentLoginPoint);
            }
          }
          else
          {
            lock (LoginPointLocker)
            {
              return InternalGetNewIsbApplication(connectionParams, storeInCache, _currentLoginPoint);
            }
          }
        }

        return InternalGetNewIsbApplication(connectionParams, storeInCache, _currentLoginPoint);
      }
      else
      {
        lock (LockRoot)
        {
          if (_currentLoginPoint == null)
            _currentLoginPoint = LoginPoint.GetLoginPoint();

          return InternalGetNewIsbApplication(connectionParams, storeInCache, _currentLoginPoint);
        }
      }
    }

    /// <summary>
    /// Получает новый объект приложения IS-Builder.
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
