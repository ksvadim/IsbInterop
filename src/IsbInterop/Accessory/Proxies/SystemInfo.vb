Namespace Accessory.Proxies

  ''' <summary>
  ''' Обертка над ISystemInfo.
  ''' </summary>
  Friend Class SystemInfo
    Inherits BaseIsbObject
    Implements ISystemInfo

    ''' <summary>
    ''' Версия клиента.
    ''' </summary>
    Public ReadOnly Property ClientVerson As String Implements ISystemInfo.ClientVerson
      Get
        Return DirectCast(GetRcwProperty("ClientVersion"), String)
      End Get
    End Property

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="systemInfo">Объект с информацией о системе.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(systemInfo As Object, scope As IScope)
      MyBase.New(systemInfo, scope)
    End Sub
  End Class
End Namespace
