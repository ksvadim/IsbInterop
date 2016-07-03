using IsbInterop.Accessory;

namespace IsbInterop.Data
{
  /// <summary>
  /// Соединение.
  /// </summary>
  public interface IConnection : IIsbComObjectWrapper
  {
    /// <summary>
    /// Получить информацию о системе.
    /// </summary>
    /// <returns>Информация о системе.</returns>
    ISystemInfo GetSystemInfo();
  }
}
