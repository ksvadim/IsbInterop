namespace IsbInterop.Accessory
{
  /// <summary>
  /// Информация о системе.
  /// </summary>
  public interface ISystemInfo : IBaseIsbObject
  {
    /// <summary>
    /// Версия клиента.
    /// </summary>
    string ClientVerson { get; }
  }
}
