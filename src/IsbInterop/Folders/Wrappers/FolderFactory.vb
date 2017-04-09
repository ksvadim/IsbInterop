Imports IsbInterop.Base.Wrappers

Namespace Folders.Wrappers

  ''' <summary>
  ''' Обертка над IFolderFactory.
  ''' </summary>
  Friend Class FolderFactory
    Inherits EdmsObjectFactory(Of IFolder, IFolderInfo)
    Implements IFolderFactory

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As IFolder
      Dim rcwObject = GetRcwObjectById(id)
      Return New Folder(rcwObject, Scope)
    End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IFolderInfo
      Dim rcwIFolderInfo = GetRcwObjectInfo(id)
      Return New FolderInfo(rcwIFolderInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIFolderFactory">COM-объект IFolderFactory.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIFolderFactory As Object, scope As IScope)
      MyBase.New(rcwIFolderFactory, scope)
    End Sub
  End Class
End Namespace