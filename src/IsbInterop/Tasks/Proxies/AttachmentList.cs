﻿using IsbInterop.Accessory.Proxies;
using IsbInterop.Base;
using IsbInterop.Collections.Proxies;

namespace IsbInterop.Tasks.Proxies
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
      var rcwAttachmentInfo = ((IRcwProxy) attachmentInfo).RcwObject;
      InvokeRcwInstanceMethod("Add", rcwAttachmentInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIAttachment">СOM-объект IAttachment.</param>
    /// <param name="scope">Область видимости.</param>
    public AttachmentList(object rcwIAttachment, IScope scope)
      : base(rcwIAttachment, scope) { }
  }
}
