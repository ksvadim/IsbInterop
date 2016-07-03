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
        Public Sub New(documentInfo As Object)
            MyBase.New(documentInfo)
        End Sub
    End Class
End Namespace