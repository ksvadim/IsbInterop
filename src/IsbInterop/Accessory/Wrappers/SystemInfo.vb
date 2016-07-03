Namespace Accessory.Wrappers
    ''' <summary>
    ''' Обертка над ISystemInfo.
    ''' </summary>
    Friend Class SystemInfo
        Inherits IsbComObjectWrapper
        Implements ISystemInfo
        ''' <summary>
        ''' Версия клиента.
        ''' </summary>
        Public ReadOnly Property ClientVerson() As String Implements ISystemInfo.ClientVerson
            Get
                Return DirectCast(Me.GetRcwProperty("ClientVersion"), String)
            End Get
        End Property

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="systemInfo">Объект с информацией о системе.</param>
        Friend Sub New(systemInfo As Object)
            MyBase.New(systemInfo)
        End Sub
    End Class
End Namespace
