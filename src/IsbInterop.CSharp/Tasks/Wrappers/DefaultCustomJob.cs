using IsbInterop.Base;
using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ICustomJob.
  /// </summary>
  internal class DefaultCustomJob : CustomJob<ICustomJobInfo>
  {
    /// <summary>
    /// Получить ICustomJobInfo.
    /// </summary>
    /// <returns>ICustomJobInfo.</returns>
    public override ICustomJobInfo GetInfo()
    {
      var rcwIJobInfo = this.GetRcwObjectInfo();
      return new CustomJobInfo(rcwIJobInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    public DefaultCustomJob(object rcwICustomJob) : base(rcwICustomJob) { }
  }
}
