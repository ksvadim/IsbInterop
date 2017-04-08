using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Folders;

namespace IsbInterop.ServiceForms.Wrappers
{
  /// <summary>
  /// Обертка над IEdmsExplorer.
  /// </summary>
  public class EdmsExplorer : IsbComObjectWrapper, IEdmsExplorer
  {
    /// <summary>
    /// Тип отображения дерева проводника.
    /// </summary>
    public TItemShow ShowTree
    {
      get { return (TItemShow)this.GetRcwProperty("ShowTree"); }
      set { this.SetRcwProperty("ShowTree", (int)value); }
    }

    /// <summary>
    /// Получить содержимое дерева проводника.
    /// </summary>
    /// <returns>Объект IContents, состоящий из элементов типа IFolderInfo.</returns>
    public IContents<IFolderInfo> GetTreeRootContents()
    {
      var rcwTreeRootContents = this.GetRcwProperty("TreeRootContents");
      return new Contents<IFolderInfo>(rcwTreeRootContents, this.Scope);
    }

    /// <summary>
    /// Установить содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void SetTreeRootContents(IFolderInfo value)
    {
      this.SetRcwProperty("TreeRootContents", ((IUnsafeRcwObjectAccessor)value).UnsafeRcwObject);
    }

    /// <summary>
    /// Установить содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void SetTreeRootContents(IContents<IFolderInfo> value)
    {
      this.SetRcwProperty("TreeRootContents", ((IUnsafeRcwObjectAccessor)value).UnsafeRcwObject);
    }

    /// <summary>
    /// Показать проводник.
    /// </summary>
    public void Show()
    {
      this.InvokeRcwInstanceMethod("Show");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEdmsExplorer">СOM-объект IEdmsExplorer.</param>
    /// <param name="scope">Область видимости.</param>
    public EdmsExplorer(object rcwIEdmsExplorer, IScope scope) : base(rcwIEdmsExplorer, scope) { }
  }
}
