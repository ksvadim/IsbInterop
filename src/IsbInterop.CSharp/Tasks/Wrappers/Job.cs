using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IJob.
  /// </summary>
  internal class Job : CustomJob<IJobInfo>, IJob
  {
    /// <summary>
    /// Получить IJobInfo.
    /// </summary>
    /// <returns>IJobInfo.</returns>
    public override IJobInfo GetInfo()
    {
      var rcwIJobInfo = this.GetRcwObjectInfo();
      return new JobInfo(rcwIJobInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIJob">СOM-объект IJob.</param>
    public Job(object rcwIJob) : base(rcwIJob) { }
  }
}
