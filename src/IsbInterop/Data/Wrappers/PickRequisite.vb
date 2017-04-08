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
        Public ReadOnly Property Items As IPickRequisiteItems Implements IPickRequisite.Items
            Get
                Dim rcwItems = Me.GetRcwProperty("Items")
                Return New PickRequisiteItems(rcwItems, Scope)
            End Get
        End Property

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwRequisite">COM-объект реквизит.</param>
        ''' <param name="scope">Область видимости.</param>
        Friend Sub New(rcwRequisite As Object, scope As IScope)
            MyBase.New(rcwRequisite, scope)
        End Sub

    End Class
End Namespace