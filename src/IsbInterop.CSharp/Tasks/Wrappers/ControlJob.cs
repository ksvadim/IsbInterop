using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IControlJob
  /// </summary>
  internal class ControlJob : CustomJob<IControlJobInfo>, IControlJob
  {
    /// <summary>
    /// Получить IControlJobInfo.
    /// </summary>
    /// <returns>IControlJobInfo.</returns>
    public override IControlJobInfo GetInfo()
    {
      var rcwIControlJobInfo = this.GetRcwObjectInfo();
      return new ControlJobInfo(rcwIControlJobInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIControlJob">СOM-объект IControlJob.</param>
    public ControlJob(object rcwIControlJob) : base(rcwIControlJob) { }
  }
}
