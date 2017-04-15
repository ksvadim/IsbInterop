namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IAttachment.
  /// </summary>
  internal class Attachment : BaseIsbObject, IAttachment
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIAttachment">СOM-объект IAttachment.</param>
    /// <param name="scope">Область видимости.</param>
    public Attachment(object rcwIAttachment, IScope scope)
      : base(rcwIAttachment, scope) { }
  }
}
