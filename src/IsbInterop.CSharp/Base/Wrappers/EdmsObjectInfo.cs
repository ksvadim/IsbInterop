namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IEdmsObjectInfo.
  /// </summary>
  internal class EdmsObjectInfo : ObjectInfo, IEdmsObjectInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEdmsObjectInfo">COM-объект IEdmsObjectInfo.</param>
    /// <param name="scope">Область видимости.</param>
    public EdmsObjectInfo(object rcwIEdmsObjectInfo, IScope scope) : base(rcwIEdmsObjectInfo, scope) { }
  }
}
