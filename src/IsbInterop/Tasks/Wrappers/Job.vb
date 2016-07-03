Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над IJob.
  ''' </summary>
  Friend Class Job
    Inherits CustomJob(Of IJobInfo)
    Implements IJob
    ''' <summary>
    ''' Получить IJobInfo.
    ''' </summary>
    ''' <returns>IJobInfo.</returns>
    Public Overrides Function GetInfo() As IJobInfo
      Dim rcwIJobInfo = Me.GetRcwObjectInfo()
      Return New JobInfo(rcwIJobInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIJob">СOM-объект IJob.</param>
    Public Sub New(rcwIJob As Object)
      MyBase.New(rcwIJob)
    End Sub
  End Class
End NameSpace