namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IControlJobInfo.
  /// </summary>
  internal class ControlJobInfo : CustomJobInfo, IControlJobInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIControlJobInfo">COM-объект IControlJobInfo.</param>
    public ControlJobInfo(object rcwIControlJobInfo) : base(rcwIControlJobInfo) { }
  }
}
