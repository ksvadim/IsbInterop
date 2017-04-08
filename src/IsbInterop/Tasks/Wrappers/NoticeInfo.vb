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
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwINoticeInfo As Object, scope As IScope)
      MyBase.New(rcwINoticeInfo, scope)
    End Sub
  End Class
End NameSpace