Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над IJob.
  ''' </summary>
  Friend Class Job
    Inherits CustomJob(Of IJobInfo)
    Implements IJob

    ''' <summary>
    ''' Информация об объекте.
    ''' </summary>
    Public Overrides ReadOnly Property Info As IJobInfo
      Get
        Dim rcwIJobInfo = GetRcwObjectInfo()
        Return New JobInfo(rcwIJobInfo, Scope)
      End Get
    End Property

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