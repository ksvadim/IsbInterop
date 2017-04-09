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
      return new Task(rcwITask, this.Scope);
    }

    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override ITask GetObjectById(int id)
    {
      var rcwObject = this.GetRcwObjectById(id);
      return new Task(rcwObject, this.Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override ITaskInfo GetObjectInfo(int id)
    {
      var rcwITaskInfo = GetRcwObjectInfo(id);
      return new TaskInfo(rcwITaskInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    /// <param name="scope">Область видимости.</param>
    public TaskFactory(object rcwITaskFactory, IScope scope) : base(rcwITaskFactory, scope) { }
  }
}
