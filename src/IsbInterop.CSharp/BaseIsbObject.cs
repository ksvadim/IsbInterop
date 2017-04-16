using IsbInterop.Utils;
using Microsoft.VisualBasic;
using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace IsbInterop
{
  /// <summary>
  /// Базовый объект IS-Builder.
  /// </summary>
  public abstract class BaseIsbObject : CriticalFinalizerObject, IBaseIsbObject, IRcwProxy
  {
    #region Поля и свойства

    /// <summary>
    /// COM-объект IS-Builder.
    /// </summary>
    protected object RcwObject
    {
      get
      {
        if (_disposed)
          throw new ObjectDisposedException(_typeName);

        return _rcwObject;
      }
      private set { _rcwObject = value; }
    }

    private object _rcwObject;

    /// <summary>
    /// Имя типа.
    /// </summary>
    private readonly string _typeName;

    /// <summary>
    /// COM-объект IS-Builder.
    /// </summary>
    object IRcwProxy.RcwObject => RcwObject;

    /// <summary>
    /// Область видимости.
    /// </summary>
    internal IScope Scope { get; private set; }

    #endregion

    #region IDisposable

    private bool _disposed;

    /// <summary>
    /// Финализатор.
    /// </summary>
    ~BaseIsbObject()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (_disposed)
        return;

      if (disposing)
      {
        if (_rcwObject != null)
        {
          if (Marshal.IsComObject(_rcwObject))
            Marshal.ReleaseComObject(_rcwObject);
          _rcwObject = null;
        }

        _disposed = true;
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Результат.</returns>
    protected object InvokeRcwInstanceMethod(string methodName, object parameter)
    {
      return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameter);
    }

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <returns>Результат.</returns>
    protected object InvokeRcwInstanceMethod(string methodName, object[] parameters = null)
    {
      return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameters);
    }

    /// <summary>
    /// Вызывает экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    protected object InvokeRcwInstanceMethod(string methodName, object[] parameters, TimeSpan timeout)
    {
      return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameters, timeout);
    }

    /// <summary>
    /// Получает свойство COM-объекта.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Результат.</returns>
    protected object GetRcwProperty(string propertyName, object parameter)
    {
      return ComUtils.GetRcwProperty(RcwObject, propertyName, parameter);
    }

    /// <summary>
    /// Получает свойство COM-объекта.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="parameters">Параметры.</param>
    /// <returns>Результат.</returns>
    protected object GetRcwProperty(string propertyName, object[] parameters = null)
    {
      return ComUtils.GetRcwProperty(RcwObject, propertyName, parameters);
    }

    /// <summary>
    /// Устанавливает свойство COM-объекта.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="value">Значение.</param>
    protected void SetRcwProperty(string propertyName, object value)
    {
      ComUtils.SetRcwProperty(RcwObject, propertyName, value);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    protected BaseIsbObject() { }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwObject">COM-объект IS-Builder.</param>
    /// <param name="scope">Область видимости.</param>
    protected BaseIsbObject(object rcwObject, IScope scope)
    {
      RcwObject = rcwObject;
      Scope = scope;
      _typeName = Information.TypeName(rcwObject);

      ((Scope)scope)?.Add(this);
    }

    #endregion
  }
}
