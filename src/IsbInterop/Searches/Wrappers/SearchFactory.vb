Namespace Searches.Wrappers

    ''' <summary>
    ''' Фабрика поисков.
    ''' </summary>
    Friend Class SearchFactory
        Inherits IsbComObjectWrapper
        Implements ISearchFactory

        ''' <summary>
        ''' Загружает описание поиска.
        ''' </summary>
        ''' <param name="searchName">Имя поиска.</param>
        ''' <returns>Описание поиска с указанным именем.</returns>
        Public Function Load(searchName As String) As ISearchForObjectDescription Implements ISearchFactory.Load
            Dim rcwSearchForObjectDescription = InvokeRcwInstanceMethod("Load", searchName)
            Return New SearchForObjectDescription(rcwSearchForObjectDescription, Scope)
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwISearchFactory">COM-объект ISearchFactory.</param>
        ''' <param name="scope">Область видимости.</param>
        Friend Sub New(rcwISearchFactory As Object, scope As IScope)
            MyBase.New(rcwISearchFactory, scope)
        End Sub
    End Class
End Namespace