using IsbInterop.Base;

namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над IContents.
  /// </summary>
  internal class Contents<TI> : ForEach<TI>, IContents<TI> where TI : IObjectInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="contentsObject">Объект IContents.</param>
    public Contents(object contentsObject) : base(contentsObject) { }
  }
}
