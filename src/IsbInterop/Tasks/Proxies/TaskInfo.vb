Namespace Tasks.Proxies

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
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwITaskInfo As Object, scope As IScope)
      MyBase.New(rcwITaskInfo, scope)
    End Sub
  End Class
End NameSpace