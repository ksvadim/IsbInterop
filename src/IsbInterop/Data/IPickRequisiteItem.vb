Namespace Data
  ''' <summary>
  ''' Описание допустимого значения реквизита типа «Признак».
  ''' </summary>
  Public Interface IPickRequisiteItem
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Внутренний идентификатор допустимого значения реквизита, хранящийся в базе данных.
    ''' </summary>
    ReadOnly Property Id() As Integer

  End Interface
End NameSpace