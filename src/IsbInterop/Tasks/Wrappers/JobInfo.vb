Namespace Tasks.Wrappers
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
    Public Sub New(rcwIJobInfo As Object)
      MyBase.New(rcwIJobInfo)
    End Sub
  End Class
End Namespace