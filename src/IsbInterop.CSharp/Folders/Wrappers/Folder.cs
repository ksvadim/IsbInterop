using IsbInterop.Base.Wrappers;

namespace IsbInterop.Folders.Wrappers
{
  /// <summary>
  /// Обертка над IFolder.
  /// </summary>
  internal class Folder : EdmsObject<IFolderInfo>, IFolder
  {
    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override IFolderInfo GetInfo()
    {
      var rcwIFolderInfo = GetRcwObjectInfo();
      return new FolderInfo(rcwIFolderInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIFolder">СOM-объект IFolder.</param>
    /// <param name="scope">Область видимости.</param>
    public Folder(object rcwIFolder, IScope scope) : base(rcwIFolder, scope) { }
  }
}
