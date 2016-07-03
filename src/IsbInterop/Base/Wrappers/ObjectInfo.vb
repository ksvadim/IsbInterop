Namespace Base.Wrappers
    ''' <summary>
    ''' Обертка над IObjectInfo.
    ''' </summary>
    Friend Class ObjectInfo
        Inherits IsbComObjectWrapper
        Implements IObjectInfo

        ''' <summary>
        ''' ИД объекта.
        ''' </summary>
        Public ReadOnly Property Id() As Integer Implements IObjectInfo.Id
            Get
                Return CInt(Me.GetRcwProperty("ID"))
            End Get
        End Property

        ''' <summary>
        ''' Имя объекта.
        ''' </summary>
        Public ReadOnly Property Name() As String Implements IObjectInfo.Name
            Get
                Return DirectCast(Me.GetRcwProperty("Name"), String)
            End Get
        End Property

        ' Для Autofac конструктор должен быть объявлен как public.
        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwObjectInfo">COM-объект ObjectInfo.</param>
        Public Sub New(rcwObjectInfo As Object)
            MyBase.New(rcwObjectInfo)
        End Sub
    End Class
End Namespace