Imports IsbInterop.Accessory.Wrappers

Namespace Data.Wrappers
    ''' <summary>
    ''' Обертка над IPickRequisiteItems.
    ''' </summary>
    Friend Class PickRequisiteItems
        Inherits ForEach(Of IPickRequisiteItem)
        Implements IPickRequisiteItems

        ''' <summary>
        ''' Получить ИД по значению.
        ''' </summary>
        ''' <param name="namedValue">Допустимое значение реквизита.</param>
        ''' <returns>ИД допустимого значения реквизита типа «Признак» – 
        ''' внутреннее значение реквизита, хранящееся на сервере.</returns>
        Public Function IdByValue(namedValue As String) As String Implements IPickRequisiteItems.IdByValue
            Return DirectCast(Me.InvokeRcwInstanceMethod("IdByValue", namedValue), String)
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwIPickRequisiteItems">COM-объект IPickRequisiteItems.</param>
        Friend Sub New(rcwIPickRequisiteItems As Object)
            MyBase.New(rcwIPickRequisiteItems)
        End Sub
    End Class
End Namespace