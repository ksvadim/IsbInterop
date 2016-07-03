namespace IsbInterop.Accessory
{
  /// <summary>
  /// Однонаправленный список.
  /// </summary>
  public interface IForEach<out T> : IIsbComObjectWrapper where T : IIsbComObjectWrapper
  {
    /// <summary>
    /// Количество элементов в списке.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    bool EOF { get; }

    ///// <summary>
    ///// Получить значение текущего элемента списка.
    ///// </summary>
    ///// <returns>Значение текущего элемента списка.</returns>
    T GetValue();

    /// <summary>
    /// Перейти к следующему объекту набора данных.
    /// </summary>
    void Next();

    /// <summary>
    /// Установить указатель текущего элемента списка на первый элемент списка.
    /// </summary>
    void Reset();
  }
}
