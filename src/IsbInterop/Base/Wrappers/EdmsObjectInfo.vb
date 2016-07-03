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
    Public Sub New(rcwIEdmsObjectInfo As Object)
      MyBase.New(rcwIEdmsObjectInfo)
    End Sub
  End Class
End NameSpace