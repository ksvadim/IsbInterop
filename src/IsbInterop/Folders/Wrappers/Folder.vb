Imports IsbInterop.Base.Wrappers

Namespace Folders.Wrappers

  ''' <summary>
  ''' Обертка над IFolder.
  ''' </summary>
  Friend Class Folder
    Inherits EdmsObject(Of IFolderInfo)
    Implements IFolder

    ''' <summary>
    ''' Информация об объекте.
    ''' </summary>
    Public Overrides ReadOnly Property Info As IFolderInfo
      Get
        Dim rcwIFolderInfo = GetRcwObjectInfo()
        Return New FolderInfo(rcwIFolderInfo, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIFolder">СOM-объект IFolder.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIFolder As Object, scope As IScope)
      MyBase.New(rcwIFolder, scope)
    End Sub
  End Class
End Namespace