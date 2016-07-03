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
      Dim rcwObject = Me.GetRcwObjectById(id)
      Return New Folder(rcwObject)
    End Function

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IFolderInfo
      Dim rcwIFolderInfo = Me.GetRcwObjectInfo(id)
      Return New FolderInfo(rcwIFolderInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIFolderFactory">COM-объект IFolderFactory.</param>
    Public Sub New(rcwIFolderFactory As Object)
      MyBase.New(rcwIFolderFactory)
    End Sub
  End Class
End NameSpace