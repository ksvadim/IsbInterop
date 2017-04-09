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
    /// Добавляет элемент в список.
    /// </summary>
    /// <typeparam name="TP">Тип параметра.</typeparam>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    public void Add<TP>(string name, TP value) where TP : IIsbComObjectWrapper
    {
      if (value is TI)
        InvokeRcwInstanceMethod("Add", new [] { name, ((IUnsafeRcwHolder)value).RcwObject });
      else
        throw new InvalidOperationException($"Cannot convert value to {typeof(TI)}");
    }

    /// <summary>
    /// Добавляет элемент в список.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    public void Add(string name, object value)
    {
      this.InvokeRcwInstanceMethod("Add", new [] { name, value });
    }

    /// <summary>
    /// Получает значение элемента списка по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента в списке.</param>
    /// <returns>Значение элемента с указанным индексом.</returns>
    public TI GetValues(int index)
    {
      var rcwObject = GetRcwProperty("Values", index);
      return IsbObjectResolver.Resolve<TI>(rcwObject, Scope);
    }

    /// <summary>
    /// Получает значение элемента по имени.
    /// </summary>
    /// <param name="name">Имя искомого элемента.</param>
    /// <returns>Значение искомого элемента.</returns>
    public TI ValueByName(string name)
    {
      var rcwObject = InvokeRcwInstanceMethod("ValueByName", new object[] { name });
      var value = IsbObjectResolver.Resolve<TI>(rcwObject, Scope);

      return value;
    }

    /// <summary>
    /// Установливает значение элемента.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    public void SetVar(string name, object value)
    {
      var isbObject = value as IUnsafeRcwHolder;

      if (isbObject != null)
        InvokeRcwInstanceMethod("SetVar", new [] { name, isbObject.RcwObject });
      else
        InvokeRcwInstanceMethod("SetVar", new [] { name, value });
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIList">COM-объект IList.</param>
    /// <param name="scope">Область видимости.</param>
    public List(object rcwIList, IScope scope) : base(rcwIList, scope) { }
  }
}
