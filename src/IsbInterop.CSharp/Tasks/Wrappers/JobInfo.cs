namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IJobInfo.
  /// </summary>
  internal class JobInfo : CustomJobInfo, IJobInfo
  {
     /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIJobInfo">COM-объект IJobInfo.</param>
    public JobInfo(object rcwIJobInfo) : base(rcwIJobInfo) { }
  }
}
