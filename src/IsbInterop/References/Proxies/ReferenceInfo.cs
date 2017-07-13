namespace IsbInterop.References.Proxies
{
  /// <summary>
  /// Обертка над IReferenceInfo.
  /// </summary>
  internal class ReferenceInfo : CompRecordInfo, IReferenceInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIReferenceInfo">COM-объект IReferenceInfo.</param>
    /// <param name="scope">Область видимости.</param>
    public ReferenceInfo(object rcwIReferenceInfo, IScope scope) : base(rcwIReferenceInfo, scope) { }
  }
}
