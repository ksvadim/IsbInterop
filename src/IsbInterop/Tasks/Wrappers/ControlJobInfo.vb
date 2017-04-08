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
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIControlJobInfo As Object, scope As IScope)
      MyBase.New(rcwIControlJobInfo, scope)
    End Sub
  End Class
End NameSpace