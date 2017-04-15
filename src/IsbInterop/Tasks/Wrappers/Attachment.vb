Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над IAttachment.
  ''' </summary>
  Friend Class Attachment
    Inherits BaseIsbObject
    Implements IAttachment

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