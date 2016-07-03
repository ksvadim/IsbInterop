Namespace Base
  ''' <summary>
  ''' Базовое задание.
  ''' </summary>
  Public Interface ICustomJob(Of  Out TI As ICustomJobInfo)
    Inherits ICustomWork(Of TI)
  End Interface
End NameSpace