using IsbInterop.System;

namespace IsbInterop.Data
{
  /// <summary>
  /// Соединение.
  /// </summary>
  public interface IConnection : IBaseIsbObject
  {
    /// <summary>
    /// Получает информацию о системе.
    /// </summary>
    /// <returns>Информация о системе.</returns>
    ISystemInfo GetSystemInfo();
  }
}
