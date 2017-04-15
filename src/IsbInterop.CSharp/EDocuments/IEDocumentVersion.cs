using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.EDocuments
{
  /// <summary>
  /// Версия электронного документа.
  /// </summary>
  public interface IEDocumentVersion : IBaseIsbObject
  {
    /// <summary>
    /// Текущее сосотяние версии.
    /// </summary>
    TEDocumentVersionState CurrentState { get; }

    /// <summary>
    /// Скрытая версия.
    /// </summary>
    bool IsHidden { get; }

    /// <summary>
    /// Номер версии.
    /// </summary>
    int Number { get; }

    /// <summary>
    /// Размер версии.
    /// </summary>
    int Size { get; }
  }
}
