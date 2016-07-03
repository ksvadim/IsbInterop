Namespace Data
  ''' <summary>
  ''' Запрос.
  ''' </summary>
  Public Interface IQuery

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    ReadOnly Property EOF() As Boolean

    ''' <summary>
    ''' Количество записей в наборе данных.
    ''' </summary>
    ReadOnly Property RecordCount() As Integer

    ''' <summary>
    ''' Добавить условие Where к запросу.
    ''' </summary>
    ''' <param name="queryWhereSection">Секция where запроса.</param>
    ''' <returns>ИД условия в запросе.</returns>
    Function AddWhere(queryWhereSection As String) As Integer

    ''' <summary>
    ''' Закрыть набор данных.
    ''' </summary>
    Sub Close()

    ''' <summary>
    ''' Удалить ограничение из запроса.
    ''' </summary>
    ''' <param name="queryConditionId">ИД условия в запросе.</param>
    Sub DelWhere(queryConditionId As Integer)

    ''' <summary>
    ''' Перейти к первой записи.
    ''' </summary>
    Sub First()

    ''' <summary>
    ''' Перейти к следущей записи.
    ''' </summary>
    Sub [Next]()

    ''' <summary>
    ''' Перейти к предыдущей записи.
    ''' </summary>
    Sub Prior()
  End Interface
End NameSpace