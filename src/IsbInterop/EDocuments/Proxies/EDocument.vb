Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Proxies
Imports IsbInterop.Base.Proxies
Imports IsbInterop.DataTypes.Enumerable

Namespace EDocuments.Proxies

  ''' <summary>
  ''' Обертка над IEDocument.
  ''' </summary>
  Friend Class EDocument
    Inherits EdmsObject(Of IEDocumentInfo)
    Implements IEDocument

    ''' <summary>
    ''' Экспортирует электронный документ.
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
      InvokeRcwInstanceMethod("Export", New Object() {versionNumber, fileName, needLock, needCompress, inExtendedFormat, CInt(signatureType)})
    End Sub

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As IEDocumentInfo
      Dim rcwIEDocumentInfo = GetRcwObjectInfo()
      Return New EDocumentInfo(rcwIEDocumentInfo, Scope)
    End Function

    ''' <summary>
    ''' Получить список версий документа.
    ''' </summary>
    ''' <returns>Список версий документа.</returns>
    Public Function GetVersions() As IList(Of IEDocumentVersion) Implements IEDocument.GetVersions
      Dim rcwVersions = GetRcwProperty("Versions")
      Return New List(Of IEDocumentVersion)(rcwVersions, Scope)
    End Function

    ''' <summary>
    ''' Импортирует версию из файла.
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
      InvokeRcwInstanceMethod("ImportFromFile", New Object() {versionNumber, versionNote, fileName, needLock, editorCode, inExtendedFormat})
    End Sub

    ''' <summary>
    ''' Импортирует подписи из ESD.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии документа.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="checkSigns">Признак необходимости проверки подписей при импорте.</param>
    Public Sub ImportSignsFromExtendedFormat(versionNumber As Integer, fileName As String,
                                             checkSigns As Boolean) Implements IEDocument.ImportSignsFromExtendedFormat
      InvokeRcwInstanceMethod("ImportSignsFromExtendedFormat", New Object() {versionNumber, fileName, checkSigns})
    End Sub

    ''' <summary>
    ''' Открывает электронный документ.
    ''' </summary>
    ''' <param name="openForWrite">Признак открытия для редактирования.</param>
    ''' <param name="versionNumber">Номер версии.</param>
    Public Sub Open(openForWrite As Boolean, versionNumber As Integer) Implements IEDocument.Open
      InvokeRcwInstanceMethod("Open", New Object() {openForWrite, versionNumber})
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIEDocument">СOM-объект IEDocument.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIEDocument As Object, scope As IScope)
      MyBase.New(rcwIEDocument, scope)
    End Sub
  End Class
End Namespace