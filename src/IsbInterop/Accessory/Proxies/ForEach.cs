namespace IsbInterop.Accessory.Proxies
{
  /// <summary>
  /// Обертка над IForEach.
  /// </summary>
  internal abstract class ForEach<TI> : BaseIsbObject, IForEach<TI> where TI : IBaseIsbObject
  {
    /// <summary>
    /// Количество элементов в списке.
    /// </summary>
    public int Count => (int)GetRcwProperty("Count");

    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    public bool EOF => (bool)GetRcwProperty("EOF");

    /// <summary>
    /// Получает значение текущего элемента списка.
    /// </summary>
    /// <returns>Значение текущего элемента списка.</returns>
    public TI GetValue()
    {
      var rcwObject = GetRcwProperty("Value");
      var value = IsbObjectResolver.Resolve<TI>(rcwObject, Scope);

      return value;
    }

    /// <summary>
    /// Перейти к следующему объекту набора данных.
    /// </summary>
    public void Next()
    {
      InvokeRcwInstanceMethod("Next");
    }

    /// <summary>
    /// Устанавливить указатель текущего элемента списка на первый элемент списка.
    /// </summary>
    public void Reset()
    {
      InvokeRcwInstanceMethod("Reset");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="contentsObject">Объект IContents.</param>
    /// <param name="scope">Область видимости.</param>
    protected ForEach(object contentsObject, IScope scope) : base(contentsObject, scope) { }
  }
}
