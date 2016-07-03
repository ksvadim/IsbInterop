Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над ICustomJob.
  ''' </summary>
  Friend Class DefaultCustomJob
    Inherits CustomJob(Of ICustomJobInfo)
    ''' <summary>
    ''' Получить ICustomJobInfo.
    ''' </summary>
    ''' <returns>ICustomJobInfo.</returns>
    Public Overrides Function GetInfo() As ICustomJobInfo
      Dim rcwIJobInfo = Me.GetRcwObjectInfo()
      Return New CustomJobInfo(rcwIJobInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    Public Sub New(rcwICustomJob As Object)
      MyBase.New(rcwICustomJob)
    End Sub
  End Class
End NameSpace