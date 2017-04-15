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
    ''' Добавляет условие ограничения набора данных.
    ''' </summary>
    ''' <param name="condition">Условие ограничения выборки.</param>
    ''' <returns>ИД условия в запросе.</returns>
    Public Function AddWhere(condition As String) As Integer Implements IQuery.AddWhere
      Return InvokeRcwInstanceMethod("AddWhere", condition)
    End Function

    ''' <summary>
    ''' Закрывает набор данных.
    ''' </summary>
    Public Sub Close() Implements IQuery.Close
      InvokeRcwInstanceMethod("Close")
    End Sub

    ''' <summary>
    ''' Удаляет условие ограничения набора данных.
    ''' </summary>
    ''' <param name="сonditionId">ИД условия в запросе.</param>
    Public Sub DelWhere(сonditionId As Integer) Implements IQuery.DelWhere
      InvokeRcwInstanceMethod("DelWhere", сonditionId)
    End Sub

    ''' <summary>
    ''' Переходит к первой записи.
    ''' </summary>
    Public Sub First() Implements IQuery.First
      InvokeRcwInstanceMethod("First")
    End Sub

    ''' <summary>
    ''' Переходит к следущей записи.
    ''' </summary>
    Public Sub [Next]() Implements IQuery.[Next]
      InvokeRcwInstanceMethod("Next")
    End Sub

    ''' <summary>
    ''' Переходит к предыдущей записи.
    ''' </summary>
    Public Sub Prior() Implements IQuery.Prior
      InvokeRcwInstanceMethod("Prior")
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