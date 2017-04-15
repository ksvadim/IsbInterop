Imports IsbInterop.Base.Proxies

Namespace ComponentTokens.Proxies

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
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIComponentTokenInfo As Object, scope As IScope)
      MyBase.New(rcwIComponentTokenInfo, scope)
    End Sub
  End Class
End NameSpace