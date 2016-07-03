Imports IsbInterop.Base.Wrappers

Namespace ComponentTokens.Wrappers
  ''' <summary>
  ''' Обертка над IComponentToken.
  ''' </summary>
  Friend Class ComponentToken
    Inherits EdmsObject(Of IComponentTokenInfo)
    Implements IComponentToken
    ''' <summary>
    ''' Получить IComponentTokenInfo.
    ''' </summary>
    ''' <returns>IComponentTokenInfo.</returns>
    Public Overrides Function GetInfo() As IComponentTokenInfo
      Dim rcwIComponentTokenInfo = Me.GetRcwObjectInfo()
      Return New ComponentTokenInfo(rcwIComponentTokenInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIComponentToken">СOM-объект IComponentToken.</param>
    Public Sub New(rcwIComponentToken As Object)
      MyBase.New(rcwIComponentToken)
    End Sub
  End Class
End NameSpace