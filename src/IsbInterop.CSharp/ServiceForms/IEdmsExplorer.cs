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
    /// Получает содержимое дерева проводника.
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
    /// Устанавливает содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    void SetTreeRootContents(IFolderInfo value);

    /// <summary>
    /// Устанавливает содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    void SetTreeRootContents(IContents<IFolderInfo> value);

    /// <summary>
    /// Показывает проводник.
    /// </summary>
    void Show();
  }
}
