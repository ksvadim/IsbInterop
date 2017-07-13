namespace IsbInterop.Tasks.Proxies
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
    /// <param name="scope">Область видимости.</param>
    public TaskInfo(object rcwITaskInfo, IScope scope) : base(rcwITaskInfo, scope) { }
  }
}
