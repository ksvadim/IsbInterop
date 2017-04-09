using IsbInterop.Tasks;

namespace IsbInterop.Base
{
  /// <summary>
  /// Деловой процесс.
  /// </summary>
  public interface ICustomWork<out TI> : IEdmsObject<TI> where TI : IObjectInfo
  {
    /// <summary>
    /// Получает список вложений.
    /// </summary>
    /// <param name="isForFamilyTask">Признак доступности вложений для семейства задач.
    /// Возможные значения:
    /// True – если нужно получить вложения, доступные из всех объектов семейства;
    /// False – если нужно получить вложения, доступные только из текущей задачи или задания.
    /// </param>
    /// <returns>Список вложений.</returns>
    IAttachmentList GetAttachments(bool isForFamilyTask);
  }
}
