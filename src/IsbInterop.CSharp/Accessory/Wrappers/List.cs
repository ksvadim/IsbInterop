namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над IList.
  /// </summary>
  internal class List<TI> : ForEach<TI>, IList<TI>
    where TI : IIsbComObjectWrapper
  {
    /// <summary>
    /// Получить значение элемента списка по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента в списке.</param>
    /// <returns>Значение элемента с указанным индексом.</returns>
    public virtual TI GetValues(int index)
    {
      var rcwObject = this.GetRcwProperty("Values", index);
      return IsbObjectResolver.Resolve<TI>(rcwObject);
    }

    /// <summary>
    /// Установить значение элемента.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    public void SetVar(string name, object value)
    {
      var isbObject = value as IUnsafeRcwObjectAccessor;

      if (isbObject != null)
        this.InvokeRcwInstanceMethod("SetVar", new object[] { name, isbObject.UnsafeRcwObject });
      else
        this.InvokeRcwInstanceMethod("SetVar", new object[] { name, value });
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIList">COM-объект IList.</param>
    public List(object rcwIList) : base(rcwIList) { }
  }
}
