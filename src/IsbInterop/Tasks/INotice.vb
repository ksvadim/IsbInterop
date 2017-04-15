Imports IsbInterop.Base

Namespace Tasks

  ''' <summary>
  ''' Уведомление.
  ''' </summary>
  Public Interface INotice
    Inherits ICustomJob(Of INoticeInfo)
  End Interface
End Namespace