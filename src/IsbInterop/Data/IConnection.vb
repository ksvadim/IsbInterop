Imports IsbInterop.Accessory

Namespace Data

  ''' <summary>
  ''' Соединение.
  ''' </summary>
  Public Interface IConnection
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Информация о системе.
    ''' </summary>
     ReadOnly Property SystemInfo As ISystemInfo
  End Interface
End NameSpace