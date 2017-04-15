using IsbInterop.Accessory;
using IsbInterop.Base;
using IsbInterop.Base.Wrappers;
using System;

namespace IsbInterop.EDocuments.Wrappers
{
  /// <summary>
  /// Обертка над IEDocumentFactory.
  /// </summary>
  internal class EDocumentFactory : EdmsObjectFactory<IEDocument, IEDocumentInfo>, IEDocumentFactory
  {
    /// <summary>
    /// Связывает документы.
    /// </summary>
    /// <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    /// <param name="destinationEdocumentInfo">Информация о документе-приемнике.</param>
    public void BindTo(IObjectInfo sourceObjectInfo, IEDocumentInfo destinationEdocumentInfo)
    {
      if (sourceObjectInfo == null)
        throw new ArgumentNullException(nameof(sourceObjectInfo));

      if (destinationEdocumentInfo == null)
        throw new ArgumentNullException(nameof(destinationEdocumentInfo));

      InvokeRcwInstanceMethod("BindTo", new[] {
        ((IRcwProxy)sourceObjectInfo).RcwObject,
        ((IRcwProxy)destinationEdocumentInfo).RcwObject });
    }
    
    /// <summary>
    /// Связывает документы.
    /// </summary>
    /// <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    /// <param name="destinationDocumentInfos">Информация о документах-приемниках, с которыми производится связывание.</param>
    public void BindTo(IObjectInfo sourceObjectInfo, IContents<IEDocumentInfo> destinationDocumentInfos)
    {
      if (sourceObjectInfo == null)
        throw new ArgumentNullException(nameof(sourceObjectInfo));

      if (destinationDocumentInfos == null)
        throw new ArgumentNullException(nameof(destinationDocumentInfos));

      InvokeRcwInstanceMethod("BindTo", new[] {
        ((IRcwProxy)sourceObjectInfo).RcwObject,
        ((IRcwProxy)destinationDocumentInfos).RcwObject });
    }

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
    public IEDocument CreateNewFromFile(string edocumentTypeCode, string edocumentKindCode,
      string edocumentEditorCode, string aSourceFileName, bool inExtendedFormat = false)
    {
      var rcwIEDocument = InvokeRcwInstanceMethod("CreateNewFromFile", new object[] {
        edocumentTypeCode, edocumentKindCode,
        edocumentEditorCode, aSourceFileName, inExtendedFormat});

      return new EDocument(rcwIEDocument, Scope);
    }

    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IEDocument GetObjectById(int id)
    {
      var rcwObject = GetRcwObjectById(id);

      return new EDocument(rcwObject, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IEDocumentInfo GetObjectInfo(int id)
    {
      var rcwIEdocumentInfo = GetRcwObjectInfo(id);
      return new EDocumentInfo(rcwIEdocumentInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEDocumentFactory">Фабрика электронных документов.</param>
    /// <param name="scope">Область видимости.</param>
    internal EDocumentFactory(object rcwIEDocumentFactory, IScope scope)
      : base(rcwIEDocumentFactory, scope) { }
  }
}
