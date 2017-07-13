using IsbInterop.Base;
using IsbInterop.Base.Proxies;
using IsbInterop.Edms;
using IsbInterop.Edms.Proxies;

namespace IsbInterop.Tasks.Proxies
{
  /// <summary>
  /// Обертка над ICustomJob.
  /// </summary>
  internal class DefaultCustomJob : CustomJob<ICustomJobInfo>
  {
    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override ICustomJobInfo GetInfo()
    {
      var rcwIJobInfo = GetRcwObjectInfo();
      return new CustomJobInfo(rcwIJobInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    /// <param name="scope">Область видимости.</param>
    public DefaultCustomJob(object rcwICustomJob, IScope scope)
      : base(rcwICustomJob, scope) { }
  }
}
