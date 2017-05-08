using IsbInterop.Base.Proxies;

namespace IsbInterop.Tasks.Proxies
{
  /// <summary>
  /// Обертка над ITaskFactory.
  /// </summary>
  internal class TaskFactory : EdmsObjectFactory<ITask, ITaskInfo>, ITaskFactory
  {
    /// <summary>
    /// Создает новую задачу.
    /// </summary>
    /// <returns>Новая задача.</returns>
    public ITask CreateNew()
    {
      var rcwITask = InvokeRcwInstanceMethod("CreateNew");
      return new Task(rcwITask, Scope);
    }

    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override ITask GetObjectById(int id)
    {
      var rcwObject = GetRcwObjectById(id);
      return new Task(rcwObject, Scope);
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
    public TaskFactory(object rcwITaskFactory, IScope scope)
      : base(rcwITaskFactory, scope) { }
  }
}
