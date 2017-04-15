using IsbInterop.Base.Wrappers;

namespace IsbInterop.Folders.Wrappers
{
  /// <summary>
  /// Обертка над IFolderFactory.
  /// </summary>
  internal class FolderFactory : EdmsObjectFactory<IFolder, IFolderInfo>, IFolderFactory
  {
    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IFolder GetObjectById(int id)
    {
      var rcwObject = GetRcwObjectById(id);
      return new Folder(rcwObject, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IFolderInfo GetObjectInfo(int id)
    {
      var rcwIFolderInfo = GetRcwObjectInfo(id);
      return new FolderInfo(rcwIFolderInfo, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIFolderFactory">COM-объект IFolderFactory.</param>
    /// <param name="scope">Область видимости.</param>
    public FolderFactory(object rcwIFolderFactory, IScope scope)
      : base(rcwIFolderFactory, scope) { }
  }
}
