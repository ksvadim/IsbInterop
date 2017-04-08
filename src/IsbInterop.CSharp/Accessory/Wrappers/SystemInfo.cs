﻿namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над ISystemInfo.
  /// </summary>
  internal class SystemInfo : IsbComObjectWrapper, ISystemInfo
  {
    /// <summary>
    /// Версия клиента.
    /// </summary>
    public string ClientVerson
    {
      get { return (string)this.GetRcwProperty("ClientVersion"); }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="systemInfo">Объект с информацией о системе.</param>
    /// <param name="scope">Область видимости.</param>
    internal SystemInfo(object systemInfo, IScope scope) : base(systemInfo, scope) { }
  }
}
