namespace IsbInterop.References.Proxies
{
  /// <summary>
  /// Обертка над IReference.
  /// </summary>
  internal class Reference : Component, IReference
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="reference">Справочник DIRECTUM.</param>
    /// <param name="scope">Область видимости.</param>
    public Reference(object reference, IScope scope) : base(reference, scope) { }
  }
}
