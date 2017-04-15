Imports IsbInterop.Accessory
Imports IsbInterop.Base
Imports IsbInterop.DataTypes.Enumerable

Namespace Searches

  ''' <summary>
  ''' Описание поиска.
  ''' </summary>
  Public Interface ISearchDescription
    Inherits IBaseIsbObject

    ''' <summary>
    ''' Выполняет поиск.
    ''' </summary>
    ''' <returns>Объект Contents.</returns>
    Function Execute(Of TI As IObjectInfo)() As IContents(Of TI)

    ''' <summary>
    ''' Выполняет поиск и показывает его результаты.
    ''' </summary>
    ''' <param name="mode">Режим отображения результатов поиска.</param>
    ''' <param name="suppressQuerySearchCriteria">Признак подавления показа диалога для заполнения значений критериев поиска:
    ''' True, если не нужно показывать диалог,
    ''' False, если диалог нужно показывать в зависимости от наличия запрашиваемых реквизитов.</param>
    Sub Show(mode As TSearchShowMode, suppressQuerySearchCriteria As Boolean)
  End Interface
End Namespace