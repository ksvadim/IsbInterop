Imports IsbInterop.Base

Namespace Tasks
  ''' <summary>
  ''' Задание-контроль.
  ''' </summary>
  Public Interface IControlJob
    Inherits ICustomJob(Of IControlJobInfo)
  End Interface
End NameSpace