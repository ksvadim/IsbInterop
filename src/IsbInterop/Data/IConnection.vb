Imports IsbInterop.Accessory

Namespace Data
  ''' <summary>
  ''' Соединение.
  ''' </summary>
  Public Interface IConnection
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Получить информацию о системе.
    ''' </summary>
    ''' <returns>Информация о системе.</returns>
    Function GetSystemInfo() As ISystemInfo

  End Interface
End NameSpace