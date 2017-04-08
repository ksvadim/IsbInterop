namespace IsbInterop.Data.Wrappers
{
  /// <summary>
  /// Обертка над объектом IQuery.
  /// </summary>
  internal abstract class Query : IsbComObjectWrapper, IQuery
  {
    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    public bool EOF
    {
      get { return (bool)this.GetRcwProperty("EOF"); }
    }

    /// <summary>
    /// Количество записей детального раздела.
    /// </summary>
    public int RecordCount
    {
      get { return (int)this.GetRcwProperty("RecordCount"); }
    }

    /// <summary>
    /// Добавить условие Where к запросу.
    /// </summary>
    /// <param name="queryWhereSection">Секция where запроса.</param>
    /// <returns>ИД условия в запросе.</returns>
    public int AddWhere(string queryWhereSection)
    {
      return (int)this.InvokeRcwInstanceMethod("AddWhere", queryWhereSection);
    }

    /// <summary>
    /// Закрыть набор данных.
    /// </summary>
    public void Close()
    {
      this.InvokeRcwInstanceMethod("Close");
    }

    /// <summary>
    /// Удалить ограничение из запроса.
    /// </summary>
    /// <param name="queryConditionId">ИД условия в запросе.</param>
    public void DelWhere(int queryConditionId)
    {
      this.InvokeRcwInstanceMethod("DelWhere", queryConditionId);
    }

    /// <summary>
    /// Перейти к первой записи.
    /// </summary>
    public void First()
    {
      this.InvokeRcwInstanceMethod("First");
    }

    /// <summary>
    /// Перейти к следущей записи.
    /// </summary>
    public void Next()
    {
      this.InvokeRcwInstanceMethod("Next");
    }

    /// <summary>
    /// Перейти к предыдущей записи.
    /// </summary>
    public void Prior()
    {
      this.InvokeRcwInstanceMethod("Prior");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIQuery">COM-объект IQuery.</param>
    /// <param name="scope">Область видимости.</param>
    protected Query(object rcwIQuery, IScope scope) : base(rcwIQuery, scope) { }
  }
}
