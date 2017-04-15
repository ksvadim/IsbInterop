Namespace Base.Proxies

    ''' <summary>
    ''' Обертка над IObjectInfo.
    ''' </summary>
    Friend Class ObjectInfo
        Inherits BaseIsbObject
        Implements IObjectInfo

        ''' <summary>
        ''' ИД объекта.
        ''' </summary>
        Public ReadOnly Property Id As Integer Implements IObjectInfo.Id
            Get
                Return GetRcwProperty("ID")
            End Get
        End Property

        ''' <summary>
        ''' Имя объекта.
        ''' </summary>
        Public ReadOnly Property Name As String Implements IObjectInfo.Name
            Get
                Return DirectCast(GetRcwProperty("Name"), String)
            End Get
        End Property

        ' Для Autofac конструктор должен быть объявлен как public.
        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwObjectInfo">COM-объект ObjectInfo.</param>
        ''' <param name="scope">Область видимости.</param>
        Public Sub New(rcwObjectInfo As Object, scope As IScope)
            MyBase.New(rcwObjectInfo, scope)
        End Sub
    End Class
End Namespace