Namespace Data.Wrappers

  ''' <summary>
  ''' Обертка над IQuery.
  ''' </summary>
  Friend MustInherit Class Query
    Inherits IsbComObjectWrapper
    Implements IQuery

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    Public ReadOnly Property EOF As Boolean Implements IQuery.EOF
      Get
        Return GetRcwProperty("EOF")
      End Get
    End Property

    ''' <summary>
    ''' Количество записей детального раздела.
    ''' </summary>
    Public ReadOnly Property RecordCount As Integer Implements IQuery.RecordCount
      Get
        Return GetRcwProperty("RecordCount")
      End Get
    End Property

    ''' <summary>
    ''' Добавить условие Where к запросу.
    ''' </summary>
    ''' <param name="queryWhereSection">Секция where запроса.</param>
    ''' <returns>ИД условия в запросе.</returns>
    Public Function AddWhere(queryWhereSection As String) As Integer Implements IQuery.AddWhere
      Return InvokeRcwInstanceMethod("AddWhere", queryWhereSection)
    End Function

    ''' <summary>
    ''' Закрыть набор данных.
    ''' </summary>
    Public Sub Close() Implements IQuery.Close
      InvokeRcwInstanceMethod("Close")
    End Sub

    ''' <summary>
    ''' Удалить ограничение из запроса.
    ''' </summary>
    ''' <param name="queryConditionId">ИД условия в запросе.</param>
    Public Sub DelWhere(queryConditionId As Integer) Implements IQuery.DelWhere
      InvokeRcwInstanceMethod("DelWhere", queryConditionId)
    End Sub

    ''' <summary>
    ''' Перейти к первой записи.
    ''' </summary>
    Public Sub First() Implements IQuery.First
      InvokeRcwInstanceMethod("First")
    End Sub

    ''' <summary>
    ''' Перейти к следущей записи.
    ''' </summary>
    Public Sub [Next]() Implements IQuery.[Next]
      InvokeRcwInstanceMethod("Next")
    End Sub

    ''' <summary>
    ''' Перейти к предыдущей записи.
    ''' </summary>
    Public Sub Prior() Implements IQuery.Prior
      Me.InvokeRcwInstanceMethod("Prior")
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIQuery">COM-объект IQuery.</param>
    ''' <param name="scope">Область видимости.</param>
    Protected Sub New(rcwIQuery As Object, scope As IScope)
      MyBase.New(rcwIQuery, scope)
    End Sub
  End Class
End Namespace