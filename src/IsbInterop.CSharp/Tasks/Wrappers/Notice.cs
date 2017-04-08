using IsbInterop.Base.Wrappers;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над INotice.
  /// </summary>
  internal class Notice : CustomJob<INoticeInfo>, INotice
  {
    /// <summary>
    /// Получить INoticeInfo.
    /// </summary>
    /// <returns>INoticeInfo.</returns>
    public override INoticeInfo GetInfo()
    {
      var rcwINoticeInfo = this.GetRcwObjectInfo();
      return new NoticeInfo(rcwINoticeInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwINotice">СOM-объект INotice.</param>
    /// <param name="scope">Область видимости.</param>
    public Notice(object rcwINotice, IScope scope) : base(rcwINotice, scope) { }
  }
}
