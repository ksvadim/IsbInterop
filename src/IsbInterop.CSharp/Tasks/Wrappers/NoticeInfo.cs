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
    public NoticeInfo(object rcwINoticeInfo) : base(rcwINoticeInfo) { }
  }
}
