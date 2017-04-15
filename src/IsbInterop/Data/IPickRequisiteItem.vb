Namespace Data

  ''' <summary>
  ''' Описание допустимого значения реквизита типа «Признак».
  ''' </summary>
  Public Interface IPickRequisiteItem
    Inherits IBaseIsbObject

    ''' <summary>
    ''' Внутренний ИД допустимого значения реквизита, хранящийся в базе данных.
    ''' </summary>
    ReadOnly Property Id As Integer
  End Interface
End NameSpace