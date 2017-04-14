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
    ''' Получает информацию о системе.
    ''' </summary>
    ''' <returns>Информация о системе.</returns>
    Public Function GetSystemInfo() As ISystemInfo Implements IConnection.GetSystemInfo
      Dim rcwSystemInfo = GetRcwProperty("SystemInfo")
      Return New SystemInfo(rcwSystemInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwConnection">СOM-объект IConnection.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwConnection As Object, scope As IScope)
      MyBase.New(rcwConnection, scope)
    End Sub
  End Class
End Namespace