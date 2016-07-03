Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над IAttachment.
  ''' </summary>
  Friend Class Attachment
    Inherits IsbComObjectWrapper
    Implements IAttachment
    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIAttachment">СOM-объект IAttachment.</param>
    Public Sub New(rcwIAttachment As Object)
      MyBase.New(rcwIAttachment)
    End Sub
  End Class
End NameSpace