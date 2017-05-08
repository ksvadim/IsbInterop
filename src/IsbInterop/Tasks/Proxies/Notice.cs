using IsbInterop.Base.Proxies;

namespace IsbInterop.Tasks.Proxies
{
  /// <summary>
  /// Обертка над INotice.
  /// </summary>
  internal class Notice : CustomJob<INoticeInfo>, INotice
  {
    /// <summary>
    /// Получает информацию об объекте.
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
