using System;

namespace IsbInterop
{
  /// <summary>
  /// Исключение превышения времени, отведенного на выполнение.
  /// </summary>
  public class IsbInteropTimoutException : IsbInteropException
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public IsbInteropTimoutException(string message) : base(message)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public IsbInteropTimoutException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
