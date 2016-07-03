Namespace Data.Wrappers
    ''' <summary>
    ''' Обертка над IRequisite.
    ''' </summary>
    Friend Class PickRequisite
        Inherits Requisite
        Implements IPickRequisite

        ''' <summary>
        ''' Список описаний допустимых значений реквизита.
        ''' </summary>
        Public ReadOnly Property Items() As IPickRequisiteItems Implements IPickRequisite.Items
            Get
                Dim rcwItems = Me.GetRcwProperty("Items")
                Return New PickRequisiteItems(rcwItems)
            End Get
        End Property

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwRequisite">COM-объект реквизит.</param>
        Friend Sub New(rcwRequisite As Object)
            MyBase.New(rcwRequisite)
        End Sub

    End Class
End Namespace