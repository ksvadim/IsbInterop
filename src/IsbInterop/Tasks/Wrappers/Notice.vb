Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над INotice.
  ''' </summary>
  Friend Class Notice
    Inherits CustomJob(Of INoticeInfo)
    Implements INotice
    ''' <summary>
    ''' Получить INoticeInfo.
    ''' </summary>
    ''' <returns>INoticeInfo.</returns>
    Public Overrides Function GetInfo() As INoticeInfo
      Dim rcwINoticeInfo = Me.GetRcwObjectInfo()
      Return New NoticeInfo(rcwINoticeInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwINotice">СOM-объект INotice.</param>
    Public Sub New(rcwINotice As Object)
      MyBase.New(rcwINotice)
    End Sub
  End Class
End NameSpace