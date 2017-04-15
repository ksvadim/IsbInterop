Namespace Searches

  ''' <summary>
  ''' Фабрика поисков.
  ''' </summary>
  Public Interface ISearchFactory
    Inherits IBaseIsbObject

    ''' <summary>
    ''' Загружает описание поиска.
    ''' </summary>
    ''' <param name="searchName">Имя поиска.</param>
    ''' <returns>Описание поиска с указанным именем.</returns>
    Function Load(searchName As String) As ISearchForObjectDescription
  End Interface
End Namespace