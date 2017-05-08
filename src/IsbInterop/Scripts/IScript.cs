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
    /// Выполняет скрипт.
    /// </summary>
    /// <returns>Результат.</returns>
    IBaseIsbObject Execute();

    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    IBaseIsbObject Execute(TimeSpan timeout);

    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    T Execute<T>() where T : IBaseIsbObject;

    /// <summary>
    /// Выполняет скрипт.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    /// <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    T Execute<T>(TimeSpan timeout) where T : IBaseIsbObject;

    /// <summary>
    /// Получает параметры.
    /// </summary>
    /// <returns>IsbObjectList.</returns>
    IList<IBaseIsbObject> GetParams();
  }
}
