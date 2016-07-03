Namespace Accessory.Wrappers
  ''' <summary>
  ''' Обертка над IList с предопределенным типом элементов списка.
  ''' </summary>
  Friend Class ListT(Of T As {IsbComObjectWrapper, TI}, TI As IIsbComObjectWrapper)
    Inherits ForEachT(Of T, TI)
    Implements IList(Of TI)
    ''' <summary>
    ''' Получить значение элемента списка по индексу.
    ''' </summary>
    ''' <param name="index">Индекс элемента в списке.</param>
    ''' <returns>Значение элемента с указанным индексом.</returns>
    Public Function GetValues(index As Integer) As TI Implements IList(Of TI).GetValues
      Dim rcwitemValue = Me.GetRcwProperty("Values", index)
      Dim itemValue = DirectCast(Activator.CreateInstance(GetType(T), rcwitemValue), T)

      Return itemValue
    End Function

    ''' <summary>
    ''' Установить значение элемента.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Public Sub SetVar(name As String, value As Object) Implements IList(Of TI).SetVar
      Dim isbObject = TryCast(value, IUnsafeRcwObjectAccessor)

      If isbObject IsNot Nothing Then
        Me.InvokeRcwInstanceMethod("SetVar", New Object() {name, isbObject.UnsafeRcwObject})
      Else
        Me.InvokeRcwInstanceMethod("SetVar", New Object() {name, value})
      End If
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIList">COM-объект IList.</param>
    Public Sub New(rcwIList As Object)
      MyBase.New(rcwIList)
    End Sub
  End Class
End Namespace