Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над ITaskFactory.
  ''' </summary>
  Friend Class TaskFactory
    Inherits EdmsObjectFactory(Of ITask, ITaskInfo)
    Implements ITaskFactory

    ''' <summary>
    ''' Создать новую задачу.
    ''' </summary>
    ''' <returns>Новая задача.</returns>
    Public Function CreateNew() As ITask Implements ITaskFactory.CreateNew
      Dim rcwITask = Me.InvokeRcwInstanceMethod("CreateNew")
      Return New Task(rcwITask)
    End Function

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As ITask
      Dim rcwITask = Me.GetRcwObjectById(id)
      Return New Task(rcwITask)
    End Function

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As ITaskInfo
      Dim rcwITaskInfo = Me.GetRcwObjectInfo(id)
      Return New TaskInfo(rcwITaskInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    Public Sub New(rcwITaskFactory As Object)
      MyBase.New(rcwITaskFactory)
    End Sub
  End Class
End Namespace