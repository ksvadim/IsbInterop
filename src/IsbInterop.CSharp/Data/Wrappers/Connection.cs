﻿using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;

namespace IsbInterop.Data.Wrappers
{
  /// <summary>
  /// Обертка над IConnection.
  /// </summary>
  internal class Connection : IsbComObjectWrapper, IConnection
  {
    /// <summary>
    /// Получить информацию о системе.
    /// </summary>
    /// <returns>Информация о системе.</returns>
    public ISystemInfo GetSystemInfo()
    {
      var rcwSystemInfo = this.GetRcwProperty("SystemInfo");
      return new SystemInfo(rcwSystemInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwConnection">СOM-объект IConnection.</param>
    /// <param name="scope">Область видимости.</param>
    internal Connection(object rcwConnection, IScope scope) : base(rcwConnection, scope) { }
  }
}
