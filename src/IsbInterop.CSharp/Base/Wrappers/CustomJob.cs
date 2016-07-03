namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над ICustomJob.
  /// </summary>
  internal abstract class CustomJob<TI> : CustomWork<TI>, ICustomJob<TI> 
    where TI : ICustomJobInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    protected CustomJob(object rcwICustomJob) : base(rcwICustomJob) { }
  }
}
