﻿Imports IsbInterop.Accessory.Wrappers
Imports IsbInterop.Base

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над IAttachmentList.
  ''' </summary>
  Friend Class AttachmentList
    Inherits ForEach(Of IAttachment)
    Implements IAttachmentList

    ''' <summary>
    ''' Добавить вложение.
    ''' </summary>
    ''' <param name="attachmentInfo">Информация о добавляемом вложении.</param>
    Public Sub Add(attachmentInfo As IObjectInfo) Implements  IAttachmentList.Add
      Dim rcwAttachmentInfo = DirectCast(attachmentInfo, IUnsafeRcwHolder).UnsafeRcwObject
      Me.InvokeRcwInstanceMethod("Add", rcwAttachmentInfo)
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIAttachment">СOM-объект IAttachment.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIAttachment As Object, scope As IScope)
      MyBase.New(rcwIAttachment, scope)
    End Sub
  End Class
End NameSpace