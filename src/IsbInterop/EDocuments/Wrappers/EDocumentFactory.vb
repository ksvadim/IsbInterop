Imports IsbInterop.Accessory
Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace EDocuments.Wrappers
    ''' <summary>
    ''' Обертка над IEDocumentFactory.
    ''' </summary>
    Friend Class EDocumentFactory
        Inherits EdmsObjectFactory(Of IEDocument, IEDocumentInfo)
        Implements IEDocumentFactory

        ''' <summary>
        ''' Связать документы.
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

            Me.InvokeRcwInstanceMethod("BindTo", New Object() {DirectCast(sourceObjectInfo, IUnsafeRcwObjectAccessor).UnsafeRcwObject, DirectCast(destinationEdocumentInfo, IUnsafeRcwObjectAccessor).UnsafeRcwObject})
        End Sub

        ''' <summary>
        ''' Связать документы.
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

            Me.InvokeRcwInstanceMethod("BindTo", New Object() {DirectCast(sourceObjectInfo, IUnsafeRcwObjectAccessor).UnsafeRcwObject, DirectCast(destinationDocumentInfos, IUnsafeRcwObjectAccessor).UnsafeRcwObject})
        End Sub

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
        Public Function CreateNewFromFile(edocumentTypeCode As String, edocumentKindCode As String, edocumentEditorCode As String,
                                          aSourceFileName As String, Optional inExtendedFormat As Boolean = False) As IEDocument Implements IEDocumentFactory.CreateNewFromFile
            Dim rcwIEDocument = Me.InvokeRcwInstanceMethod("CreateNewFromFile", New Object() {edocumentTypeCode, edocumentKindCode,
                                                                                              edocumentEditorCode, aSourceFileName,
                                                                                              inExtendedFormat})
            Return New EDocument(rcwIEDocument)
        End Function


        ''' <summary>
        ''' Получить объект по его ИД.
        ''' </summary>
        ''' <param name="id">ИД.</param>
        ''' <returns>Объект.</returns>
        Public Overrides Function GetObjectById(id As Integer) As IEDocument
            Dim rcwObject = Me.GetRcwObjectById(id)

            Return New EDocument(rcwObject)
        End Function

        ''' <summary>
        ''' Получить информацию об объекте.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <returns>Info-объект.</returns>
        Public Overrides Function GetObjectInfo(id As Integer) As IEDocumentInfo
            Dim rcwIEdocumentInfo = Me.GetRcwObjectInfo(id)
            Return New EDocumentInfo(rcwIEdocumentInfo)
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwIEDocumentFactory">Фабрика электронных документов.</param>
        Friend Sub New(rcwIEDocumentFactory As Object)
            MyBase.New(rcwIEDocumentFactory)
        End Sub

    End Class
End Namespace