Namespace Tasks.Proxies

  ''' <summary>
  ''' Обертка над IJobInfo.
  ''' </summary>
  Friend Class JobInfo
    Inherits CustomJobInfo
    Implements IJobInfo

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIJobInfo">COM-объект IJobInfo.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIJobInfo As Object, scope As IScope)
      MyBase.New(rcwIJobInfo, scope)
    End Sub
  End Class
End Namespace