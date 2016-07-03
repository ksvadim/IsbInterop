''' <summary>
''' Фатальное исключение.
''' </summary>
Public Class FatalIsbInteropException
    Inherits Exception
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="message">Сообщение.</param>
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="message">Сообщение.</param>
    ''' <param name="innerException">Внутреннее исключение.</param>
    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
End Class
