Namespace Searches.Wrappers
    ''' <summary>
    ''' Фабрика поисков.
    ''' </summary>
    Friend Class SearchFactory
        Inherits IsbComObjectWrapper
        Implements ISearchFactory

        ''' <summary>
        ''' Загрузить описание поиска.
        ''' </summary>
        ''' <param name="searchName">Имя поиска.</param>
        ''' <returns>Описание поиска с указанным именем.</returns>
        Public Function Load(searchName As String) As ISearchForObjectDescription Implements ISearchFactory.Load
            Dim rcwSearchForObjectDescription = Me.InvokeRcwInstanceMethod("Load", searchName)
            Return New SearchForObjectDescription(rcwSearchForObjectDescription)
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwISearchFactory">COM-объект ISearchFactory.</param>
        Friend Sub New(rcwISearchFactory As Object)
            MyBase.New(rcwISearchFactory)
        End Sub
    End Class
End Namespace