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
      return new JobInfo(rcwIJobInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIJob">СOM-объект IJob.</param>
    /// <param name="scope">Область видимости.</param>
    public Job(object rcwIJob, IScope scope) : base(rcwIJob, scope) { }
  }
}
