using IsbInterop.Accessory;

namespace IsbInterop.Data
{
  /// <summary>
  /// Соединение.
  /// </summary>
  public interface IConnection : IIsbComObjectWrapper
  {
    /// <summary>
    /// Информация о системе.
    /// </summary>
    ISystemInfo SystemInfo { get; }
  }
}
