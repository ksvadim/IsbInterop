namespace IsbInterop.Base
{
  /// <summary>
  /// Информация об объекте.
  /// </summary>
  public interface IObjectInfo : IBaseIsbObject
  {
    /// <summary>
    /// ИД документа.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Имя документа.
    /// </summary>
    string Name { get; }
  }
}
