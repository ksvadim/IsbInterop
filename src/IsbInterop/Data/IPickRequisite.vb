Namespace Data

  ''' <summary>
  ''' Реквизит типа «Признак».
  ''' </summary>
  Public Interface IPickRequisite
    Inherits IRequisite

    ''' <summary>
    ''' Cписок описаний допустимых значений реквизита.
    ''' </summary>
    ReadOnly Property Items As IPickRequisiteItems
  End Interface
End NameSpace