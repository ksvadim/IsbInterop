using IsbInterop.Accessory;
using IsbInterop.Base;
using System;

namespace IsbInterop.Scripts
{
  /// <summary>
  /// Сценарий.
  /// </summary>
  public interface IScript : IObject<IObjectInfo>
  {
    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <returns>Результат.</returns>
    IIsbComObjectWrapper Execute();

    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    IIsbComObjectWrapper Execute(TimeSpan timeout);

    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    T Execute<T>() where T : IIsbComObjectWrapper;

    /// <summary>
    /// Выполнить скрипт.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    T Execute<T>(TimeSpan timeout) where T : IIsbComObjectWrapper;

    /// <summary>
    /// Получить параметры.
    /// </summary>
    /// <returns>IsbObjectList.</returns>
    IList<IIsbComObjectWrapper> GetParams();
  }
}
