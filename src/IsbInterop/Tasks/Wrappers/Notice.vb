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
      Dim rcwINoticeInfo = GetRcwObjectInfo()
      Return New NoticeInfo(rcwINoticeInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwINotice">СOM-объект INotice.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwINotice As Object, scope As IScope)
      MyBase.New(rcwINotice, scope)
    End Sub
  End Class
End NameSpace