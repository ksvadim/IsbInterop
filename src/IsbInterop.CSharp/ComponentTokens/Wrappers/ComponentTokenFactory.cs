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
    /// Запускает компоненту.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    public void Execute(IObjectInfo objectInfo)
    {
      InvokeRcwInstanceMethod("Execute", ((IUnsafeRcwHolder)objectInfo).RcwObject);
    }

    /// <summary>
    /// Запускает компоненту в новом процессе.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    public void ExecuteInNewProcess(IObjectInfo objectInfo)
    {
      InvokeRcwInstanceMethod("ExecuteInNewProcess", ((IUnsafeRcwHolder)objectInfo).RcwObject);
    }

    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IComponentToken GetObjectById(int id)
    {
      var rcwComponentToken = GetRcwObjectById(id);
      return new ComponentToken(rcwComponentToken, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IComponentTokenInfo GetObjectInfo(int id)
    {
      var rcwIComponentTokenInfo = GetRcwObjectInfo(id);
      return new ComponentTokenInfo(rcwIComponentTokenInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIComponentTokenFactory">COM-объект IComponentTokenFactory.</param>
    /// <param name="scope">Область видимости.</param>
    public ComponentTokenFactory(object rcwIComponentTokenFactory, IScope scope)
      : base(rcwIComponentTokenFactory, scope) { }
  }
}
