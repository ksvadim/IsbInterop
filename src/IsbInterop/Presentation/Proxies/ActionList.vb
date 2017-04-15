Imports IsbInterop.Accessory.Proxies

Namespace Presentation.Proxies

  ''' <summary>
  ''' Обертка над IActionList.
  ''' </summary>
  Friend Class ActionList
    Inherits List(Of IAction)
    Implements IActionList

    ''' <summary>
    ''' Получает действие по имени.
    ''' </summary>
    ''' <param name="name">Имя действия.</param>
    ''' <returns>Действие из списка с именем name, если оно существует, иначе null.</returns>
    Public Function FindAction(name As String) As IAction Implements IActionList.FindAction
      Dim actionRcw = InvokeRcwInstanceMethod("FindAction", name)
      Return If(actionRcw IsNot Nothing, New Action(actionRcw, Scope), Nothing)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIActionList">COM-объект IActionList.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIActionList As Object, scope As IScope)
      MyBase.New(rcwIActionList, scope)
    End Sub
  End Class
End Namespace