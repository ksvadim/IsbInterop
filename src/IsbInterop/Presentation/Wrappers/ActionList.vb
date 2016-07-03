Imports IsbInterop.Accessory.Wrappers

Namespace Presentation.Wrappers
  ''' <summary>
  ''' Обертка над IActionList.
  ''' </summary>
  Friend Class ActionList
    Inherits List(Of IAction)
    Implements IActionList
    ''' <summary>
    ''' Получить действие по имени.
    ''' </summary>
    ''' <param name="name">Имя действия.</param>
    ''' <returns>Действие из списка с именем name, если оно существует, иначе null.</returns>
    Public Function FindAction(name As String) As IAction Implements IActionList.FindAction
      Dim actionRcw = Me.InvokeRcwInstanceMethod("FindAction", name)
      Return If(actionRcw IsNot Nothing, New Action(actionRcw), Nothing)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIActionList">COM-объект IActionList.</param>
    Public Sub New(rcwIActionList As Object)
      MyBase.New(rcwIActionList)
    End Sub
  End Class
End Namespace