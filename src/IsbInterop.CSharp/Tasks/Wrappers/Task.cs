using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ITask.
  /// </summary>
  internal class Task : CustomWork<ITaskInfo>, ITask
  {
    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override ITaskInfo GetInfo()
    {
      var rcwITasInfo = this.GetRcwObjectInfo();
      return new TaskInfo(rcwITasInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITask">СOM-объект ITask.</param>
    /// <param name="scope">Область видимости.</param>
    public Task(object rcwITask, IScope scope) : base(rcwITask, scope) { }
  }
}
