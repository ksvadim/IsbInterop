Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над ITaskInfo.
  ''' </summary>
  Friend Class TaskInfo
    Inherits CustomWorkInfo
    Implements ITaskInfo
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITaskInfo">COM-объект ITaskInfo.</param>
    Public Sub New(rcwITaskInfo As Object)
      MyBase.New(rcwITaskInfo)
    End Sub
  End Class
End NameSpace