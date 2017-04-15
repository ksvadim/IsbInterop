Imports IsbInterop.Base

Namespace Tasks

  ''' <summary>
  ''' Фабрика задач.
  ''' </summary>
  Public Interface ITaskFactory
    Inherits IEdmsObjectFactory(Of ITask, ITaskInfo)

    ''' <summary>
    ''' Создать новую задачу.
    ''' </summary>
    ''' <returns>Новая задача.</returns>
    Function CreateNew() As ITask
  End Interface
End Namespace