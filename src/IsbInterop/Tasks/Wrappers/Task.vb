Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над ITask.
  ''' </summary>
  Friend Class Task
    Inherits CustomWork(Of ITaskInfo)
    Implements ITask
    ''' <summary>
    ''' Получить ITaskInfo.
    ''' </summary>
    ''' <returns>ITaskInfo.</returns>
    Public Overrides Function GetInfo() As ITaskInfo
      Dim rcwITasInfo = Me.GetRcwObjectInfo()
      Return New TaskInfo(rcwITasInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITask">СOM-объект ITask.</param>
    Public Sub New(rcwITask As Object)
      MyBase.New(rcwITask)
    End Sub
  End Class
End NameSpace