Imports IsbInterop.Accessory

Namespace Presentation

  ''' <summary>
  ''' Список действий.
  ''' </summary>
  Public Interface IActionList
    Inherits IList(Of IAction)

    ''' <summary>
    ''' Получает действие по имени.
    ''' </summary>
    ''' <param name="name">Имя действия.</param>
    ''' <returns>Действие из списка с именем name, если оно существует, иначе null.</returns>
    Function FindAction(name As String) As IAction
  End Interface
End NameSpace