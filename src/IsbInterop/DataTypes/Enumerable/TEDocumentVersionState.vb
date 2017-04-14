Namespace DataTypes.Enumerable

  ''' <summary>
  ''' Состояние версии электронного документа.
  ''' </summary>
  Public Enum TEDocumentVersionState
    ''' <summary>
    ''' Состояние по умолчанию, указанное в карточке вида электронного документа на закладке «Жизненный цикл».
    ''' </summary>
    vsDefault = 0

    ''' <summary>
    ''' Разрабатываемая версия.
    ''' </summary>
    vsDesign = 1

    ''' <summary>
    ''' Действующая версия.
    ''' </summary>
    vsActive = 2

    ''' <summary>
    ''' Устаревшая версия.
    ''' </summary>
    vsObsolete = 3

    ''' <summary>
    ''' Неизвестное состояние версии.
    ''' </summary>
    vsUnknown = -1
  End Enum
End NameSpace