using System;

namespace IsbInterop
{
  /// <summary>
  /// Исключение взаимодействия с IS-Builder.
  /// </summary>
  public class IsbInteropException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public IsbInteropException(string message) : base(message)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public IsbInteropException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
