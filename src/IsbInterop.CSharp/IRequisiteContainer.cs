using IsbInterop.Data;
using System;

namespace IsbInterop
{
  /// <summary>
  /// Интерфейс контейнера реквизитов.
  /// </summary>
  internal interface IRequisiteContainer
  {
    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <param name="getRequisiteCallback">Callback для получения реквизита.</param>
    /// <returns>Реквизит.</returns>
    IRequisite GetRequisite(string requisiteName, Func<string, IRequisite> getRequisiteCallback);

    /// <summary>
    /// Освободить реквизиты.
    /// </summary>
    void DisposeRequisites();
  }
}
