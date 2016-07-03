Imports IsbInterop.Tasks
Imports IsbInterop.Tasks.Wrappers

Namespace Base.Wrappers
  ''' <summary>
  ''' Обертка над ICustomWork.
  ''' </summary>
  Friend MustInherit Class CustomWork(Of TI As IObjectInfo)
    Inherits EdmsObject(Of TI)
    Implements ICustomWork(Of TI)

    ''' <summary>
    ''' Получить список вложений.
    ''' </summary>
    ''' <param name="isForFamilyTask">Признак доступности вложений для семейства задач.</param>
    ''' <returns>Список вложений.</returns>
    Public Function GetAttachments(isForFamilyTask As Boolean) As IAttachmentList Implements ICustomWork(Of TI).GetAttachments
      Dim rcwIAttachmentList = Me.InvokeRcwInstanceMethod("GetAttachments", isForFamilyTask)
      Return New AttachmentList(rcwIAttachmentList)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwICustomWork">COM-объект ICustomWork.</param>
    Protected Sub New(rcwICustomWork As Object)
      MyBase.New(rcwICustomWork)
    End Sub
  End Class
End Namespace