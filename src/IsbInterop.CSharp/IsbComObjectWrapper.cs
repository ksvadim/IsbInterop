using Microsoft.VisualBasic;
using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace IsbInterop
{
  /// <summary>
  /// Базовый объект.
  /// </summary>
  public abstract class IsbComObjectWrapper : CriticalFinalizerObject, IIsbComObjectWrapper, IUnsafeRcwObjectAccessor
  {
    #region Поля и свойства

    /// <summary>
    /// COM-объект IS-Builder.
    /// </summary>
    protected object RcwObject
    {
      get
      {
        if (this.disposed)
          throw new ObjectDisposedException(this.typeName);

        return rcwObject;
      }
      private set { rcwObject = value; }
    }

    private object rcwObject;

    /// <summary>
    /// Имя типа.
    /// </summary>
    private readonly string typeName;

    /// <summary>
    /// COM-объект IS-Builder.
    /// </summary>
    object IUnsafeRcwObjectAccessor.UnsafeRcwObject
    {
      get { return this.RcwObject; }
    }

    /// <summary>
    /// Область видимости.
    /// </summary>
    internal IScope Scope { get; private set; }

    #endregion

    #region IDisposable

    private bool disposed;

    /// <summary>
    /// Финализатор.
    /// </summary>
    ~IsbComObjectWrapper()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;

      if (disposing)
      {
        if (this.rcwObject != null)
        {
          if (Marshal.IsComObject(this.rcwObject))
            Marshal.ReleaseComObject(this.rcwObject);
          this.rcwObject = null;
        }

        this.disposed = true;
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Вызвать экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Результат.</returns>
    protected object InvokeRcwInstanceMethod(string methodName, object parameter)
    {
      return ComUtils.InvokeRcwInstanceMethod(this.RcwObject, methodName, parameter);
    }

    /// <summary>
    /// Вызвать экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <returns>Результат.</returns>
    protected object InvokeRcwInstanceMethod(string methodName, object[] parameters = null)
    {
      return ComUtils.InvokeRcwInstanceMethod(this.RcwObject, methodName, parameters);
    }

    /// <summary>
    /// Вызвать экземплярный метод COM-объекта.
    /// </summary>
    /// <param name="methodName">Имя метода.</param>
    /// <param name="parameters">Параметры.</param>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    protected object InvokeRcwInstanceMethod(string methodName, object[] parameters, TimeSpan? timeout)
    {
      return ComUtils.InvokeRcwInstanceMethod(this.RcwObject, methodName, parameters, timeout);
    }

    /// <summary>
    /// Получить свойство COM-объекта.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Результат.</returns>
    protected object GetRcwProperty(string propertyName, object parameter)
    {
      return ComUtils.GetRcwProperty(this.RcwObject, propertyName, parameter);
    }

    /// <summary>
    /// Получить свойство COM-объекта.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="parameters">Параметры.</param>
    /// <returns>Результат.</returns>
    protected object GetRcwProperty(string propertyName, object[] parameters = null)
    {
      return ComUtils.GetRcwProperty(this.RcwObject, propertyName, parameters);
    }

    /// <summary>
    /// Установить свойство COM-объекта.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <param name="value">Значение.</param>
    protected void SetRcwProperty(string propertyName, object value)
    {
      ComUtils.SetRcwProperty(this.RcwObject, propertyName, value);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    protected IsbComObjectWrapper() { }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwObject">COM-объект IS-Builder.</param>
    /// <param name="scope">Область видимости.</param>
    protected IsbComObjectWrapper(object rcwObject, IScope scope)
    {
      this.RcwObject = rcwObject;
      this.typeName = Information.TypeName(rcwObject);
      this.Scope = scope;

      ((Scope)scope)?.Add(this);
    }

    #endregion
  }
}
