using IsbInterop.Accessory;
using IsbInterop.Properties;
using IsbInterop.System.Proxies;
using IsbInterop.Utils;
using System;
using System.Reflection;
using IsbInterop.System;

// ReSharper disable once CheckNamespace
// LoginPoint - публичный класс, он должен быть виден из namespace IsbInterop.
namespace IsbInterop
{
  /// <summary>
  /// Обертка над ILoginPoint.
  /// </summary>
  public class LoginPoint : BaseIsbObject, ILoginPoint
  {
    #region Поля и свойства

    /// <summary>
    /// ИД процесса.
    /// </summary>
    public int PID => (int)GetRcwProperty("PID");

    #endregion

    /// <summary>
    /// Получает объект ILoginPoint.
    /// </summary>
    /// <returns>ILoginPoint.</returns>
    /// <exception cref="FatalIsbInteropException">Исключение при неудачной попытке получить LoginPoint.</exception>
    public static ILoginPoint GetLoginPoint()
    {
      var comType = Type.GetTypeFromProgID("SBLogon.LoginPoint");
      if (comType == null)
        throw new IsbInteropException(string.Format(Resources.UnableToGetObject, "SBLogon.LoginPoint"));

      try
      {
        var rcwLoginPoint = Activator.CreateInstance(comType);
        var loginPoint = new LoginPoint(rcwLoginPoint);

        return loginPoint;
      }
      catch (Exception ex)
      {
        throw new FatalIsbInteropException(Resources.UnableToGetLoginPoint, ex);
      }
    }

    /// <summary>
    /// Получает объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш: True, если нужно добавить информацию, иначе False.</param>
    /// <returns>Объект приложения IApplication, или null.</returns>
    public IApplication GetApplication(string connectionParams, bool storeInCache = true)
    {
      var rcwApplication = GetRcwApplication(connectionParams, storeInCache);

      return rcwApplication == null
        ? null
        : new Application(rcwApplication, null);
    }

    /// <summary>
    /// Получает объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="errorCode">Код ошибки.</param>
    /// <returns>Объект приложения IApplication, либо null, если его не удалось получить.</returns>
    public IApplication GetApplicationEx(string connectionParams, out int errorCode)
    {
      var rcwApplication = GetRcwApplicationEx(connectionParams, out errorCode);

      return rcwApplication == null ? null :
        new Application(rcwApplication, null);
    }

    /// <summary>
    /// Получает RCW-объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш: True, если нужно добавить информацию, иначе False.</param>
    /// <returns>RCW-объект IApplication.</returns>
    internal object GetRcwApplication(string connectionParams, bool storeInCache = true)
    {
      var parameters = new object[] { connectionParams, storeInCache };

      var timeout = TimeSpan.FromSeconds(IsbInteropConfiguration.IsbAppCreationTimeout);
      var rcwApplication = ComUtils.InvokeRcwInstanceMethod(RcwObject, "GetApplication", parameters, timeout);

      return rcwApplication;
    }

    /// <summary>
    /// Получить RCW-объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="errorCode">Код ошибки.</param>
    /// <returns>Объект приложения IApplication, либо null, если его не удалось получить.</returns>
    internal object GetRcwApplicationEx(string connectionParams, out int errorCode)
    {
      const int defaultErrorCode = -1;

      var parameters = new object[] { connectionParams, defaultErrorCode };

      var p = new ParameterModifier(2);
      p[1] = true;
      ParameterModifier[] mods = { p };

      var timeout = TimeSpan.FromSeconds(IsbInteropConfiguration.IsbAppCreationTimeout);
      var rcwApplication = ComUtils.InvokeRcwInstanceMethod(RcwObject, "GetApplication", parameters, mods, timeout);

      errorCode = (int)parameters[1];
      return rcwApplication;
    }

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwLoginPoint">COM-объект LoginPoint.</param>
    private LoginPoint(object rcwLoginPoint) : base(rcwLoginPoint, null) { }

    #endregion
  }
}
