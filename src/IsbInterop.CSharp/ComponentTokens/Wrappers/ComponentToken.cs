using IsbInterop.Base.Wrappers;

namespace IsbInterop.ComponentTokens.Wrappers
{
  /// <summary>
  /// Обертка над IComponentToken.
  /// </summary>
  internal class ComponentToken : EdmsObject<IComponentTokenInfo>, IComponentToken
  {
    /// <summary>
    /// Получить IComponentTokenInfo.
    /// </summary>
    /// <returns>IComponentTokenInfo.</returns>
    public override IComponentTokenInfo GetInfo()
    {
      var rcwIComponentTokenInfo = this.GetRcwObjectInfo();
      return new ComponentTokenInfo(rcwIComponentTokenInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIComponentToken">СOM-объект IComponentToken.</param>
    /// <param name="scope">Область видимости.</param>
    public ComponentToken(object rcwIComponentToken, IScope scope) : base(rcwIComponentToken, scope) { }
  }
}
