Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Wrappers

Namespace Data.Wrappers
    ''' <summary>
    ''' Обертка над IConnection.
    ''' </summary>
    Friend Class Connection
        Inherits IsbComObjectWrapper
        Implements IConnection

        ''' <summary>
        ''' Получить информацию о системе.
        ''' </summary>
        ''' <returns>Информация о системе.</returns>
        Public Function GetSystemInfo() As ISystemInfo Implements IConnection.GetSystemInfo
            Dim rcwSystemInfo = Me.GetRcwProperty("SystemInfo")
            Return New SystemInfo(rcwSystemInfo)
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwConnection">СOM-объект IConnection.</param>
        Friend Sub New(rcwConnection As Object)
            MyBase.New(rcwConnection)
        End Sub
    End Class
End Namespace