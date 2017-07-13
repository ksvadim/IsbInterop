using IsbInterop.Base;
using IsbInterop.Tasks;
using IsbInterop.Tasks.Proxies;

namespace IsbInterop.Edms.Proxies
{
  /// <summary>
  /// Обертка над ICustomWork.
  /// </summary>
  internal abstract class CustomWork<TI> : EdmsObject<TI>, ICustomWork<TI>
    where TI : IObjectInfo
  {
    /// <summary>
    /// Получает список вложений.
    /// </summary>
    /// <param name="isForFamilyTask">Признак доступности вложений для семейства задач.</param>
    /// <returns>Список вложений.</returns>
    public IAttachmentList GetAttachments(bool isForFamilyTask)
    {
      var rcwIAttachmentList = InvokeRcwInstanceMethod("GetAttachments", isForFamilyTask);
      return new AttachmentList(rcwIAttachmentList, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICustomWork">COM-объект ICustomWork.</param>
    /// <param name="scope">Область видимости.</param>
    protected CustomWork(object rcwICustomWork, IScope scope) : base(rcwICustomWork, scope) { }
  }
}
