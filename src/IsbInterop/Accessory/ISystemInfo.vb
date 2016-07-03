Namespace Accessory
  ''' <summary>
  ''' Информация о системе.
  ''' </summary>
  Public Interface ISystemInfo
    Inherits IIsbComObjectWrapper
    ''' <summary>
    ''' Версия клиента.
    ''' </summary>
    ReadOnly Property ClientVerson() As String
  End Interface
End NameSpace