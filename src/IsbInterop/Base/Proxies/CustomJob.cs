namespace IsbInterop.Base.Proxies
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
    /// <param name="scope">Область видимости.</param>
    protected CustomJob(object rcwICustomJob, IScope scope) : base(rcwICustomJob, scope) { }
  }
}
