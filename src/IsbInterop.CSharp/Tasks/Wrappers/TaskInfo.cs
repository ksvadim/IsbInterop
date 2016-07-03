namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ITaskInfo.
  /// </summary>
  internal class TaskInfo : CustomWorkInfo, ITaskInfo
  {
     /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITaskInfo">COM-объект ITaskInfo.</param>
    public TaskInfo(object rcwITaskInfo) : base(rcwITaskInfo) { }
  }
}
