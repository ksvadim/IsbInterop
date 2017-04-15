Imports IsbInterop.Base

Namespace Tasks

  ''' <summary>
  ''' Фабрика заданий.
  ''' </summary>
  Public Interface IJobFactory
    Inherits IEdmsObjectFactory(Of ICustomJob(Of ICustomJobInfo), ICustomJobInfo)
  End Interface
End NameSpace