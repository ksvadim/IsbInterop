Imports IsbInterop.Base

Namespace Tasks
  ''' <summary>
  ''' Задача.
  ''' </summary>
  Public Interface ITask
    Inherits ICustomWork(Of ITaskInfo)
  End Interface
End NameSpace