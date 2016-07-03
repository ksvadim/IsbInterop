namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IAttachment.
  /// </summary>
  internal class Attachment : IsbComObjectWrapper, IAttachment
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIAttachment">СOM-объект IAttachment.</param>
    public Attachment(object rcwIAttachment) : base(rcwIAttachment) { }
  }
}
