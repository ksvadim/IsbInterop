using IsbInterop.Accessory;
using IsbInterop.Base;
using IsbInterop.Collections;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Edms;
using IsbInterop.EDocuments.Versions;

namespace IsbInterop.EDocuments
{
  /// <summary>
  /// Электронный документ.
  /// </summary>
  public interface IEDocument : IEdmsObject<IEDocumentInfo>
  {
    /// <summary>
    /// Экспортирует электронный документ.
    /// </summary>
    /// <param name="versionNumber">Номер версии.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="needLock">Признак необходимости блокировки.</param>
    /// <param name="needCompress">Признак необходимсоти выполнения сжатия.</param>
    /// <param name="inExtendedFormat">Признак экспорта в ESD.</param>
    /// <param name="signatureType">Тип подписи.</param>
    void Export(int versionNumber, string fileName, bool needLock = true,
      bool needCompress = true, bool inExtendedFormat = true,
      TExportedSignaturesType signatureType = TExportedSignaturesType.estAll);

    /// <summary>
    /// Получить список версий документа.
    /// </summary>
    /// <returns>Список версий документа.</returns>
    IList<IEDocumentVersion> GetVersions();

    /// <summary>
    /// Импортирует версию из файла.
    /// </summary>
    /// <param name="versionNumber">Номер версии.</param>
    /// <param name="versionNote">Комментарий к версии.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="needLock">Признак необходимости блокировки.</param>
    /// <param name="editorCode">Код приложения-редактора.</param>
    /// <param name="inExtendedFormat">Признак, что выполняется импорт из ESD.</param>
    void ImportFromFile(int versionNumber, string versionNote, string fileName,
      bool needLock = true, string editorCode = "", bool inExtendedFormat = true);

    /// <summary>
    /// Импортирует подписи из ESD.
    /// </summary>
    /// <param name="versionNumber">Номер версии документа.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="checkSigns">Признак неоходимости проверки подписей при импорте.</param>
    void ImportSignsFromExtendedFormat(int versionNumber, string fileName, bool checkSigns);

    /// <summary>
    /// Открывает электронный документ.
    /// </summary>
    /// <param name="openForWrite">Признак открытия для редактирования.</param>
    /// <param name="versionNumber">Номер версии.</param>
    void Open (bool openForWrite, int versionNumber);
  }
}
