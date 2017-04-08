using IsbInterop.Base.Wrappers;

namespace IsbInterop.Folders.Wrappers
{
  /// <summary>
  /// Обертка над IFolder.
  /// </summary>
  internal class Folder : EdmsObject<IFolderInfo>, IFolder
  {
    /// <summary>
    /// Получить IFolderInfo.
    /// </summary>
    /// <returns>IFolderInfo.</returns>
    public override IFolderInfo GetInfo()
    {
      var rcwIFolderInfo = this.GetRcwObjectInfo();
      return new FolderInfo(rcwIFolderInfo, this.Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIFolder">СOM-объект IFolder.</param>
    /// <param name="scope">Область видимости.</param>
    public Folder(object rcwIFolder, IScope scope) : base(rcwIFolder, scope) { }
  }
}
