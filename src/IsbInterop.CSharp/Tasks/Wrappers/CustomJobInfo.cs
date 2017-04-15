using IsbInterop.Base;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ICustomJobInfo.
  /// </summary>
  internal class CustomJobInfo : CustomWorkInfo, ICustomJobInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomJobInfo">COM-объект ICustomJobInfo.</param>
    /// <param name="scope">Область видимости.</param>
    public CustomJobInfo(object rcwICustomJobInfo, IScope scope)
      : base(rcwICustomJobInfo, scope) { }
  }
}
