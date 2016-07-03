Imports IsbInterop.Accessory
Imports IsbInterop.Base

Namespace Tasks
  ''' <summary>
  ''' Список вложений.
  ''' </summary>
  Public Interface IAttachmentList
    Inherits IForEach(Of IAttachment)
    ''' <summary>
    ''' Добавить вложение.
    ''' </summary>
    ''' <param name="attachmentInfo">Информация о добавляемом вложении.</param>
    Sub Add(attachmentInfo As IObjectInfo)
  End Interface
End NameSpace