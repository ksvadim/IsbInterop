Imports IsbInterop.Base

Namespace Searches.Proxies

    ''' <summary>
    ''' Обертка над ISearchForObjectDescription.
    ''' </summary>
    Friend Class SearchForObjectDescription
        Inherits SearchDescription
        Implements ISearchForObjectDescription

        ''' <summary>
        ''' Инициализирует поиск.
        ''' </summary>
        ''' <param name="objectInfo"></param>
        Public Sub InitializeSearch(objectInfo As IObjectInfo) Implements ISearchForObjectDescription.InitializeSearch
            If objectInfo Is Nothing Then
                Throw New ArgumentNullException("objectInfo")
            End If

            InvokeRcwInstanceMethod("InitializeSearch", DirectCast(objectInfo, IRcwProxy).RcwObject)
        End Sub

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwISearchForObjectDescription">COM-объект ISearchForObjectDescription.</param>
        ''' <param name="scope">Область видимости.</param>
        Friend Sub New(rcwISearchForObjectDescription As Object, scope As IScope)
            MyBase.New(rcwISearchForObjectDescription, scope)
        End Sub
    End Class
End Namespace