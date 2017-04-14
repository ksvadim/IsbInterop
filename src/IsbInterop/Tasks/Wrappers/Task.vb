Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над ITask.
  ''' </summary>
  Friend Class Task
    Inherits CustomWork(Of ITaskInfo)
    Implements ITask

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As ITaskInfo
      Dim rcwITasInfo = GetRcwObjectInfo()
      Return New TaskInfo(rcwITasInfo, Scope)
    End Function

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