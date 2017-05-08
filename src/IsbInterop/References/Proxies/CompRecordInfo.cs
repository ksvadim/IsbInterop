using IsbInterop.Base.Proxies;

namespace IsbInterop.References.Proxies
{
  /// <summary>
  /// Обертка над ICompRecordInfo.
  /// </summary>
  internal abstract class CompRecordInfo : ObjectInfo, ICompRecordInfo
  {
    /// <summary>
    /// Код записи.
    /// </summary>
    public string Code => (string)GetRcwProperty("Code");

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwICompRecordInfo">COM-объект ICompRecordInfo.</param>
    /// <param name="scope">Область видимости.</param>
    protected CompRecordInfo(object rcwICompRecordInfo, IScope scope)
      : base(rcwICompRecordInfo, scope) { }
  }
}
