using IsbInterop.Base;

namespace IsbInterop.ComponentTokens
{
  /// <summary>
  /// Фабрика задач.
  /// </summary>
  public interface IComponentTokenFactory : IEdmsObjectFactory<IComponentToken, IComponentTokenInfo>
  {
    /// <summary>
    /// Запускает компоненту.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    void Execute(IObjectInfo objectInfo);

    /// <summary>
    /// Запускает компоненту в новом процессе.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    void ExecuteInNewProcess(IObjectInfo objectInfo);
  }
}
