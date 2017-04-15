''' <summary>
''' Имплементация базового объекта IS-Builder.
''' </summary>
Friend Class BaseIsbObjectImp
  Inherits BaseIsbObject

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  ''' <param name="rcwObject">COM-объект.</param>
  ''' <param name="scope">Область видимости.</param>
  Public Sub New(rcwObject As Object, scope As IScope)
    MyBase.New(rcwObject, scope)
  End Sub
End Class