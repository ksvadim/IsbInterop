namespace IsbInterop.References.Wrappers
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
    public ReferenceInfo(object rcwIReferenceInfo) : base(rcwIReferenceInfo) { }
  }
}
