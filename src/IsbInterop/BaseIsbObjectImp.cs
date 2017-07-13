namespace IsbInterop
{
  /// <summary>
  /// Имплементация базового объекта IS-Builder.
  /// </summary>
  internal sealed class BaseIsbObjectImp : BaseIsbObject
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="scope">Область видимости.</param>
    public BaseIsbObjectImp(object rcwObject, IScope scope)
      : base(rcwObject, scope) { }
  }
}
