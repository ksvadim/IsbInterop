namespace IsbInterop
{
  /// <summary>
  /// Пустая объект IS-Builder.
  /// </summary>
  internal class EmptyIsbObject : IsbComObjectWrapper
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    public EmptyIsbObject(object rcwObject) : base(rcwObject) { }
  }
}
