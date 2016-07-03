Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над IControlJobInfo.
  ''' </summary>
  Friend Class ControlJobInfo
    Inherits CustomJobInfo
    Implements IControlJobInfo
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIControlJobInfo">COM-объект IControlJobInfo.</param>
    Public Sub New(rcwIControlJobInfo As Object)
      MyBase.New(rcwIControlJobInfo)
    End Sub
  End Class
End NameSpace