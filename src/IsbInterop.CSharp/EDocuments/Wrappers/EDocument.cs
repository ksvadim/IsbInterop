using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;
using IsbInterop.Base.Wrappers;
using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.EDocuments.Wrappers
{
  /// <summary>
  /// Обертка над IEDocument.
  /// </summary>
  internal class EDocument : EdmsObject<IEDocumentInfo>, IEDocument
  {
    /// <summary>
    /// Экспортирует электронный документ.
    /// </summary>
    /// <param name="versionNumber">Номер версии.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="needLock">Признак необходимости блокировки.</param>
    /// <param name="needCompress">Признак необходимости выполнения сжатия.</param>
    /// <param name="inExtendedFormat">Признак экспорта в ESD.</param>
    /// <param name="signatureType">Тип подписи.</param>
    public void Export(int versionNumber, string fileName, bool needLock = true,
      bool needCompress = true, bool inExtendedFormat = true, 
      TExportedSignaturesType signatureType = TExportedSignaturesType.estAll)
    {
      InvokeRcwInstanceMethod("Export", new object[] { versionNumber, fileName,
        needLock, needCompress, inExtendedFormat, (int)signatureType });
    }

    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте</returns>
    public override IEDocumentInfo GetInfo()
    {
      var rcwIEDocumentInfo = this.GetRcwObjectInfo();
      return new EDocumentInfo(rcwIEDocumentInfo, this.Scope);
    }

    /// <summary>
    /// Получить cписок версий документа.
    /// </summary>
    /// <returns>Список версий документа.</returns>
    public IList<IEDocumentVersion> GetVersions()
    {
      var rcwVersions = GetRcwProperty("Versions");
      return new List<IEDocumentVersion>(rcwVersions, Scope);
    }

    /// <summary>
    /// Импортирует версию из файла.
    /// </summary>
    /// <param name="versionNumber">Номер версии.</param>
    /// <param name="versionNote">Комментарий к версии.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="needLock">Признак необходимости блокировки.</param>
    /// <param name="editorCode">Код приложения-редактора.</param>
    /// <param name="inExtendedFormat">Признак, что выполняется импорт из ESD.</param>
    public void ImportFromFile(int versionNumber, string versionNote, string fileName,
      bool needLock = true, string editorCode = "", bool inExtendedFormat = true)
    {
      InvokeRcwInstanceMethod("ImportFromFile", new object[] { versionNumber, versionNote, fileName, needLock, editorCode, inExtendedFormat });
    }

    /// <summary>
    /// Импортирует подписи из ESD.
    /// </summary>
    /// <param name="versionNumber">Номер версии документа.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="checkSigns">Признак необходимости проверки подписей при импорте.</param>
    public void ImportSignsFromExtendedFormat(int versionNumber, string fileName, bool checkSigns)
    {
      InvokeRcwInstanceMethod("ImportSignsFromExtendedFormat", new object[] { versionNumber, fileName, checkSigns });
    }

    /// <summary>
    /// Открыват электронный документ.
    /// </summary>
    /// <param name="openForWrite">Признак открытия для редактирования.</param>
    /// <param name="versionNumber">Номер версии.</param>
    public void Open(bool openForWrite, int versionNumber)
    {
      InvokeRcwInstanceMethod("Open", new object[] { openForWrite, versionNumber });
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEDocument">СOM-объект IEDocument.</param>
    /// <param name="scope">Область видимости.</param>
    public EDocument(object rcwIEDocument, IScope scope) : base(rcwIEDocument, scope) { }
  }
}
