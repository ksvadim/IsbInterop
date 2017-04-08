Imports IsbInterop.Base.Wrappers

Namespace Folders.Wrappers

  ''' <summary>
  ''' Обертка над IFolder.
  ''' </summary>
  Friend Class Folder
    Inherits EdmsObject(Of IFolderInfo)
    Implements IFolder

    ''' <summary>
    ''' Получить IFolderInfo.
    ''' </summary>
    ''' <returns>IFolderInfo.</returns>
    Public Overrides Function GetInfo() As IFolderInfo
      Dim rcwIFolderInfo = Me.GetRcwObjectInfo()
      Return New FolderInfo(rcwIFolderInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIFolder">СOM-объект IFolder.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIFolder As Object, scope As IScope)
      MyBase.New(rcwIFolder, scope)
    End Sub
  End Class
End NameSpace