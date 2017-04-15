﻿Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Proxies
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.Folders

Namespace ServiceForms.Proxies

  ''' <summary>
  ''' Обертка над IEdmsExplorer.
  ''' </summary>
  Public Class EdmsExplorer
    Inherits BaseIsbObject
    Implements IEdmsExplorer

    ''' <summary>
    ''' Тип отображения дерева проводника.
    ''' </summary>
    Public Property ShowTree As TItemShow Implements IEdmsExplorer.ShowTree
      Get
        Return GetRcwProperty("ShowTree")
      End Get
      Set
        SetRcwProperty("ShowTree", CInt(value))
      End Set
    End Property

    ''' <summary>
    ''' Получает содержимое дерева проводника.
    ''' </summary>
    ''' <returns>Объект IContents, состоящий из элементов типа IFolderInfo.</returns>
    Public Function GetTreeRootContents() As IContents(Of IFolderInfo) Implements IEdmsExplorer.GetTreeRootContents
      Dim rcwTreeRootContents = GetRcwProperty("TreeRootContents")
      Return New Contents(Of IFolderInfo)(rcwTreeRootContents, Scope)
    End Function

    ''' <summary>
    ''' Устанавливает содержимое дерева проводника.
    ''' </summary>
    ''' <param name="value">Значение.</param>
    Public Sub SetTreeRootContents(value As IFolderInfo) Implements IEdmsExplorer.SetTreeRootContents
      SetRcwProperty("TreeRootContents", DirectCast(value, IRcwProxy).RcwObject)
    End Sub

    ''' <summary>
    ''' Устанавливает содержимое дерева проводника.
    ''' </summary>
    ''' <param name="value">Значение.</param>
    Public Sub SetTreeRootContents(value As IContents(Of IFolderInfo)) Implements IEdmsExplorer.SetTreeRootContents
      SetRcwProperty("TreeRootContents", DirectCast(value, IRcwProxy).RcwObject)
    End Sub

    ''' <summary>
    ''' Показывает проводник.
    ''' </summary>
    Public Sub Show() Implements IEdmsExplorer.Show
      InvokeRcwInstanceMethod("Show")
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIEdmsExplorer">СOM-объект IEdmsExplorer.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIEdmsExplorer As Object, scope As IScope)
      MyBase.New(rcwIEdmsExplorer, scope)
    End Sub
  End Class
End NameSpace