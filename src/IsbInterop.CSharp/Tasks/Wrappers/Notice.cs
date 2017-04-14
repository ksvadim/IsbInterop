using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над INotice.
  /// </summary>
  internal class Notice : CustomJob<INoticeInfo>, INotice
  {
    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override INoticeInfo GetInfo()
    {
      var rcwINoticeInfo = GetRcwObjectInfo();
      return new NoticeInfo(rcwINoticeInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwINotice">СOM-объект INotice.</param>
    /// <param name="scope">Область видимости.</param>
    public Notice(object rcwINotice, IScope scope) : base(rcwINotice, scope) { }
  }
}
