Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над ITask.
  ''' </summary>
  Friend Class Task
    Inherits CustomWork(Of ITaskInfo)
    Implements ITask

    ''' <summary>
    ''' Информация об объекте.
    ''' </summary>
    Public Overrides ReadOnly Property Info As ITaskInfo
      Get
        Dim rcwITasInfo = GetRcwObjectInfo()
        Return New TaskInfo(rcwITasInfo, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITask">СOM-объект ITask.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwITask As Object, scope As IScope)
      MyBase.New(rcwITask, scope)
    End Sub
  End Class
End Namespace