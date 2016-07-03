namespace IsbInterop.Accessory
{
  /// <summary>
  /// Информация о системе.
  /// </summary>
  public interface ISystemInfo : IIsbComObjectWrapper
  {
    /// <summary>
    /// Версия клиента.
    /// </summary>
    string ClientVerson { get; }
  }
}
