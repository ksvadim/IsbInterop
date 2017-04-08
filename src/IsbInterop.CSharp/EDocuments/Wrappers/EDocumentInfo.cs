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
    /// <param name="scope">Область видимости.</param>
    public EDocumentInfo(object rcwIEDocumentInfo, IScope scope) : base(rcwIEDocumentInfo, scope) { }
  }
}
