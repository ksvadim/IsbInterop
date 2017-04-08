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
      return new CustomJobInfo(rcwIJobInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    /// <param name="scope">Область видимости.</param>
    public DefaultCustomJob(object rcwICustomJob, IScope scope) : base(rcwICustomJob, scope) { }
  }
}
