Namespace Accessory.Proxies

  ''' <summary>
  ''' Обертка над IForEach.
  ''' </summary>
  Friend MustInherit Class ForEach(Of TI As IBaseIsbObject)
    Inherits BaseIsbObject
    Implements IForEach(Of TI)

    ''' <summary>
    ''' Количество элементов в списке.
    ''' </summary>
    Public ReadOnly Property Count As Integer Implements IForEach(Of TI).Count
      Get
        Return GetRcwProperty("Count")
      End Get
    End Property

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    Public ReadOnly Property EOF As Boolean Implements IForEach(Of TI).EOF
      Get
        Return GetRcwProperty("EOF")
      End Get
    End Property

    ''' <summary>
    ''' Получить значение текущего элемента списка.
    ''' </summary>
    ''' <returns>Значение текущего элемента списка.</returns>
    Public Function GetValue() As TI Implements IForEach(Of TI).GetValue
      Dim curentValueRcw = GetRcwProperty("Value")
      Dim value = IsbObjectResolver.Resolve(Of TI)(curentValueRcw, Scope)

      Return value
    End Function

    ''' <summary>
    ''' Перейти к следующему объекту набора данных.
    ''' </summary>
    Public Sub [Next]() Implements IForEach(Of TI).[Next]
      InvokeRcwInstanceMethod("Next")
    End Sub

    ''' <summary>
    ''' Устанавливить указатель текущего элемента списка на первый элемент списка.
    ''' </summary>
    Public Sub Reset() Implements IForEach(Of TI).Reset
      InvokeRcwInstanceMethod("Reset")
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="contentsObject">Объект IContents.</param>
    ''' <param name="scope">Область видимости.</param>
    Protected Sub New(contentsObject As Object, scope As IScope)
      MyBase.New(contentsObject, scope)
    End Sub
  End Class
End Namespace
