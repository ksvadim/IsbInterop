namespace IsbInterop.Data.Requisites
{
  /// <summary>
  /// Описание допустимого значения реквизита типа «Признак».
  /// </summary>
  public interface IPickRequisiteItem : IBaseIsbObject
  {
    /// <summary>
    /// Внутренний ИД допустимого значения реквизита, хранящийся в базе данных.
    /// </summary>
    int Id { get; }
  }
}
