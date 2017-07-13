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
    /// Добавляет условие ограничения набора данных.
    /// </summary>
    /// <param name="condition">Условие ограничения выборки.</param>
    /// <returns>ИД условия в запросе.</returns>
    int AddWhere(string condition);

    /// <summary>
    /// Закрывает набор данных.
    /// </summary>
    void Close();

    /// <summary>
    /// Удаляет условие ограничения набора данных.
    /// </summary>
    /// <param name="сonditionId">ИД условия в запросе.</param>
    void DelWhere(int сonditionId);

    /// <summary>
    /// Переходит к первой записи.
    /// </summary>
    void First();

    /// <summary>
    /// Переходит к следущей записи.
    /// </summary>
    void Next();

    /// <summary>
    /// Переходит к предыдущей записи.
    /// </summary>
    void Prior();
  }
}
