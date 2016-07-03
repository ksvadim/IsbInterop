Imports IsbInterop.Base

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над ICustomJobInfo.
  ''' </summary>
  Friend Class CustomJobInfo
    Inherits CustomWorkInfo
    Implements ICustomJobInfo
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwICustomJobInfo">COM-объект ICustomJobInfo.</param>
    Public Sub New(rcwICustomJobInfo As Object)
      MyBase.New(rcwICustomJobInfo)
    End Sub
  End Class
End NameSpace