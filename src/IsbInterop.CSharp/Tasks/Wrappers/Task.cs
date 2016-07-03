using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ITask.
  /// </summary>
  internal class Task : CustomWork<ITaskInfo>, ITask
  {
    /// <summary>
    /// Получить ITaskInfo.
    /// </summary>
    /// <returns>ITaskInfo.</returns>
    public override ITaskInfo GetInfo()
    {
      var rcwITasInfo = this.GetRcwObjectInfo();
      return new TaskInfo(rcwITasInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITask">СOM-объект ITask.</param>
    public Task(object rcwITask) : base(rcwITask) { }
  }
}
