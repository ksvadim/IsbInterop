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
    Public Sub New(folderInfo As Object)
      MyBase.New(folderInfo)
    End Sub
  End Class
End NameSpace