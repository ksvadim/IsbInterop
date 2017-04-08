Imports IsbInterop.Base.Wrappers

Namespace Folders.Wrappers

  ''' <summary>
  ''' Обертка над IFolderInfo.
  ''' </summary>
  Friend Class FolderInfo
    Inherits ObjectInfo
    Implements IFolderInfo

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="folderInfo">Объект с информацией о папке DIRECTUM.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(folderInfo As Object, scope As IScope)
      MyBase.New(folderInfo, scope)
    End Sub
  End Class
End NameSpace