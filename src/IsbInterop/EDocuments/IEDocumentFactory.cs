using IsbInterop.Accessory;
using IsbInterop.Base;
using IsbInterop.Collections;
using IsbInterop.Edms;

namespace IsbInterop.EDocuments
{
  /// <summary>
  /// Фабрика электронных документов.
  /// </summary>
  public interface IEDocumentFactory : IEdmsObjectFactory<IEDocument, IEDocumentInfo>
  {
    /// <summary>
    /// Связывает документы.
    /// </summary>
    /// <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    /// <param name="destinationEdocumentInfo">Информация о документе-приемнике.</param>
    /// <remarks>
    /// В качестве объекта-источника, с которым производится связывание,
    /// можно указывать электронный документ или запись справочника.
    /// </remarks>
    void BindTo(IObjectInfo sourceObjectInfo, IEDocumentInfo destinationEdocumentInfo);

    /// <summary>
    /// Связывает документы.
    /// </summary>
    /// <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    /// <param name="destinationDocumentInfos">Информация о документах-приемниках, с которыми производится связывание.</param>
    void BindTo(IObjectInfo sourceObjectInfo, IContents<IEDocumentInfo> destinationDocumentInfos);

    /// <summary>
    /// Создает новый документа из файла.
    /// </summary>
    /// <param name="edocumentTypeCode">Имя типа электронного документа.
    /// В качестве значения параметра следует передавать имя записи из справочника "Типы карточек электронных документов".</param>
    /// <param name="edocumentKindCode">Код вида электронного документа.
    /// В качестве значения параметра следует передавать код записи из справочника "Виды электронных документов".</param>
    /// <param name="edocumentEditorCode">Код приложения редактора.
    /// В качестве значения параметра следует передавать код записи из справочника "Приложения-редакторы".</param>
    /// <param name="aSourceFileName">Полное имя файла, на основе которого создается документ.</param>
    /// <param name="inExtendedFormat">Признак создания документа из файла структурированного электронного документа.
    /// True, если нужно создать документ из файла структурированного электронного документа, иначе False.
    /// По умолчанию параметр принимает значение False.</param>
    /// <returns>Электронный документ.</returns>
    IEDocument CreateNewFromFile(string edocumentTypeCode, string edocumentKindCode,
      string edocumentEditorCode, string aSourceFileName, bool inExtendedFormat = false);
  }
}
