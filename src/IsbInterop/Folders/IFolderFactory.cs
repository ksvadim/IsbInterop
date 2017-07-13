using IsbInterop.Base;
using IsbInterop.Edms;

namespace IsbInterop.Folders
{
  /// <summary>
  /// Фабрика папок.
  /// </summary>
  public interface IFolderFactory : IEdmsObjectFactory<IFolder, IFolderInfo>
  {
  }
}
