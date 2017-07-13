namespace IsbInterop.Tasks.Proxies
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
    /// <param name="scope">Область видимости.</param>
    public JobInfo(object rcwIJobInfo, IScope scope) : base(rcwIJobInfo, scope) { }
  }
}
