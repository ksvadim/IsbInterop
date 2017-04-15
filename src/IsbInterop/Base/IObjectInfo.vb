Namespace Base
  ''' <summary>
  ''' Информация об объекте.
  ''' </summary>
  Public Interface IObjectInfo
    Inherits IBaseIsbObject
    ''' <summary>
    ''' ИД документа.
    ''' </summary>
    ReadOnly Property Id() As Integer

    ''' <summary>
    ''' Имя документа.
    ''' </summary>
    ReadOnly Property Name() As String
  End Interface
End NameSpace