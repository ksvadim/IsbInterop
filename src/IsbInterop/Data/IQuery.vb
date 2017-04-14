Namespace Data

  ''' <summary>
  ''' Запрос.
  ''' </summary>
  Public Interface IQuery

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    ReadOnly Property EOF As Boolean

    ''' <summary>
    ''' Количество записей в наборе данных.
    ''' </summary>
    ReadOnly Property RecordCount As Integer

    ''' <summary>
    ''' Добавляет условие ограничения набора данных.
    ''' </summary>
    ''' <param name="condition">Условие ограничения выборки.</param>
    ''' <returns>ИД условия в запросе.</returns>
    Function AddWhere(condition As String) As Integer

    ''' <summary>
    ''' Закрывает набор данных.
    ''' </summary>
    Sub Close()

    ''' <summary>
    ''' Удаляет условие ограничения набора данных.
    ''' </summary>
    ''' <param name="сonditionId">ИД условия в запросе.</param>
    Sub DelWhere(сonditionId As Integer)

    ''' <summary>
    ''' Переходит к первой записи.
    ''' </summary>
    Sub First()

    ''' <summary>
    ''' Переходит к следущей записи.
    ''' </summary>
    Sub [Next]()

    ''' <summary>
    ''' Переходит к предыдущей записи.
    ''' </summary>
    Sub Prior()
  End Interface
End NameSpace