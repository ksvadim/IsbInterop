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
End NameSpace