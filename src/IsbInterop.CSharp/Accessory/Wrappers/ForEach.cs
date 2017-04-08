namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над IForEach.
  /// </summary>
  internal abstract class ForEach<TI> : IsbComObjectWrapper, IForEach<TI> where TI : IIsbComObjectWrapper
  {
    /// <summary>
    /// Количество элементов в списке.
    /// </summary>
    public int Count
    {
      get { return (int)this.GetRcwProperty("Count"); }
    }

    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    public bool EOF
    {
      get { return (bool)this.GetRcwProperty("EOF"); }
    }

    /// <summary>
    /// Получить объект набора данных.
    /// </summary>
    /// <returns>Реквизит.</returns>
    public TI GetValue()
    {
      var rcwObject = this.GetRcwProperty("Value");
      var value = IsbObjectResolver.Resolve<TI>(rcwObject, Scope);

      return value;
    }

    /// <summary>
    /// Перейти к следующему объекту набора данных.
    /// </summary>
    public void Next()
    {
      this.InvokeRcwInstanceMethod("Next");
    }

    /// <summary>
    /// Устанавливить указатель текущего элемента списка на первый элемент списка.
    /// </summary>
    public void Reset()
    {
      this.InvokeRcwInstanceMethod("Reset");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="contentsObject">Объект IContents.</param>
    /// <param name="scope">Область видимости.</param>
    protected ForEach(object contentsObject, IScope scope) : base(contentsObject, scope) { }
  }
}
