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
    /// <returns>Результат.</returns>
    public static object InvokeRcwInstanceMethod(object rcwObject, string methodName, object[] parameters = null)
    {
      var timeout = TimeSpan.FromSeconds(IsbInteropConfiguration.IsbMethodExecutionTimeout);
      return InvokeRcwInstanceMethod(rcwObject, methodName, parameters, timeout);
    }

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    public static object InvokeRcwInstanceMethod(object rcwObject, string methodName, object[] parameters, TimeSpan timeout)
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
      }, timeout);

      return result;
    }

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <param name="modifiers">Атрибуты параметров.</param>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    internal static object InvokeRcwInstanceMethod(object rcwObject, string methodName,
      object[] parameters, ParameterModifier[] modifiers, TimeSpan timeout)
    {
      object result = ThreadUtils.Invoke(() =>
      {
        try
        {
          result = rcwObject.GetType()
            .InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null,
              rcwObject, parameters, modifiers, null, null);
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
      }, timeout);

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
  }
}
