﻿using IsbInterop.Base.Proxies;
using IsbInterop.Edms.Proxies;

namespace IsbInterop.Tasks.Proxies
{
  /// <summary>
  /// Обертка над IJob.
  /// </summary>
  internal class Job : CustomJob<IJobInfo>, IJob
  {
    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override IJobInfo GetInfo()
    {
      var rcwIJobInfo = GetRcwObjectInfo();
      return new JobInfo(rcwIJobInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIJob">СOM-объект IJob.</param>
    /// <param name="scope">Область видимости.</param>
    public Job(object rcwIJob, IScope scope) : base(rcwIJob, scope) { }
  }
}
