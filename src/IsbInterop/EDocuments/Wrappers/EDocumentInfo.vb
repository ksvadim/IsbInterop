Imports IsbInterop.Base.Wrappers

Namespace EDocuments.Wrappers

    ''' <summary>
    ''' Обертка над IEDocumentInfo.
    ''' </summary>
    Friend Class EDocumentInfo
        Inherits ObjectInfo
        Implements IEDocumentInfo

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="documentInfo">Объект с информацией о документе DIRECTUM.</param>
        ''' <param name="scope">Область видимости.</param>
        Public Sub New(documentInfo As Object, scope As IScope)
            MyBase.New(documentInfo, scope)
        End Sub
    End Class
End Namespace