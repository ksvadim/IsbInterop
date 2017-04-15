Imports IsbInterop.Base.Proxies

Namespace Tasks.Proxies

  ''' <summary>
  ''' Обертка над IJob.
  ''' </summary>
  Friend Class Job
    Inherits CustomJob(Of IJobInfo)
    Implements IJob

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As IJobInfo
      Dim rcwIJobInfo = GetRcwObjectInfo()
      Return New JobInfo(rcwIJobInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIJob">СOM-объект IJob.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIJob As Object, scope As IScope)
      MyBase.New(rcwIJob, scope)
    End Sub
  End Class
End Namespace