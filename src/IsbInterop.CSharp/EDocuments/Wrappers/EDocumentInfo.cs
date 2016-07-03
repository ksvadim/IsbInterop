using IsbInterop.Base.Wrappers;

namespace IsbInterop.EDocuments.Wrappers
{
  /// <summary>
  /// Обертка над IEDocumentInfo.
  /// </summary>
  internal class EDocumentInfo : ObjectInfo, IEDocumentInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEDocumentInfo">COM-объект IEDocumentInfo.</param>
    public EDocumentInfo(object rcwIEDocumentInfo) : base(rcwIEDocumentInfo) { }
  }
}
