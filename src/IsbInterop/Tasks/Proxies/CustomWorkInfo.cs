using IsbInterop.Base;
using IsbInterop.Base.Proxies;
using IsbInterop.Edms;
using IsbInterop.Edms.Proxies;

namespace IsbInterop.Tasks.Proxies
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
