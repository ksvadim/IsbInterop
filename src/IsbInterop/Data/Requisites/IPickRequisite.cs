namespace IsbInterop.Data.Requisites
{
  /// <summary>
  /// Реквизит типа «Признак».
  /// </summary>
  public interface IPickRequisite : IRequisite
  {
    /// <summary>
    /// Cписок описаний допустимых значений реквизита.
    /// </summary>
    IPickRequisiteItems Items { get; }
  }
}
