Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Wrappers

''' <summary>
''' Область видимости.
''' </summary>
Friend Class Scope
  Implements IScope
  ''' <summary>
  ''' Рабочий набор.
  ''' </summary>
  Private ReadOnly workingSet As New Stack(Of IIsbComObjectWrapper)()

  ''' <summary>
  ''' Приложение IS-Builder.
  ''' </summary>
  Public ReadOnly Property Application As IApplication Implements IScope.Application

#Region "IDisposable"

  ''' <summary>
  ''' Выполнить очистку.
  ''' </summary>
  Public Sub Dispose() Implements IDisposable.Dispose
    For Each isbObject As IIsbComObjectWrapper In workingSet
      Try
        isbObject.Dispose()
        ' Гасим исключение, если объект уже освобожден.
      Catch generatedExceptionName As ObjectDisposedException
      End Try
    Next

    workingSet.Clear()
  End Sub

#End Region

  ''' <summary>
  ''' Добавить объект в область видимости.
  ''' </summary>
  ''' <param name="isbObject">Объект IS-Builder.</param>
  Public Sub Add(isbObject As IIsbComObjectWrapper)
    workingSet.Push(isbObject)
  End Sub

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  ''' <param name="rcwApp">RCW-объект IApplication.</param>
  Public Sub New(rcwApp As Object)
    Me.Application = New Application(rcwApp, Me)
  End Sub
End Class

''' <summary>
''' Интерфейс области видимости.
''' </summary>
Public Interface IScope
  Inherits IDisposable
  ''' <summary>
  ''' Приложение IS-Builder.
  ''' </summary>
  ReadOnly Property Application As IApplication
End Interface
