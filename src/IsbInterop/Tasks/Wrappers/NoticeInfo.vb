Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над INoticeInfo.
  ''' </summary>
  Friend Class NoticeInfo
    Inherits CustomJobInfo
    Implements INoticeInfo
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwINoticeInfo">COM-объект IJobInfo.</param>
    Public Sub New(rcwINoticeInfo As Object)
      MyBase.New(rcwINoticeInfo)
    End Sub
  End Class
End NameSpace