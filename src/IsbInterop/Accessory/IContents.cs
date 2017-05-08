using IsbInterop.Base;

namespace IsbInterop.Accessory
{
  /// <summary>
  /// Содержимое.
  /// </summary>
  public interface IContents<out TI> : IForEach<TI> where TI : IObjectInfo
  {
  }
}
