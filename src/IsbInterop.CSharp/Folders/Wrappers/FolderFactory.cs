using IsbInterop.Base.Wrappers;

namespace IsbInterop.Folders.Wrappers
{
  /// <summary>
  /// Обертка над IFolderFactory.
  /// </summary>
  internal class FolderFactory : EdmsObjectFactory<IFolder, IFolderInfo>, IFolderFactory
  {
    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IFolder GetObjectById(int id)
    {
      var rcwObject = this.GetRcwObjectById(id);
      return new Folder(rcwObject);
    }

    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IFolderInfo GetObjectInfo(int id)
    {
      var rcwIFolderInfo = this.GetRcwObjectInfo(id);
      return new FolderInfo(rcwIFolderInfo);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIFolderFactory">COM-объект IFolderFactory.</param>
    public FolderFactory(object rcwIFolderFactory) : base(rcwIFolderFactory) { }
  }
}
