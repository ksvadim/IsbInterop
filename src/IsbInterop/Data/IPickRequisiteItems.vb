Imports IsbInterop.Accessory

Namespace Data
  ''' <summary>
  ''' Список описаний допустимых значений реквизита типа «Признак».
  ''' </summary>
  Public Interface IPickRequisiteItems
    Inherits IForEach(Of IPickRequisiteItem)

    ''' <summary>
    ''' Получить ИД по значению.
    ''' </summary>
    ''' <param name="namedValue">Допустимое значение реквизита.</param>
    ''' <returns>ИД допустимого значения реквизита типа «Признак» – 
    ''' внутреннее значение реквизита, хранящееся на сервере.</returns>
    Function IdByValue(namedValue As String) As String
  End Interface
End NameSpace