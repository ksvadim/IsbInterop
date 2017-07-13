using IsbInterop.Base;

namespace IsbInterop.Collections.Proxies
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
    /// <param name="scope">Область видимости.</param>
    public Contents(object contentsObject, IScope scope) : base(contentsObject, scope) { }
  }
}
