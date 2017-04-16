using IsbInterop.Accessory;
using IsbInterop.Base;
using IsbInterop.Base.Proxies;
using System;

namespace IsbInterop.Scripts.Proxies
{
  /// <summary>
  /// Обертка над IScript.
  /// </summary>
  internal class Script : IsbObject<IObjectInfo>, IScript
  {
    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <returns>Результат.</returns>
    public IBaseIsbObject Execute()
    {
      var rcwObject = InvokeRcwInstanceMethod("Execute", null, TimeSpan.MaxValue);
      return new BaseIsbObjectImp(rcwObject, Scope);
    }

    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    public IBaseIsbObject Execute(TimeSpan timeout)
    {
      var rcwObject = InvokeRcwInstanceMethod("Execute", null, timeout);
      return new BaseIsbObjectImp(rcwObject, Scope);
    }

    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    public T Execute<T>() where T : IBaseIsbObject
    {
      var rcwObject = InvokeRcwInstanceMethod("Execute", null, TimeSpan.MaxValue);
      return IsbObjectResolver.Resolve<T>(rcwObject, Scope);
    }

    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    public T Execute<T>(TimeSpan timeout) where T : IBaseIsbObject
    {
      var rcwObject = InvokeRcwInstanceMethod("Execute", null, timeout);
      return IsbObjectResolver.Resolve<T>(rcwObject, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override IObjectInfo GetInfo()
    {
      throw new NotSupportedException("This method is not supported by IS-Builder API.");
    }

    /// <summary>
    /// Получает параметры.
    /// </summary>
    /// <returns>IsbObjectList.</returns>
    public IList<IBaseIsbObject> GetParams()
    {
      return GetParams<IBaseIsbObject>();
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="script">Скрипт DIRECTUM.</param>
    /// <param name="scope">Область видимости.</param>
    public Script(object script, IScope scope) : base(script, scope) { }
  }
}
