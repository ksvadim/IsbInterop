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
    /// <param name="scope">Область видимости.</param>
    public ControlJobInfo(object rcwIControlJobInfo, IScope scope)
      : base(rcwIControlJobInfo, scope) { }
  }
}
