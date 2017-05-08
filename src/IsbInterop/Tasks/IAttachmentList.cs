using IsbInterop.Accessory;
using IsbInterop.Base;

namespace IsbInterop.Tasks
{
  /// <summary>
  /// Список вложений.
  /// </summary>
  public interface IAttachmentList : IForEach<IAttachment>
  {
    /// <summary>
    /// Добавить вложение.
    /// </summary>
    /// <param name="attachmentInfo">Информация о добавляемом вложении.</param>
    void Add(IObjectInfo attachmentInfo);
  }
}
