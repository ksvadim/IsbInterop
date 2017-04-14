using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IControlJob
  /// </summary>
  internal class ControlJob : CustomJob<IControlJobInfo>, IControlJob
  {
    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override IControlJobInfo GetInfo()
    {
      var rcwIControlJobInfo = GetRcwObjectInfo();
      return new ControlJobInfo(rcwIControlJobInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIControlJob">СOM-объект IControlJob.</param>
    /// <param name="scope">Область видимости.</param>
    public ControlJob(object rcwIControlJob, IScope scope) : base(rcwIControlJob, scope) { }
  }
}
