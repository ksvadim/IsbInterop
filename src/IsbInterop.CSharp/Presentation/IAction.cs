using System;

namespace IsbInterop.Presentation
{
  /// <summary>
  /// Действие формы.
  /// </summary>
  public interface IAction : IIsbComObjectWrapper
  {
    /// <summary>
    /// Выполнить действие.
    /// </summary>
    /// <returns>True, если действие было выполнено, иначе false.</returns>
    bool Execute();

    /// <summary>
    /// Выполнить действие.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>True, если действие было выполнено, иначе false.</returns>
    bool Execute(TimeSpan timeout);
  }
}
