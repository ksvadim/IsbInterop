namespace IsbInterop.Data
{
  /// <summary>
  /// Описание допустимого значения реквизита типа «Признак».
  /// </summary>
  public interface IPickRequisiteItem : IIsbComObjectWrapper
  {
    /// <summary>
    /// Внутренний ИД допустимого значения реквизита, хранящийся в базе данных.
    /// </summary>
    int Id { get; }
  }
}
