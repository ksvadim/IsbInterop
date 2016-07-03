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
    public CustomJobInfo(object rcwICustomJobInfo) : base(rcwICustomJobInfo) { }
  }
}
