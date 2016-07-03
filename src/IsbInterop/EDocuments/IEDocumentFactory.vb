Imports IsbInterop.Accessory
Imports IsbInterop.Base

Namespace EDocuments
  ''' <summary>
  ''' Фабрика электронных документов.
  ''' </summary>
  Public Interface IEDocumentFactory
    Inherits IEdmsObjectFactory(Of IEDocument, IEDocumentInfo)

    ''' <summary>
    ''' Связать документы.
    ''' </summary>
    ''' <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    ''' <param name="destinationEdocumentInfo">Информация о документе-приемнике.</param>
    ''' <remarks>В качестве объекта-источника, с которым производится связывание, 
    ''' можно указывать электронный документ или запись справочника.</remarks>
    Sub BindTo(sourceObjectInfo As IObjectInfo, destinationEdocumentInfo As IEDocumentInfo)

    ''' <summary>
    ''' Связать документы.
    ''' </summary>
    ''' <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    ''' <param name="destinationDocumentInfos">Информация о документах-приемниках, с которыми производится связывание.</param>
    Sub BindTo(sourceObjectInfo As IObjectInfo, destinationDocumentInfos As IContents(Of IEDocumentInfo))

    ''' <summary>
    ''' Создать новый документа из файла.
    ''' </summary>
    ''' <param name="edocumentTypeCode">Имя типа электронного документа. 
    ''' В качестве значения параметра следует передавать имя записи из справочника "Типы карточек электронных документов".</param>
    ''' <param name="edocumentKindCode">Код вида электронного документа.
    ''' В качестве значения параметра следует передавать код записи из справочника "Виды электронных документов".</param>
    ''' <param name="edocumentEditorCode">Код приложения редактора.
    ''' В качестве значения параметра следует передавать код записи из справочника "Приложения-редакторы".</param>
    ''' <param name="aSourceFileName">Полное имя файла, на основе которого создается документ.</param>
    ''' <param name="inExtendedFormat">Признак создания документа из файла структурированного электронного документа.
    ''' True, если нужно создать документ из файла структурированного электронного документа, иначе False.
    ''' По умолчанию параметр принимает значение False.</param>
    ''' <returns>Электронный документ.</returns>
    Function CreateNewFromFile(edocumentTypeCode As String, edocumentKindCode As String,
                               edocumentEditorCode As String, aSourceFileName As String,
                               Optional inExtendedFormat As Boolean = False) As IEDocument

  End Interface
End NameSpace