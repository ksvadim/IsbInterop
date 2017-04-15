Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над ITaskFactory.
  ''' </summary>
  Friend Class TaskFactory
    Inherits EdmsObjectFactory(Of ITask, ITaskInfo)
    Implements ITaskFactory

    ''' <summary>
    ''' Создает новую задачу.
    ''' </summary>
    ''' <returns>Новая задача.</returns>
    Public Function CreateNew() As ITask Implements ITaskFactory.CreateNew
      Dim rcwITask = InvokeRcwInstanceMethod("CreateNew")
      Return New Task(rcwITask, Scope)
    End Function

    ''' <summary>
    ''' Получает объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As ITask
      Dim rcwITask = GetRcwObjectById(id)
      Return New Task(rcwITask, Scope)
    End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As ITaskInfo
      Dim rcwITaskInfo = GetRcwObjectInfo(id)
      Return New TaskInfo(rcwITaskInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwITaskFactory As Object, scope As IScope)
      MyBase.New(rcwITaskFactory, scope)
    End Sub
  End Class
End Namespace