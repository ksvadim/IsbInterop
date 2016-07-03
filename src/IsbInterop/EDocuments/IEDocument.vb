Imports IsbInterop.Accessory
Imports IsbInterop.Base
Imports IsbInterop.DataTypes.Enumerable

Namespace EDocuments
  ''' <summary>
  ''' Электронный документ.
  ''' </summary>
  Public Interface IEDocument
    Inherits IEdmsObject(Of IEDocumentInfo)

    ''' <summary>
    ''' Экспорт электронного документа.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="needLock">Признак необходимости блокировки.</param>
    ''' <param name="needCompress">Признак необходимсоти выполнения сжатия.</param>
    ''' <param name="inExtendedFormat">Признак экспорта в ESD.</param>
    ''' <param name="signatureType">Тип подписи.</param>
    Sub Export(versionNumber As Integer, fileName As String, Optional needLock As Boolean = True,
               Optional needCompress As Boolean = True, Optional inExtendedFormat As Boolean = True,
               Optional signatureType As TExportedSignaturesType = TExportedSignaturesType.estAll)

    ''' <summary>
    ''' Получить IsbObjectList версий документов.
    ''' </summary>
    ''' <returns>IsbObjectList.</returns>
    Function GetVersions() As IList(Of IEDocumentVersion)

    ''' <summary>
    ''' Импортировать версию из файла.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии.</param>
    ''' <param name="versionNote">Комментарий к версии.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="needLock">Признак необходимости блокировки.</param>
    ''' <param name="editorCode">Код приложения-редактора.</param>
    ''' <param name="inExtendedFormat">Признак, что выполняется импорт из ESD.</param>
    Sub ImportFromFile(versionNumber As Integer, versionNote As String, fileName As String, Optional needLock As Boolean = True,
                       Optional editorCode As String = "", Optional inExtendedFormat As Boolean = True)

    ''' <summary>
    ''' Импортировать подписи из ESD.
    ''' </summary>
    ''' <param name="versionNumber">Номер версии документа.</param>
    ''' <param name="fileName">Имя файла.</param>
    ''' <param name="checkSigns">Признак неоходимости проверки подписей при импорте.</param>
    Sub ImportSignsFromExtendedFormat(versionNumber As Integer, fileName As String, checkSigns As Boolean)

    ''' <summary>
    ''' Открыть электронный документ.
    ''' </summary>
    ''' <param name="openForWrite">Признак открытия для редактирования.</param>
    ''' <param name="versionNumber">Номер версии.</param>
    Sub Open(openForWrite As Boolean, versionNumber As Integer)
  End Interface
End Namespace