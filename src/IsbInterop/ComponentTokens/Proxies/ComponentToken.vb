Imports IsbInterop.Base.Proxies

Namespace ComponentTokens.Proxies

  ''' <summary>
  ''' Обертка над IComponentToken.
  ''' </summary>
  Friend Class ComponentToken
    Inherits EdmsObject(Of IComponentTokenInfo)
    Implements IComponentToken

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As IComponentTokenInfo
      Dim rcwIComponentTokenInfo = GetRcwObjectInfo()
      Return New ComponentTokenInfo(rcwIComponentTokenInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIComponentToken">СOM-объект IComponentToken.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIComponentToken As Object, scope As IScope)
      MyBase.New(rcwIComponentToken, scope)
    End Sub
  End Class
End Namespace