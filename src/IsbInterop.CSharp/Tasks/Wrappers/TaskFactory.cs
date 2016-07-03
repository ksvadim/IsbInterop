using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ITaskFactory.
  /// </summary>
  internal class TaskFactory : EdmsObjectFactory<ITask, ITaskInfo>, ITaskFactory
  {
    /// <summary>
    /// Создать новую задачу.
    /// </summary>
    /// <returns>Новая задача.</returns>
    public ITask CreateNew()
    {
      var rcwITask = this.InvokeRcwInstanceMethod("CreateNew");
      return new Task(rcwITask);
    }

    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override ITask GetObjectById(int id)
    {
      var rcwObject = this.GetRcwObjectById(id);
      return new Task(rcwObject);
    }

    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override ITaskInfo GetObjectInfo(int id)
    {
      var rcwITaskInfo = this.GetRcwObjectInfo(id);
      return new TaskInfo(rcwITaskInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    public TaskFactory(object rcwITaskFactory) : base(rcwITaskFactory) { }
  }
}
