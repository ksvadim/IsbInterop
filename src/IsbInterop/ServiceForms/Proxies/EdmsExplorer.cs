﻿using IsbInterop.Accessory;
using IsbInterop.Accessory.Proxies;
using IsbInterop.Collections;
using IsbInterop.Collections.Proxies;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Folders;

namespace IsbInterop.ServiceForms.Proxies
{
  /// <summary>
  /// Обертка над IEdmsExplorer.
  /// </summary>
  public class EdmsExplorer : BaseIsbObject, IEdmsExplorer
  {
    /// <summary>
    /// Тип отображения дерева проводника.
    /// </summary>
    public TItemShow ShowTree
    {
      get { return (TItemShow)GetRcwProperty("ShowTree"); }
      set { SetRcwProperty("ShowTree", (int)value); }
    }

    /// <summary>
    /// Получает содержимое дерева проводника.
    /// </summary>
    /// <returns>Объект IContents, состоящий из элементов типа IFolderInfo.</returns>
    public IContents<IFolderInfo> GetTreeRootContents()
    {
      var rcwTreeRootContents = GetRcwProperty("TreeRootContents");
      return new Contents<IFolderInfo>(rcwTreeRootContents, Scope);
    }

    /// <summary>
    /// Устанавливает содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void SetTreeRootContents(IFolderInfo value)
    {
      SetRcwProperty("TreeRootContents", ((IRcwProxy)value).RcwObject);
    }

    /// <summary>
    /// Устанавливает содержимое дерева проводника.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void SetTreeRootContents(IContents<IFolderInfo> value)
    {
      SetRcwProperty("TreeRootContents", ((IRcwProxy)value).RcwObject);
    }

    /// <summary>
    /// Показывает проводник.
    /// </summary>
    public void Show()
    {
      InvokeRcwInstanceMethod("Show");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEdmsExplorer">СOM-объект IEdmsExplorer.</param>
    /// <param name="scope">Область видимости.</param>
    public EdmsExplorer(object rcwIEdmsExplorer, IScope scope) : base(rcwIEdmsExplorer, scope) { }
  }
}
