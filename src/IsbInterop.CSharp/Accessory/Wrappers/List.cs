using System;

namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над IList.
  /// </summary>
  internal class List<TI> : ForEach<TI>, IList<TI>
    where TI : IIsbComObjectWrapper
  {
    /// <summary>
    /// Добавить элемент.
    /// </summary>
    /// <typeparam name="TP">Тип параметра.</typeparam>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    public void Add<TP>(string name, TP value) where TP : IIsbComObjectWrapper
    {
      if (value is TI)
        this.InvokeRcwInstanceMethod("Add", new object[] { name, ((IUnsafeRcwObjectAccessor)value).UnsafeRcwObject });
      else
        throw new InvalidOperationException(string.Format("Cannot convert value to {0}", typeof(TI)));
    }

    /// <summary>
    /// Добавить элемент.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    public void Add(string name, object value)
    {
      this.InvokeRcwInstanceMethod("Add", new object[] { name, value });
    }

    /// <summary>
    /// Получить значение элемента списка по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента в списке.</param>
    /// <returns>Значение элемента с указанным индексом.</returns>
    public virtual TI GetValues(int index)
    {
      var rcwObject = this.GetRcwProperty("Values", index);
      return IsbObjectResolver.Resolve<TI>(rcwObject, Scope);
    }

    /// <summary>
    /// Получить значение по имени.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Имя искомого элемента.</returns>
    public TI GetValueByName(string name)
    {
      var rcwObject = this.InvokeRcwInstanceMethod("ValueByName", new object[] { name });
      var value = IsbObjectResolver.Resolve<TI>(rcwObject, Scope);

      return value;
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
    /// <param name="scope">Область видимости.</param>
    public List(object rcwIList, IScope scope) : base(rcwIList, scope) { }
  }
}
