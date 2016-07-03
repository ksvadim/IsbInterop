using IsbInterop.Base;

namespace IsbInterop.References
{
  /// <summary>
  /// Информации о записи компоненты.
  /// </summary>
  public interface ICompRecordInfo : IObjectInfo
  {
    /// <summary>
    /// Код записи.
    /// </summary>
    string Code { get; }
  }
}
