using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;
using IsbInterop.Properties;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
// LoginPoint - публичный класс, он должен быть виден из namespace IsbInterop.
namespace IsbInterop
{
  /// <summary>
  /// Обертка над ILoginPoint.
  /// </summary>
  public class LoginPoint : IsbComObjectWrapper, ILoginPoint
  {
    /// <summary>
    /// Код ошибки по умолчанию.
    /// </summary>
    private const int DefaultErrorCode = -1;

    /// <summary>
    /// Таймаут на создание объекта приложения.
    /// </summary>
    private readonly TimeSpan applicationCreationTimeout = TimeSpan.FromSeconds(20);

    /// <summary>
    /// ИД процесса.
    /// </summary>
    public int PID
    {
      get { return (int)this.GetRcwProperty("PID"); }
    }

    /// <summary>
    /// Получить объект ILoginPoint.
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
    /// Получить объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш: True, если нужно добавить информацию, иначе False.</param>
    /// <returns>Объект приложения IApplication, или null.</returns>
    public IApplication GetApplication(string connectionParams, bool storeInCache = true)
    {
      var rcwApplication = GetRcwApplication(connectionParams, storeInCache);

      return rcwApplication == null ? null :
        new Application(rcwApplication, null);
    }

    /// <summary>
    /// Получить объект приложения.
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
    /// Получить RCW-объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш: True, если нужно добавить информацию, иначе False.</param>
    /// <returns>RCW-объект IApplication.</returns>
    internal object GetRcwApplication(string connectionParams, bool storeInCache = true)
    {
      var parameters = new object[] { connectionParams, storeInCache };

      object rcwApplication = ThreadUtils.Invoke(() =>
      {
        try
        {
          rcwApplication = this.RcwObject.GetType()
            .InvokeMember("GetApplication", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null,
              this.RcwObject, parameters);
        }
        catch (TargetInvocationException ex)
        {
          var errorMessage = string.Format(Resources.CannotExecuteObjectMethodTemplate,
            "GetApplication", typeof(ILoginPoint).Name);

          if (ex.InnerException is COMException)
            throw new IsbInteropException(errorMessage, ex.InnerException);

          throw new IsbInteropException(errorMessage, ex);
        }

        return rcwApplication;
      }, applicationCreationTimeout);

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
      var parameters = new object[] { connectionParams, DefaultErrorCode };

      object rcwApplication = ThreadUtils.Invoke(() =>
      {
        var p = new ParameterModifier(2);
        p[1] = true;
        ParameterModifier[] mods = { p };

        try
        {
          rcwApplication = this.RcwObject.GetType()
            .InvokeMember("GetApplicationEx",
              BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
              null, this.RcwObject, parameters, mods, null, null);
        }
        catch (TargetInvocationException ex)
        {
          if (ex.InnerException is COMException)
            throw new IsbInteropException(
              string.Format(Resources.CannotExecuteObjectMethodTemplate, "GetApplicationEx", typeof(ILoginPoint).Name),
              ex);

          throw ex.InnerException;
        }
        return rcwApplication;
      }, applicationCreationTimeout);

      errorCode = (int)parameters[1];

      return rcwApplication;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwLoginPoint">COM-объект LoginPoint.</param>
    private LoginPoint(object rcwLoginPoint) : base(rcwLoginPoint, null) { }
  }
}
