Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Wrappers
Imports IsbInterop.Base
Imports IsbInterop.DataTypes.Enumerable

Namespace Searches.Wrappers
  ''' <summary>
  ''' Обертка над ISearchDescription.
  ''' </summary>
  Friend MustInherit Class SearchDescription
    Inherits IsbComObjectWrapper
    Implements ISearchDescription

    ''' <summary>
    ''' Выполнить поиск.
    ''' </summary>
    ''' <returns>Объект Contents.</returns>
    Public Function Execute(Of TI As IObjectInfo)() As IContents(Of TI) Implements ISearchDescription.Execute
      Dim rcwContents = Me.InvokeRcwInstanceMethod("Execute")
      Return New Contents(Of TI)(rcwContents)
    End Function

    ''' <summary>
    ''' Выполнить поиск и показать его результаты.
    ''' </summary>
    ''' <param name="mode">Режим отображения результатов поиска.</param>
    ''' <param name="suppressQuerySearchCriteria">Признак подавления показа диалога для заполнения значений критериев поиска: 
    ''' True, если не нужно показывать диалог, 
    ''' False, если диалог нужно показывать в зависимости от наличия запрашиваемых реквизитов.</param>
    Public Sub Show(mode As TSearchShowMode, suppressQuerySearchCriteria As Boolean) Implements ISearchDescription.Show
      Me.InvokeRcwInstanceMethod("Show", New Object() {mode, suppressQuerySearchCriteria})
    End Sub


    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwISearchDescription">COM-объект ISearchDescription.</param>
    Protected Sub New(rcwISearchDescription As Object)
      MyBase.New(rcwISearchDescription)
    End Sub
  End Class
End Namespace