//using System;

//namespace IsbInterop.Accessory.Wrappers
//{
//  /// <summary>
//  /// Обертка над IList с предопределенным типом элементов списка.
//  /// </summary>
//  internal class ListT<T, TI> : ForEachT<T, TI>, IList<TI>
//    where T : IsbComObjectWrapper, TI
//    where TI : IIsbComObjectWrapper
//  {
//    /// <summary>
//    /// Получить значение элемента списка по индексу.
//    /// </summary>
//    /// <param name="index">Индекс элемента в списке.</param>
//    /// <returns>Значение элемента с указанным индексом.</returns>
//    public TI GetValues(int index)
//    {
//      var rcwitemValue = this.GetRcwProperty("Values", index);
//      var itemValue = (T)Activator.CreateInstance(typeof(T), rcwitemValue);

//      return itemValue;
//    }

//    /// <summary>
//    /// Установить значение элемента.
//    /// </summary>
//    /// <param name="name">Имя элемента.</param>
//    /// <param name="value">Значение элемента.</param>
//    public void SetVar(string name, object value)
//    {
//      var isbObject = value as IUnsafeRcwObjectAccessor;

//      if (isbObject != null)
//        this.InvokeRcwInstanceMethod("SetVar", new object[] { name, isbObject.UnsafeRcwObject });
//      else
//        this.InvokeRcwInstanceMethod("SetVar", new object[] { name, value });
//    }

//    /// <summary>
//    /// Конструктор.
//    /// </summary>
//    /// <param name="rcwIList">COM-объект IList.</param>
//    public ListT(object rcwIList) : base(rcwIList)
//    {
//    }
//  }
//}
