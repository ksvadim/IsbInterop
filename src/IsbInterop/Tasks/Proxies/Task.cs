﻿using IsbInterop.Base.Proxies;
using IsbInterop.Edms.Proxies;

namespace IsbInterop.Tasks.Proxies
{
  /// <summary>
  /// Обертка над ITask.
  /// </summary>
  internal class Task : CustomWork<ITaskInfo>, ITask
  {
    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override ITaskInfo GetInfo()
    {
      var rcwITasInfo = GetRcwObjectInfo();
      return new TaskInfo(rcwITasInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITask">СOM-объект ITask.</param>
    /// <param name="scope">Область видимости.</param>
    public Task(object rcwITask, IScope scope) : base(rcwITask, scope) { }
  }
}
