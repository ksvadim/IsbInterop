﻿using IsbInterop.Base;
using IsbInterop.Edms;

namespace IsbInterop.Tasks
{
  /// <summary>
  /// Фабрика заданий.
  /// </summary>
  public interface IJobFactory : IEdmsObjectFactory<ICustomJob<ICustomJobInfo>, ICustomJobInfo>
  {
  }
}
