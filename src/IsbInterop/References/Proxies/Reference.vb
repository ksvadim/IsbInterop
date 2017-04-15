Namespace References.Proxies

  ''' <summary>
  ''' Обертка над IReference.
  ''' </summary>
  Friend Class Reference
    Inherits Component
    Implements IReference

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="reference">Справочник DIRECTUM.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(reference As Object, scope As IScope)
      MyBase.New(reference, scope)
    End Sub
  End Class
End Namespace
