using IsbInterop.Accessory.Wrappers;
using IsbInterop.Base;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IAttachmentList.
  /// </summary>
  internal class AttachmentList : ForEach<IAttachment>, IAttachmentList
  {
    /// <summary>
    /// Добавить вложение.
    /// </summary>
    /// <param name="attachmentInfo">Информация о добавляемом вложении.</param>
    public void Add(IObjectInfo attachmentInfo)
    {
      var rcwAttachmentInfo = ((IUnsafeRcwObjectAccessor) attachmentInfo).UnsafeRcwObject;
      this.InvokeRcwInstanceMethod("Add", rcwAttachmentInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIAttachment">СOM-объект IAttachment.</param>
    public AttachmentList(object rcwIAttachment) : base(rcwIAttachment) { }
  }
}
