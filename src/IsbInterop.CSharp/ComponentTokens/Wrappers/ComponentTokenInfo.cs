using IsbInterop.Base.Wrappers;

namespace IsbInterop.ComponentTokens.Wrappers
{
  /// <summary>
  /// Обертка над IComponentTokenInfo.
  /// </summary>
  internal class ComponentTokenInfo : EdmsObjectInfo, IComponentTokenInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIComponentTokenInfo">COM-объект IComponentTokenInfo.</param>
    /// <param name="scope">Область видимости.</param>
    public ComponentTokenInfo(object rcwIComponentTokenInfo, IScope scope)
      : base(rcwIComponentTokenInfo, scope) { }
  }
}
