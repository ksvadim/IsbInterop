''' <summary>
''' Пустой объект.
''' </summary>
Friend Class EmptyIsbObject
    Inherits IsbComObjectWrapper

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    Public Sub New(rcwObject As Object)
        MyBase.New(rcwObject)
    End Sub
End Class