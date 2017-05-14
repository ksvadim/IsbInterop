using IsbInterop.Base;

namespace IsbInterop.Collections
{
  /// <summary>
  /// Содержимое.
  /// </summary>
  public interface IContents<out TI> : IForEach<TI> where TI : IObjectInfo
  {
  }
}
