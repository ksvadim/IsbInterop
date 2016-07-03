namespace IsbInterop.Data
{
  /// <summary>
  /// Описание допустимого значения реквизита типа «Признак».
  /// </summary>
  public interface IPickRequisiteItem : IIsbComObjectWrapper
  {
    /// <summary>
    /// Внутренний идентификатор допустимого значения реквизита, хранящийся в базе данных.
    /// </summary>
    int Id { get; }
  }
}
