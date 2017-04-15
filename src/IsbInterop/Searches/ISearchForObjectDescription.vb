Imports IsbInterop.Base

Namespace Searches

  ''' <summary>
  ''' Описание поиска для объекта.
  ''' </summary>
  Public Interface ISearchForObjectDescription
    Inherits ISearchDescription

    ''' <summary>
    ''' Инициализирует поиск.
    ''' </summary>
    ''' <param name="directumObject">Информация об объекте поиска.</param>
    Sub InitializeSearch(directumObject As IObjectInfo)
  End Interface
End NameSpace