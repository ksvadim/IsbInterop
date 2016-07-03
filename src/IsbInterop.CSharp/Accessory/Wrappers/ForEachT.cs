using System;

namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над IForEach с предопределенным типом элементов списка.
  /// </summary>
  internal abstract class ForEachT<T, TI> : IsbComObjectWrapper, IForEach<TI> 
    where T : IsbComObjectWrapper, TI
    where TI : IIsbComObjectWrapper
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
      var rcwCurrentValue = this.GetRcwProperty("Value");
      var itemValue = (T)Activator.CreateInstance(typeof(T), rcwCurrentValue);

      return itemValue;
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
    protected ForEachT(object contentsObject) : base(contentsObject) { }
  }
}
