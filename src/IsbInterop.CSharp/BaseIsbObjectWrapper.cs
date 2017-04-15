namespace IsbInterop
{
  /// <summary>
  /// Базовая обертка над объектом IS-Builder.
  /// </summary>
  internal class BaseIsbObjectWrapper : IsbComObjectWrapper
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="scope">Область видимости.</param>
    public BaseIsbObjectWrapper(object rcwObject, IScope scope)
      : base(rcwObject, scope) { }
  }
}
