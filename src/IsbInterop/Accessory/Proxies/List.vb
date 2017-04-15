﻿Namespace Accessory.Proxies

  ''' <summary>
  ''' Обертка над IList.
  ''' </summary>
  Friend Class List(Of TI As IBaseIsbObject)
    Inherits ForEach(Of TI)
    Implements IList(Of TI)

    ''' <summary>
    ''' Добавляет элемент в список.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметра.</typeparam>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Public Sub Add(Of TP As IBaseIsbObject)(name As String, value As TP) Implements IList(Of TI).Add
      If TypeOf value Is TI Then
        InvokeRcwInstanceMethod("Add", New Object() {name, DirectCast(value, IRcwProxy).RcwObject})
      Else
        Throw New InvalidOperationException(String.Format("Cannot convert value to {0}", GetType(TI)))
      End If
    End Sub

    ''' <summary>
    ''' Добавляет элемент в список.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Public Sub Add(name As String, value As Object) Implements IList(Of TI).Add
      InvokeRcwInstanceMethod("Add", New Object() {name, value})
    End Sub

    ''' <summary>
    ''' Получает значение элемента списка по индексу.
    ''' </summary>
    ''' <param name="index">Индекс элемента в списке.</param>
    ''' <returns>Значение элемента с указанным индексом.</returns>
    Public Function GetValues(index As Integer) As TI Implements IList(Of TI).GetValues
      Dim rcwObjectResult = GetRcwProperty("Values", index)
      Return IsbObjectResolver.Resolve(Of TI)(rcwObjectResult, Scope)
    End Function

    ''' <summary>
    ''' Получает значение элемента по имени.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <returns>Значение элемента.</returns>
    Public Function GetValueByName(name As String) As TI Implements IList(Of TI).GetValueByName
      Dim rcwObject = InvokeRcwInstanceMethod("ValueByName", New Object() {name})
      Return IsbObjectResolver.Resolve(Of TI)(rcwObject, Scope)
    End Function

    ''' <summary>
    ''' Установливает значение элемента.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Public Sub SetVar(name As String, value As Object) Implements IList(Of TI).SetVar
      Dim isbObject = TryCast(value, IRcwProxy)

      If isbObject IsNot Nothing Then
        InvokeRcwInstanceMethod("SetVar", New Object() {name, isbObject.RcwObject})
      Else
        InvokeRcwInstanceMethod("SetVar", New Object() {name, value})
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