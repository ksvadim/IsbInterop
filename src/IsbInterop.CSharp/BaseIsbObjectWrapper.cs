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
    public BaseIsbObjectWrapper(object rcwObject) : base(rcwObject) { }
  }
}
