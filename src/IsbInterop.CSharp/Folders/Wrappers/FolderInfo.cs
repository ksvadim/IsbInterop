using IsbInterop.Base.Wrappers;

namespace IsbInterop.Folders.Wrappers
{
  /// <summary>
  /// Обертка над IFolderInfo.
  /// </summary>
  internal class FolderInfo : ObjectInfo, IFolderInfo
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="folderInfo">Объект с информацией о папке DIRECTUM.</param>
    public FolderInfo(object folderInfo) : base(folderInfo) { }
  }
}
