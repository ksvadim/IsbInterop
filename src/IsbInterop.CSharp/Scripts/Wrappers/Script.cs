using IsbInterop.Base;
using IsbInterop.Base.Wrappers;
using System;
using IsbInterop.Accessory;

namespace IsbInterop.Scripts.Wrappers
{
  /// <summary>
  /// Обертка над IScript.
  /// </summary>
  internal class Script : IsbObject<IObjectInfo>, IScript
  {
    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <returns>Результат.</returns>
    public IIsbComObjectWrapper Execute()
    {
      var rcwObject = this.InvokeRcwInstanceMethod("Execute", null, null);
      return new BaseIsbObjectWrapper(rcwObject, Scope);
    }

    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    public IIsbComObjectWrapper Execute(TimeSpan timeout)
    {
      var rcwObject = this.InvokeRcwInstanceMethod("Execute", null, timeout);
      return new BaseIsbObjectWrapper(rcwObject, Scope);
    }

    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    public T Execute<T>() where T : IIsbComObjectWrapper
    {
      var rcwObject = this.InvokeRcwInstanceMethod("Execute", null, null);
      return IsbObjectResolver.Resolve<T>(rcwObject, Scope);
    }

    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    public T Execute<T>(TimeSpan timeout) where T : IIsbComObjectWrapper
    {
      var rcwObject = this.InvokeRcwInstanceMethod("Execute", null, timeout);
      return IsbObjectResolver.Resolve<T>(rcwObject, Scope);
    }

    /// <summary>
    /// Получить IObjectInfo.
    /// </summary>
    /// <returns>IObjectInfo.</returns>
    public override IObjectInfo GetInfo()
    {
      throw new NotSupportedException("This method is not supported by IS-Builder API.");
    }

    /// <summary>
    /// Получить параметры.
    /// </summary>
    /// <returns>IsbObjectList.</returns>
    public IList<IIsbComObjectWrapper> GetParams()
    {
      return GetParams<IIsbComObjectWrapper>();
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="script">Скрипт DIRECTUM.</param>
    /// <param name="scope">Область видимости.</param>
    public Script(object script, IScope scope) : base(script, scope) { }
  }
}
