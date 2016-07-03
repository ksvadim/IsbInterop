Imports IsbInterop.Base.Wrappers

Namespace ComponentTokens.Wrappers
  ''' <summary>
  ''' Обертка над IComponentTokenInfo.
  ''' </summary>
  Friend Class ComponentTokenInfo
    Inherits EdmsObjectInfo
    Implements IComponentTokenInfo
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIComponentTokenInfo">COM-объект IComponentTokenInfo.</param>
    Public Sub New(rcwIComponentTokenInfo As Object)
      MyBase.New(rcwIComponentTokenInfo)
    End Sub
  End Class
End NameSpace