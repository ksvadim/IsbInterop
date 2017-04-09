Namespace Base.Wrappers

  ''' <summary>
  ''' Обертка над IEdmsObjectInfo.
  ''' </summary>
  Friend Class EdmsObjectInfo
    Inherits ObjectInfo
    Implements IEdmsObjectInfo

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIEdmsObjectInfo">COM-объект IEdmsObjectInfo.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIEdmsObjectInfo As Object, scope As IScope)
      MyBase.New(rcwIEdmsObjectInfo, scope)
    End Sub
  End Class
End Namespace