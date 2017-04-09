using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IControlJob
  /// </summary>
  internal class ControlJob : CustomJob<IControlJobInfo>, IControlJob
  {
    /// <summary>
    /// Информация об объекте.
    /// </summary>
    public override IControlJobInfo Info
    {
      get
      {
        var rcwIControlJobInfo = GetRcwObjectInfo();
        return new ControlJobInfo(rcwIControlJobInfo, Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIControlJob">СOM-объект IControlJob.</param>
    /// <param name="scope">Область видимости.</param>
    public ControlJob(object rcwIControlJob, IScope scope) : base(rcwIControlJob, scope) { }
  }
}
