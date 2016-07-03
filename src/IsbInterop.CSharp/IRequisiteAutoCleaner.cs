using System;
using IsbInterop.Data;

namespace IsbInterop
{
  /// <summary>
  /// Интерфейс объекта, поддерживающего автоматичесую очистку реквизитов.
  /// </summary>
  internal interface IRequisiteAutoCleaner : IDisposable
  {
    /// <summary>
    /// Контейнер реквизитов.
    /// </summary>
    IRequisiteContainer RequisiteContainer { get; }

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <remarks>Внимание! Этот метод должен вызывать методы RequisiteContainer
    /// для получения реквизитов.</remarks>
    IRequisite GetRequisite(string requisiteName);
  }
}
