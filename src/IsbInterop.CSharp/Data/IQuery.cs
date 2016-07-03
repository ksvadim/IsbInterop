namespace IsbInterop.Data
{
  /// <summary>
  /// Запрос.
  /// </summary>
  public interface IQuery
  {
    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    bool EOF { get; }

    /// <summary>
    /// Количество записей в наборе данных.
    /// </summary>
    int RecordCount { get; }

    /// <summary>
    /// Добавить условие Where к запросу.
    /// </summary>
    /// <param name="queryWhereSection">Секция where запроса.</param>
    /// <returns>ИД условия в запросе.</returns>
    int AddWhere(string queryWhereSection);

    /// <summary>
    /// Закрыть набор данных.
    /// </summary>
    void Close();

    /// <summary>
    /// Удалить ограничение из запроса.
    /// </summary>
    /// <param name="queryConditionId">ИД условия в запросе.</param>
    void DelWhere(int queryConditionId);

    /// <summary>
    /// Перейти к первой записи.
    /// </summary>
    void First();

    /// <summary>
    /// Перейти к следущей записи.
    /// </summary>
    void Next();

    /// <summary>
    /// Перейти к предыдущей записи.
    /// </summary>
    void Prior();
  }
}
