Namespace DataTypes.Enumerable
  ''' <summary>
  ''' Тип реквизита.
  ''' </summary>
  Public Enum TReqDataType
    ''' <summary>
    ''' Тип данны "Строка".
    ''' </summary>
    rdtString = 0

    ''' <summary>
    ''' Тип данных «Дробное число».
    ''' </summary>
    rdtNumeric = 1

    ''' <summary>
    ''' Тип данных «Целое число».
    ''' </summary>
    rdtInteger = 2

    ''' <summary>
    ''' Тип данных «Дата».
    ''' </summary>
    rdtDate = 3

    ''' <summary>
    ''' Тип данных «Справочник».
    ''' </summary>
    rdtReference = 4

    ''' <summary>
    ''' ???
    ''' </summary>
    rdtAccount = 5

    ''' <summary>
    ''' Тип данных «Текст».
    ''' </summary>
    rdtText = 6

    ''' <summary>
    ''' Тип данных «Признак».
    ''' </summary>
    rdtPick = 7

    ''' <summary>
    ''' Неизвестный тип данных.
    ''' </summary>
    rdtUnknown = 8
  End Enum
End NameSpace