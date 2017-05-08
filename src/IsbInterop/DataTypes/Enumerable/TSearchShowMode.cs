namespace IsbInterop.DataTypes.Enumerable
{
  /// <summary>
  /// Режим отображения результатов поиска.
  /// </summary>
  public enum TSearchShowMode
  {
    /// <summary>
    /// Просмотр результатов поиска.
    /// </summary>
    ssmBrowse = 0,

    /// <summary>
    /// Выбор одного объекта из результатов поиска.
    /// </summary>
    ssmSelect = 1,

    /// <summary>
    /// Выбор нескольких объектов из результатов поиска.
    /// </summary>
    ssmMultiSelect = 2
  }
}
