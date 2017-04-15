Imports IsbInterop.Accessory
Imports IsbInterop.Base
Imports IsbInterop.Base.Proxies

Namespace EDocuments.Proxies

  ''' <summary>
  ''' Обертка над IEDocumentFactory.
  ''' </summary>
  Friend Class EDocumentFactory
    Inherits EdmsObjectFactory(Of IEDocument, IEDocumentInfo)
    Implements IEDocumentFactory

    ''' <summary>
    ''' Связывает документы.
    ''' </summary>
    ''' <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    ''' <param name="destinationEdocumentInfo">Информация о документе-приемнике.</param>
    Public Sub BindTo(sourceObjectInfo As IObjectInfo, destinationEdocumentInfo As IEDocumentInfo) Implements IEDocumentFactory.BindTo
      If sourceObjectInfo Is Nothing Then
        Throw New ArgumentNullException("sourceObjectInfo")
      End If

      If destinationEdocumentInfo Is Nothing Then
        Throw New ArgumentNullException("destinationEdocumentInfo")
      End If

      InvokeRcwInstanceMethod("BindTo", New Object() { DirectCast(sourceObjectInfo, IRcwProxy).RcwObject,
                              DirectCast(destinationEdocumentInfo, IRcwProxy).RcwObject })
    End Sub

    ''' <summary>
    ''' Связывает документы.
    ''' </summary>
    ''' <param name="sourceObjectInfo">Информация о объекте-источнике.</param>
    ''' <param name="destinationDocumentInfos">Информация о документах-приемниках, с которыми производится связывание.</param>
    Public Sub BindTo(sourceObjectInfo As IObjectInfo, destinationDocumentInfos As IContents(Of IEDocumentInfo)) Implements IEDocumentFactory.BindTo
      If sourceObjectInfo Is Nothing Then
        Throw New ArgumentNullException("sourceObjectInfo")
      End If

      If destinationDocumentInfos Is Nothing Then
        Throw New ArgumentNullException("destinationDocumentInfos")
      End If

      InvokeRcwInstanceMethod("BindTo", New Object() { DirectCast(sourceObjectInfo, IRcwProxy).RcwObject,
                              DirectCast(destinationDocumentInfos, IRcwProxy).RcwObject })
    End Sub

    ''' <summary>
    ''' Создает новый документа из файла.
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
    Public Function CreateNewFromFile(edocumentTypeCode As String, edocumentKindCode As String, edocumentEditorCode As String,
                                      aSourceFileName As String, Optional inExtendedFormat As Boolean = False) As IEDocument Implements IEDocumentFactory.CreateNewFromFile
      Dim rcwIEDocument = InvokeRcwInstanceMethod("CreateNewFromFile", New Object() {
                                                  edocumentTypeCode, edocumentKindCode,
                                                  edocumentEditorCode, aSourceFileName,
                                                  inExtendedFormat })
      Return New EDocument(rcwIEDocument, Scope)
    End Function


    ''' <summary>
    ''' Получает объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As IEDocument
      Dim rcwObject = GetRcwObjectById(id)

      Return New EDocument(rcwObject, Scope)
    End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IEDocumentInfo
      Dim rcwIEdocumentInfo = GetRcwObjectInfo(id)
      Return New EDocumentInfo(rcwIEdocumentInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIEDocumentFactory">Фабрика электронных документов.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwIEDocumentFactory As Object, scope As IScope)
      MyBase.New(rcwIEDocumentFactory, scope)
    End Sub
  End Class
End Namespace