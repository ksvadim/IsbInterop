using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ITask.
  /// </summary>
  internal class Task : CustomWork<ITaskInfo>, ITask
  {
    /// <summary>
    /// Информация об объекте.
    /// </summary>
    public override ITaskInfo Info
    {
      get
      {
        var rcwITasInfo = GetRcwObjectInfo();
        return new TaskInfo(rcwITasInfo, Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITask">СOM-объект ITask.</param>
    /// <param name="scope">Область видимости.</param>
    public Task(object rcwITask, IScope scope) : base(rcwITask, scope) { }
  }
}
