Imports IsbInterop.Base

Namespace Searches.Wrappers
    ''' <summary>
    ''' Обертка над ISearchForObjectDescription.
    ''' </summary>
    Friend Class SearchForObjectDescription
        Inherits SearchDescription
        Implements ISearchForObjectDescription

        ''' <summary>
        ''' Инициализировать поиск.
        ''' </summary>
        ''' <param name="objectInfo"></param>
        Public Sub InitializeSearch(objectInfo As IObjectInfo) Implements ISearchForObjectDescription.InitializeSearch
            If objectInfo Is Nothing Then
                Throw New ArgumentNullException("objectInfo")
            End If

            Me.InvokeRcwInstanceMethod("InitializeSearch", DirectCast(objectInfo, IUnsafeRcwObjectAccessor).UnsafeRcwObject)
        End Sub

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwISearchForObjectDescription">COM-объект ISearchForObjectDescription.</param>
        Friend Sub New(rcwISearchForObjectDescription As Object)
            MyBase.New(rcwISearchForObjectDescription)
        End Sub
    End Class
End Namespace