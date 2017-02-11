namespace IsbInterop.Accessory
{
  /// <summary>
  /// Список.
  /// </summary>
  public interface IList<out T> : IForEach<T> where T : IIsbComObjectWrapper
  {
    /// <summary>
    /// Добавить элемент.
    /// </summary>
    /// <typeparam name="TP">Тип параметра.</typeparam>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void Add<TP>(string name, TP value) where TP : IIsbComObjectWrapper;

    /// <summary>
    /// Добавить элемент.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void Add(string name, object value);

    /// <summary>
    /// Получить значение элемента списка по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента в списке.</param>
    /// <returns>Значение элемента с указанным индексом.</returns>
    T GetValues(int index);

    /// <summary>
    /// Получить значение по имени.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Имя искомого элемента.</returns>
    T GetValueByName(string name);

    /// <summary>
    /// Установить значение элемента.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void SetVar(string name, object value);
  }
}
