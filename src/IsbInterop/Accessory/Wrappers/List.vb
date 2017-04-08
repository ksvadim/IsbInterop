Namespace Accessory.Wrappers
  ''' <summary>
  ''' Обертка над IList.
  ''' </summary>
  Friend Class List(Of TI As IIsbComObjectWrapper)
    Inherits ForEach(Of TI)
    Implements IList(Of TI)

    ''' <summary>
    ''' Добавить элемент.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметра.</typeparam>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Public Sub Add(Of TP As IIsbComObjectWrapper)(name As String, value As TP) Implements IList(Of TI).Add
      If TypeOf value Is TI Then
        InvokeRcwInstanceMethod("Add", New Object() {name, DirectCast(value, IUnsafeRcwObjectAccessor).UnsafeRcwObject})
      Else
        Throw New InvalidOperationException(String.Format("Cannot convert value to {0}", GetType(TI)))
      End If
    End Sub

    ''' <summary>
    ''' Добавить элемент.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Public Sub Add(name As String, value As Object) Implements IList(Of TI).Add
      InvokeRcwInstanceMethod("Add", New Object() {name, value})
    End Sub

    ''' <summary>
    ''' Получить значение элемента списка по индексу.
    ''' </summary>
    ''' <param name="index">Индекс элемента в списке.</param>
    ''' <returns>Значение элемента с указанным индексом.</returns>
    Public Overridable Function GetValues(index As Integer) As TI Implements IList(Of TI).GetValues
      Dim rcwObjectResult = Me.GetRcwProperty("Values", index)
      Return IsbObjectResolver.Resolve(Of TI)(rcwObjectResult, Scope)
    End Function


    ''' <summary>
    ''' Получить значение по имени.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns>Имя искомого элемента.</returns>
    Public Function GetValueByName(name As String) As TI Implements IList(Of TI).GetValueByName
      Dim rcwObject = InvokeRcwInstanceMethod("ValueByName", New Object() {name})
      Return IsbObjectResolver.Resolve(Of TI)(rcwObject, Scope)
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
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIList As Object, scope As IScope)
      MyBase.New(rcwIList, scope)
    End Sub
  End Class
End Namespace
