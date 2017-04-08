using IsbInterop.Base;
using IsbInterop.Base.Wrappers;

namespace IsbInterop.ComponentTokens.Wrappers
{
  /// <summary>
  /// Обертка над IComponentTokenFactory.
  /// </summary>
  internal class ComponentTokenFactory : EdmsObjectFactory<IComponentToken, IComponentTokenInfo>, IComponentTokenFactory
  {
    /// <summary>
    /// Запустить компоненту.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    public void Execute(IObjectInfo objectInfo)
    {
      this.InvokeRcwInstanceMethod("Execute", ((IUnsafeRcwObjectAccessor)objectInfo).UnsafeRcwObject);
    }

    /// <summary>
    /// Запустить компоненту в новом процессе.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    public void ExecuteInNewProcess(IObjectInfo objectInfo)
    {
      this.InvokeRcwInstanceMethod("ExecuteInNewProcess", ((IUnsafeRcwObjectAccessor)objectInfo).UnsafeRcwObject);
    }

    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IComponentToken GetObjectById(int id)
    {
      var rcwComponentToken = this.GetRcwObjectById(id);
      return new ComponentToken(rcwComponentToken, this.Scope);
    }

    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IComponentTokenInfo GetObjectInfo(int id)
    {
      var rcwIComponentTokenInfo = this.GetRcwObjectInfo(id);
      return new ComponentTokenInfo(rcwIComponentTokenInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIComponentTokenFactory">COM-объект IComponentTokenFactory.</param>
    /// <param name="scope">Область видимости.</param>
    public ComponentTokenFactory(object rcwIComponentTokenFactory, IScope scope) : base(rcwIComponentTokenFactory, scope) { }
  }
}
