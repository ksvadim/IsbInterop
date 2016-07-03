using IsbInterop.Base;

namespace IsbInterop.ComponentTokens
{
  /// <summary>
  /// Фабрика задач.
  /// </summary>
  public interface IComponentTokenFactory : IEdmsObjectFactory<IComponentToken, IComponentTokenInfo>
  {
    /// <summary>
    /// Запустить компоненту.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    /// <remarks>
    /// Метод запускает компоненту с помощью варианта запуска, информация о котором была передана в параметре ObjectInfo.
    /// </remarks>
    void Execute(IObjectInfo objectInfo);

    /// <summary>
    /// Запустить компоненту в новом процессе.
    /// </summary>
    /// <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    /// <remarks>
    /// Метод запускает компоненту в новом процессе Windows с помощью варианта запуска, 
    /// информация о котором была передана в параметре ObjectInfo. 
    /// Компонента запускается без ожидания завершения запущенного процесса.
    /// </remarks>
    void ExecuteInNewProcess(IObjectInfo objectInfo);
  }
}
