Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Proxies

''' <summary>
''' Область видимости.
''' </summary>
Friend Class Scope
  Implements IScope
  ''' <summary>
  ''' Рабочий набор.
  ''' </summary>
  Private ReadOnly _workingSet As New Stack(Of IBaseIsbObject)()

  ''' <summary>
  ''' Приложение IS-Builder.
  ''' </summary>
  Public ReadOnly Property Application As IApplication Implements IScope.Application

#Region "IDisposable"

  ''' <summary>
  ''' Выполняет очистку.
  ''' </summary>
  Public Sub Dispose() Implements IDisposable.Dispose
    While _workingSet.Count > 0
      Dim requisite = _workingSet.Pop()
      Try
        requisite.Dispose()
        ' Гасим исключение, если объект уже освобожден.
      Catch exception As ObjectDisposedException
      End Try
    End While

    _workingSet.Clear()
  End Sub

#End Region

  ''' <summary>
  ''' Добавляет объект в область видимости.
  ''' </summary>
  ''' <param name="isbObject">Объект IS-Builder.</param>
  Public Sub Add(isbObject As IBaseIsbObject)
    _workingSet.Push(isbObject)
  End Sub

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  ''' <param name="rcwApp">RCW-объект IApplication.</param>
  Public Sub New(rcwApp As Object)
    Application = New Application(rcwApp, Me)
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
