﻿using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IJob.
  /// </summary>
  internal class Job : CustomJob<IJobInfo>, IJob
  {
    /// <summary>
    /// Информация об объекте.
    /// </summary>
    public override IJobInfo Info
    {
      get
      {
        var rcwIJobInfo = GetRcwObjectInfo();
        return new JobInfo(rcwIJobInfo, Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIJob">СOM-объект IJob.</param>
    /// <param name="scope">Область видимости.</param>
    public Job(object rcwIJob, IScope scope) : base(rcwIJob, scope) { }
  }
}
