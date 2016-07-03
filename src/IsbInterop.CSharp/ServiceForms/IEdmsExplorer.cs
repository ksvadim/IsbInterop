using IsbInterop.Accessory;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Folders;

namespace IsbInterop.ServiceForms
{
  /// <summary>
  /// Проводник системы.
  /// </summary>
  public interface IEdmsExplorer : IIsbComObjectWrapper
  {
    /// <summary>
    /// Тип отображения дерева проводника.
    /// </summary>
    TItemShow ShowTree { get; set; }

    /// <summary>
    /// Получить содержимое дерева проводника.
    /// </summary>
    /// <returns>Объект IContents, состоящий из элементов типа IFolderInfo.</returns>
    /// <remarks>
    /// Значением свойства TreeRootContents может быть:
    /// * объект IFolderInfo;
    /// * массив объектов IFolderInfo;
    /// * объект IContents, состоящий из элементов типа IFolderInfo.
    /// </remarks>
    IContents<IFolderInfo> GetTreeRootContents();

    /// <summary>
    /// Установить содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    void SetTreeRootContents(IFolderInfo value);

    /// <summary>
    /// Установить содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    void SetTreeRootContents(IContents<IFolderInfo> value);

    /// <summary>
    /// Показать проводник.
    /// </summary>
    void Show();
  }
}
