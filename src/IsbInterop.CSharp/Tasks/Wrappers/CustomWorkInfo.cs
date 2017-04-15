using IsbInterop.Base;
using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над ICustomWorkInfo.
  /// </summary>
  internal class CustomWorkInfo : EdmsObjectInfo, ICustomWorkInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomWorkInfo">COM-объект ICustomWorkInfo.</param>
    /// <param name="scope">Область видимости.</param>
    public CustomWorkInfo(object rcwICustomWorkInfo, IScope scope)
      : base(rcwICustomWorkInfo, scope) { }
  }
}
