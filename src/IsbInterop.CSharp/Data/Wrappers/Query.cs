namespace IsbInterop.Data.Wrappers
{
  /// <summary>
  /// Обертка над объектом IQuery.
  /// </summary>
  internal abstract class Query : BaseIsbObject, IQuery
  {
    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    public bool EOF => (bool)GetRcwProperty("EOF");

    /// <summary>
    /// Количество записей детального раздела.
    /// </summary>
    public int RecordCount => (int)GetRcwProperty("RecordCount");

    /// <summary>
    /// Добавляет условие ограничения набора данных.
    /// </summary>
    /// <param name="condition">Условие ограничения выборки.</param>
    /// <returns>ИД условия в запросе.</returns>
    public int AddWhere(string condition)
    {
      return (int)InvokeRcwInstanceMethod("AddWhere", condition);
    }

    /// <summary>
    /// Закрывает набор данных.
    /// </summary>
    public void Close()
    {
      InvokeRcwInstanceMethod("Close");
    }

    /// <summary>
    /// Удаляет условие ограничения набора данных.
    /// </summary>
    /// <param name="сonditionId">ИД условия в запросе.</param>
    public void DelWhere(int сonditionId)
    {
      InvokeRcwInstanceMethod("DelWhere", сonditionId);
    }

    /// <summary>
    /// Перехоидт к первой записи.
    /// </summary>
    public void First()
    {
      InvokeRcwInstanceMethod("First");
    }

    /// <summary>
    /// Переходит к следущей записи.
    /// </summary>
    public void Next()
    {
      InvokeRcwInstanceMethod("Next");
    }

    /// <summary>
    /// Переходит к предыдущей записи.
    /// </summary>
    public void Prior()
    {
      InvokeRcwInstanceMethod("Prior");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIQuery">COM-объект IQuery.</param>
    /// <param name="scope">Область видимости.</param>
    protected Query(object rcwIQuery, IScope scope) : base(rcwIQuery, scope) { }
  }
}
