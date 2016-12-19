''' <summary>
''' Базовая обертка над объектом IS-Builder.
''' </summary>
Friend Class BaseIsbObjectWrapper
    Inherits IsbComObjectWrapper

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    Public Sub New(rcwObject As Object)
        MyBase.New(rcwObject)
    End Sub
End Class