namespace IsbInterop.Accessory
{
  /// <summary>
  /// Список.
  /// </summary>
  public interface IList<out T> : IForEach<T> where T: IIsbComObjectWrapper
  {
    /// <summary>
    /// Получить значение элемента списка по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента в списке.</param>
    /// <returns>Значение элемента с указанным индексом.</returns>
    T GetValues(int index);

    /// <summary>
    /// Установить значение элемента.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void SetVar(string name, object value);
  }
}
