Imports IsbInterop.Accessory
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.Folders

Namespace ServiceForms

  ''' <summary>
  ''' Проводник системы.
  ''' </summary>
  Public Interface IEdmsExplorer
    Inherits IBaseIsbObject

    ''' <summary>
    ''' Тип отображения дерева проводника.
    ''' </summary>
    Property ShowTree As TItemShow

    ''' <summary>
    ''' Получает содержимое дерева проводника.
    ''' </summary>
    ''' <returns>Объект IContents, состоящий из элементов типа IFolderInfo.</returns>
    ''' <remarks>
    ''' Значением свойства TreeRootContents может быть:
    ''' * объект IFolderInfo;
    ''' * массив объектов IFolderInfo;
    ''' * объект IContents, состоящий из элементов типа IFolderInfo.
    ''' </remarks>
    Function GetTreeRootContents() As IContents(Of IFolderInfo)

    ''' <summary>
    ''' Устанавливает содержимое дерева проводника.
    ''' </summary>
    ''' <param name="value">Значение.</param>
    Sub SetTreeRootContents(value As IFolderInfo)

    ''' <summary>
    ''' Устанавливает содержимое дерева проводника.
    ''' </summary>
    ''' <param name="value">Значение.</param>
    Sub SetTreeRootContents(value As IContents(Of IFolderInfo))

    ''' <summary>
    ''' Показывает проводник.
    ''' </summary>
    Sub Show()
  End Interface
End NameSpace