using IsbInterop.Properties;
using Microsoft.VisualBasic;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IsbInterop.Utils
{
  /// <summary>
  /// Утилиты для работы с COM-объектами.
  /// </summary>
  internal static class ComUtils
  {
    /// <summary>
    /// Таймаут выполнения COM-метода по умолчанию, секунд.
    /// </summary>
    private const int DefaultComMethodExecutionTimeout = 60;

    /// <summary>
    /// Таймаут выполнения COM-метода, секунд.
    /// </summary>
    private static readonly Lazy<int> ComMethodExecutionTimeout = new Lazy<int>(GetComMethodExecutionTimeoutValue, true);

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Результат.</returns>
    public static object InvokeRcwInstanceMethod(object rcwObject, string methodName, object parameter)
    {
      return InvokeRcwInstanceMethod(rcwObject, methodName, new [] { parameter });
    }

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    public static object InvokeRcwInstanceMethod(object rcwObject, string methodName, object[] parameters, TimeSpan? timeout)
    {
      Func<object> func = () =>
      {
        object result;
        try
        {
          result = rcwObject.GetType()
            .InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null,
              rcwObject, parameters);
        }
        catch (TargetInvocationException ex)
        {
          var errorMessage = string.Format(Resources.CannotExecuteObjectMethodTemplate,
            methodName, Information.TypeName(rcwObject));

          if (ex.InnerException is COMException)
            throw new IsbInteropException(errorMessage, ex.InnerException);

          throw new IsbInteropException(errorMessage, ex);
        }

        return result;
      };

      var methodResult = timeout != null ? ThreadUtils.Invoke(func, timeout.Value) : func.Invoke();

      return methodResult;
    }

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <returns>Результат.</returns>
    public static object InvokeRcwInstanceMethod(object rcwObject, string methodName, object[] parameters = null)
    {
      object result = ThreadUtils.Invoke(() =>
      {
        try
        {
          result = rcwObject.GetType()
            .InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null,
              rcwObject, parameters);
        }
        catch (TargetInvocationException ex)
        {
          var errorMessage = string.Format(Resources.CannotExecuteObjectMethodTemplate,
            methodName, Information.TypeName(rcwObject));

          if (ex.InnerException is COMException)
            throw new IsbInteropException(errorMessage, ex.InnerException);

          throw new IsbInteropException(errorMessage, ex);
        }

        return result;
      }, TimeSpan.FromSeconds(ComMethodExecutionTimeout.Value));

      return result;
    }

    /// <summary>
    /// Получает свойство COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Результат.</returns>
    public static object GetRcwProperty(object rcwObject, string propertyName, object parameter)
    {
      return GetRcwProperty(rcwObject, propertyName, new [] { parameter });
    }

    /// <summary>
    /// Получает свойство COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="parameters">Параметры.</param>
    /// <returns>Результат.</returns>
    public static object GetRcwProperty(object rcwObject, string propertyName, object[] parameters = null)
    {
      object result;

      try
      {
        result = rcwObject.GetType()
          .InvokeMember(propertyName, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, null,
          rcwObject, parameters);
      }
      catch (TargetInvocationException ex)
      {
        var errorMessage = string.Format(Resources.CannotGetObjectProperyTemplate,
          propertyName, Information.TypeName(rcwObject));

        if (ex.InnerException is COMException)
          throw new IsbInteropException(errorMessage, ex.InnerException);

        throw new IsbInteropException(errorMessage, ex);
      }

      return result;
    }

    /// <summary>
    /// Установливает свойство COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="value">Значение.</param>
    public static void SetRcwProperty(object rcwObject, string propertyName, object value)
    {
      try
      {
        var result = rcwObject.GetType()
          .InvokeMember(propertyName, BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public, null,
          rcwObject, new[] { value });
      }
      catch (TargetInvocationException ex)
      {
        var errorMessage = string.Format(Resources.CannotSetObjectProperyTemplate,
          propertyName, Information.TypeName(rcwObject));

        if (ex.InnerException is COMException)
          throw new IsbInteropException(errorMessage, ex.InnerException);

        throw new IsbInteropException(errorMessage, ex);
      }
    }

    /// <summary>
    /// Получает значение таймаута выполнения COM-метода.
    /// </summary>
    /// <returns>Таймаут в секундах.</returns>
    private static int GetComMethodExecutionTimeoutValue()
    {
      int timeout = DefaultComMethodExecutionTimeout;

      if (ConfigurationUtils.TryGetAppSetting("IsbInteropTimeout", ref timeout))
      {
        if (timeout <= 0)
          timeout = DefaultComMethodExecutionTimeout;
      }

      return timeout;
    }
  }
}
