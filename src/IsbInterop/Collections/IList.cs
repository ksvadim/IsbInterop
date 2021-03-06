﻿namespace IsbInterop.Collections
{
  /// <summary>
  /// Список.
  /// </summary>
  public interface IList<out T> : IForEach<T> where T : IBaseIsbObject
  {
    /// <summary>
    /// Добавляет элемент в список.
    /// </summary>
    /// <typeparam name="TP">Тип параметра.</typeparam>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void Add<TP>(string name, TP value) where TP : IBaseIsbObject;

    /// <summary>
    /// Добавляет элемент в список.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void Add(string name, object value);

    /// <summary>
    /// Получает значение элемента по имени.
    /// </summary>
    /// <param name="name">Имя искомого элемента.</param>
    /// <returns>Значение искомого элемента.</returns>
    T GetValueByName(string name);

    /// <summary>
    /// Получает значение элемента по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента в списке.</param>
    /// <returns>Значение элемента с указанным индексом.</returns>
    T GetValues(int index);

    /// <summary>
    /// Устанавливает значение элемента.
    /// </summary>
    /// <param name="name">Имя элемента.</param>
    /// <param name="value">Значение элемента.</param>
    void SetVar(string name, object value);
  }
}
