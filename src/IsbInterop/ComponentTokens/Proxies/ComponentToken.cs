using IsbInterop.Base.Proxies;

namespace IsbInterop.ComponentTokens.Proxies
{
  /// <summary>
  /// Обертка над IComponentToken.
  /// </summary>
  internal class ComponentToken : EdmsObject<IComponentTokenInfo>, IComponentToken
  {
    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override IComponentTokenInfo GetInfo()
    {
      var rcwIComponentTokenInfo = GetRcwObjectInfo();
      return new ComponentTokenInfo(rcwIComponentTokenInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIComponentToken">СOM-объект IComponentToken.</param>
    /// <param name="scope">Область видимости.</param>
    public ComponentToken(object rcwIComponentToken, IScope scope)
      : base(rcwIComponentToken, scope) { }
  }
}
