Imports IsbInterop.Base.Proxies

Namespace Folders.Proxies

  ''' <summary>
  ''' Обертка над IFolder.
  ''' </summary>
  Friend Class Folder
    Inherits EdmsObject(Of IFolderInfo)
    Implements IFolder

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As IFolderInfo
      Dim rcwIFolderInfo = GetRcwObjectInfo()
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
End Namespace