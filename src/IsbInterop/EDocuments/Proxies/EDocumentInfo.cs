using IsbInterop.Base.Proxies;

namespace IsbInterop.EDocuments.Proxies
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
