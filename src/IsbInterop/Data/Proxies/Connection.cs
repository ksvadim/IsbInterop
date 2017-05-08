using IsbInterop.Accessory;
using IsbInterop.Accessory.Proxies;

namespace IsbInterop.Data.Proxies
{
  /// <summary>
  /// Обертка над IConnection.
  /// </summary>
  internal class Connection : BaseIsbObject, IConnection
  {
    /// <summary>
    /// Получает информацию о системе.
    /// </summary>
    /// <returns>Информация о системе.</returns>
    public ISystemInfo GetSystemInfo()
    {
      var rcwSystemInfo = GetRcwProperty("SystemInfo");
      return new SystemInfo(rcwSystemInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwConnection">СOM-объект IConnection.</param>
    /// <param name="scope">Область видимости.</param>
    internal Connection(object rcwConnection, IScope scope)
      : base(rcwConnection, scope) { }
  }
}
