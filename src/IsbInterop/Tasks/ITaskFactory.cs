using IsbInterop.Base;
using IsbInterop.Edms;

namespace IsbInterop.Tasks
{
  /// <summary>
  /// Фабрика задач.
  /// </summary>
  public interface ITaskFactory : IEdmsObjectFactory<ITask, ITaskInfo>
  {
    /// <summary>
    /// Создать новую задачу.
    /// </summary>
    /// <returns>Новая задача.</returns>
    ITask CreateNew();
  }
}
