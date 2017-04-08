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
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwICustomJobInfo As Object, scope As IScope)
      MyBase.New(rcwICustomJobInfo, scope)
    End Sub
  End Class
End NameSpace