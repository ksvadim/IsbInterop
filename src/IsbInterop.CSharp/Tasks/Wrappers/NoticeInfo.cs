namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над INoticeInfo.
  /// </summary>
  internal class NoticeInfo : CustomJobInfo, INoticeInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwINoticeInfo">COM-объект IJobInfo.</param>
    /// <param name="scope">Область видимости.</param>
    public NoticeInfo(object rcwINoticeInfo, IScope scope)
      : base(rcwINoticeInfo, scope) { }
  }
}
