Namespace Presentation.Wrappers
  ''' <summary>
  ''' Обертка над IAction.
  ''' </summary>
  Friend Class Action
    Inherits IsbComObjectWrapper
    Implements IAction
    ''' <summary>
    ''' Выполнить действие.
    ''' </summary>
    ''' <returns>True, если действие было выполнено, иначе false.</returns>
    Public Function Execute() As Boolean Implements IAction.Execute
      Dim result = CBool(Me.InvokeRcwInstanceMethod("Execute", Nothing, Nothing))
      Return result
    End Function

    ''' <summary>
    ''' Выполнить действие.
    ''' </summary>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>True, если действие было выполнено, иначе false.</returns>
    Public Function Execute(timeout As TimeSpan) As Boolean Implements IAction.Execute
      Dim result = CBool(Me.InvokeRcwInstanceMethod("Execute", Nothing, timeout))
      Return result
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIForm">СOM-объект IAction.</param>
    Public Sub New(rcwIForm As Object)
      MyBase.New(rcwIForm)
    End Sub
  End Class
End Namespace