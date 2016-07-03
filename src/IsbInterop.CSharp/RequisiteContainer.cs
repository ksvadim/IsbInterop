using IsbInterop.Data;
using System;
using System.Collections.Generic;

namespace IsbInterop
{
  /// <summary>
  /// Контейнер реквизитов.
  /// </summary>
  internal class RequisiteContainer : IRequisiteContainer
  {
    /// <summary>
    /// Кэш реквизитов.
    /// </summary>
    private readonly Stack<IRequisite> requisitesCache = new Stack<IRequisite>();

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <param name="getRequisiteCallback">Callback для получения реквизита.</param>
    /// <returns>Реквизит.</returns>
    public IRequisite GetRequisite(string requisiteName, Func<string, IRequisite> getRequisiteCallback)
    {
      var requisite = getRequisiteCallback(requisiteName);
      this.requisitesCache.Push(requisite);

      return requisite;
    }

    /// <summary>
    /// Освободить реквизиты.
    /// </summary>
    public void DisposeRequisites()
    {
      while (requisitesCache.Count > 0)
      {
        var requisite = requisitesCache.Pop();
        try
        {
          requisite.Dispose();
        }
        catch (ObjectDisposedException)
        {
          // Гасим исключение, если объект уже освобожден.
        }
      }

      requisitesCache.Clear();
    }
  }
}
