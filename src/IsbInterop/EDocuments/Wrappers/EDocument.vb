Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Wrappers
Imports IsbInterop.Base.Wrappers
Imports IsbInterop.DataTypes.Enumerable

Namespace EDocuments.Wrappers
  ''' <summary>
  ''' Обертка над IEDocument.
  ''' </summary>
  Friend Class EDocument
    Inherits EdmsObject(Of IEDocumentInfo)
    Implements IEDocument
    ''' <summary>
    ''' Экспорт электронного документа.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="needLock">Признак необходимости блокировки.</param>
    ''' <param name="needCompress">Признак необходимости выполнения сжатия.</param>
    ''' <param name="inExtendedFormat">Признак экспорта в ESD.</param>
    ''' <param name="signatureType">Тип подписи.</param>
    Public Sub Export(versionNumber As Integer, fileName As String, Optional needLock As Boolean = True,
                      Optional needCompress As Boolean = True, Optional inExtendedFormat As Boolean = True,
                      Optional signatureType As TExportedSignaturesType = TExportedSignaturesType.estAll) Implements IEDocument.Export
      Me.InvokeRcwInstanceMethod("Export", New Object() {versionNumber, fileName, needLock, needCompress, inExtendedFormat, CInt(signatureType)})
    End Sub

    ''' <summary>
    ''' Получить IEDocumentInfo.
    ''' </summary>
    ''' <returns>IEDocumentInfo.</returns>
    Public Overrides Function GetInfo() As IEDocumentInfo
      Dim rcwIEDocumentInfo = Me.GetRcwObjectInfo()
      Return New EDocumentInfo(rcwIEDocumentInfo)
    End Function

    ''' <summary>
    ''' Получить IsbObjectList версий документов.
    ''' </summary>
    ''' <returns>Список версий электронного документа.</returns>
    Public Function GetVersions() As IList(Of IEDocumentVersion) Implements IEDocument.GetVersions
      Dim rcwVersions = Me.GetRcwProperty("Versions")
      Return New List(Of IEDocumentVersion)(rcwVersions)
    End Function

    ''' <summary>
    ''' Импортировать версию из файла.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии.</param>
    ''' <param name="versionNote">Комментарий к версии.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="needLock">Признак необходимости блокировки.</param>
    ''' <param name="editorCode">Код приложения-редактора.</param>
    ''' <param name="inExtendedFormat">Признак, что выполняется импорт из ESD.</param>
    Public Sub ImportFromFile(versionNumber As Integer, versionNote As String, fileName As String,
                              Optional needLock As Boolean = True, Optional editorCode As String = "",
                              Optional inExtendedFormat As Boolean = True) Implements IEDocument.ImportFromFile
      Me.InvokeRcwInstanceMethod("ImportFromFile", New Object() {versionNumber, versionNote, fileName, needLock, editorCode, inExtendedFormat})
    End Sub

    ''' <summary>
    ''' Импортировать подписи из ESD.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии документа.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="checkSigns">Признак необходимости проверки подписей при импорте.</param>
    Public Sub ImportSignsFromExtendedFormat(versionNumber As Integer, fileName As String,
                                             checkSigns As Boolean) Implements IEDocument.ImportSignsFromExtendedFormat
      Me.InvokeRcwInstanceMethod("ImportSignsFromExtendedFormat", New Object() {versionNumber, fileName, checkSigns})
    End Sub

    ''' <summary>
    ''' Открыть электронный документ.
    ''' </summary>
    ''' <param name="openForWrite">Признак открытия для редактирования.</param>
    ''' <param name="versionNumber">Номер версии.</param>
    Public Sub Open(openForWrite As Boolean, versionNumber As Integer) Implements IEDocument.Open
      Me.InvokeRcwInstanceMethod("Open", New Object() {openForWrite, versionNumber})
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIEDocument">СOM-объект IEDocument.</param>
    Public Sub New(rcwIEDocument As Object)
      MyBase.New(rcwIEDocument)
    End Sub
  End Class
End Namespace