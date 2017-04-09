using IsbInterop.Base.Wrappers;

namespace IsbInterop.Folders.Wrappers
{
  /// <summary>
  /// Обертка над IFolder.
  /// </summary>
  internal class Folder : EdmsObject<IFolderInfo>, IFolder
  {
    /// <summary>
    /// Информация об объекте.
    /// </summary>
    public override IFolderInfo Info
    {
      get
      {
        var rcwIFolderInfo = GetRcwObjectInfo();
        return new FolderInfo(rcwIFolderInfo, Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIFolder">СOM-объект IFolder.</param>
    /// <param name="scope">Область видимости.</param>
    public Folder(object rcwIFolder, IScope scope) : base(rcwIFolder, scope) { }
  }
}
