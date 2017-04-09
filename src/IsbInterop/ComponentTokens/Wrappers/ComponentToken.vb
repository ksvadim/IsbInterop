Imports IsbInterop.Base.Wrappers

Namespace ComponentTokens.Wrappers

  ''' <summary>
  ''' Обертка над IComponentToken.
  ''' </summary>
  Friend Class ComponentToken
    Inherits EdmsObject(Of IComponentTokenInfo)
    Implements IComponentToken

    ''' <summary>
    ''' Информация об объекте.
    ''' </summary>
    Public Overrides ReadOnly Property Info As IComponentTokenInfo
      Get
        Dim rcwIComponentTokenInfo = GetRcwObjectInfo()
        Return New ComponentTokenInfo(rcwIComponentTokenInfo, Scope)
      End Get
    End Property

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