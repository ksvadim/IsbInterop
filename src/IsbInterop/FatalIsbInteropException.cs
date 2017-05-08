using System;

namespace IsbInterop
{
  /// <summary>
  /// Фатальное исключение.
  /// </summary>
  public class FatalIsbInteropException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public FatalIsbInteropException(string message)
      : base(message) { }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public FatalIsbInteropException(string message, Exception innerException)
      : base(message, innerException) { }
  }
}
