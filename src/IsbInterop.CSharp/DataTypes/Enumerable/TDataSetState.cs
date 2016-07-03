namespace IsbInterop.DataTypes.Enumerable
{
  /// <summary>
  /// Состояние детального раздела.
  /// </summary>
  public enum TDataSetState
  {
    /// <summary>
    /// Режим редактирования.
    /// </summary>
    dssEdit = 0,

    /// <summary>
    /// Режим вставки.
    /// </summary>
    dssInsert = 1,

    /// <summary>
    /// Режим просмотра.
    /// </summary>
    dssBrowse = 2,

    /// <summary>
    /// Режим неактивного набора данных.
    /// </summary>
    dssInActive = 3,
  }
}
