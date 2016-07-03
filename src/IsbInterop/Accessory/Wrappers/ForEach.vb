﻿Namespace Accessory.Wrappers
  ''' <summary>
  ''' Обертка над IForEach.
  ''' </summary>
  Friend MustInherit Class ForEach(Of TI As IIsbComObjectWrapper)
    Inherits IsbComObjectWrapper
    Implements IForEach(Of TI)
    ''' <summary>
    ''' Количество элементов в списке.
    ''' </summary>
    Public ReadOnly Property Count() As Integer Implements IForEach(Of TI).Count
      Get
        Return CInt(Me.GetRcwProperty("Count"))
      End Get
    End Property

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    Public ReadOnly Property EOF() As Boolean Implements IForEach(Of TI).EOF
      Get
        Return CBool(Me.GetRcwProperty("EOF"))
      End Get
    End Property

    ''' <summary>
    ''' Получить объект набора данных.
    ''' </summary>
    ''' <returns>Реквизит.</returns>
    Public Function GetValue() As TI Implements IForEach(Of TI).GetValue
      Dim curentValueRcw = Me.GetRcwProperty("Value")
      Dim value = IsbObjectResolver.Resolve(Of TI)(curentValueRcw)

      Return value
    End Function

    ''' <summary>
    ''' Перейти к следующему объекту набора данных.
    ''' </summary>
    Public Sub [Next]() Implements IForEach(Of TI).[Next]
      Me.InvokeRcwInstanceMethod("Next")
    End Sub

    ''' <summary>
    ''' Устанавливить указатель текущего элемента списка на первый элемент списка.
    ''' </summary>
    Public Sub Reset() Implements IForEach(Of TI).Reset
      Me.InvokeRcwInstanceMethod("Reset")
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="contentsObject">Объект IContents.</param>
    Protected Sub New(contentsObject As Object)
      MyBase.New(contentsObject)
    End Sub
  End Class
End Namespace
