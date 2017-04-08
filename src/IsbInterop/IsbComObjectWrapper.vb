Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices

''' <summary>
''' Базовый объект.
''' </summary>
Public MustInherit Class IsbComObjectWrapper
  Inherits CriticalFinalizerObject
  Implements IIsbComObjectWrapper
  Implements IUnsafeRcwObjectAccessor

#Region "Поля и свойства"

  ''' <summary>
  ''' COM-объект IS-Builder.
  ''' </summary>
  Protected Property RcwObject As Object
    Get
      If disposed Then
        Throw New ObjectDisposedException(Me.typeName)
      End If

      Return _rcwObject
    End Get
    Private Set
      _rcwObject = value
    End Set
  End Property

  Private _rcwObject As Object

  ''' <summary>
  ''' Имя типа.
  ''' </summary>
  Private ReadOnly typeName As String

  ''' <summary>
  ''' COM-объект IS-Builder.
  ''' </summary>
  Private ReadOnly Property IUnsafeRcwObjectAccessor_UnsafeRcwObject As Object Implements IUnsafeRcwObjectAccessor.UnsafeRcwObject
    Get
      Return RcwObject
    End Get
  End Property

  ''' <summary>
  ''' Область видимости.
  ''' </summary>
  Friend Property Scope As IScope

#End Region

#Region "IDisposable"

  Private disposed As Boolean

  ''' <summary>
  ''' Финализатор.
  ''' </summary>
  Protected Overrides Sub Finalize()
    Try
      Dispose(False)
    Finally
      MyBase.Finalize()
    End Try
  End Sub

  Public Sub Dispose() Implements IDisposable.Dispose
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub

  Protected Overridable Sub Dispose(disposing As Boolean)
    If disposed Then
      Return
    End If

    If disposing Then
      If _rcwObject IsNot Nothing Then
        If Marshal.IsComObject(_rcwObject) Then
          Marshal.ReleaseComObject(_rcwObject)
        End If
        Me._rcwObject = Nothing
      End If

      disposed = True
    End If
  End Sub

#End Region

#Region "Методы"

  '''' <summary>
  '''' Вызвать экземплярный метод COM-объекта.
  '''' </summary>
  '''' <param name="methodName">Имя метода.</param>
  '''' <param name="parameter">Параметр.</param>
  '''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, parameter As Object) As Object
    Return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameter)
  End Function

  ''' <summary>
  ''' Вызвать экземплярный метод COM-объекта.
  ''' </summary>
  ''' <param name="methodName">Имя метода.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, Optional parameters As Object() = Nothing) As Object
    Return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameters)
  End Function

  ''' <summary>
  ''' Вызвать экземплярный метод COM-объекта.
  ''' </summary>
  ''' <param name="methodName">Имя метода.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <param name="timeout">Таймаут.</param>
  ''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, parameters As Object(), timeout As TimeSpan?) As Object
    Return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameters, timeout)
  End Function


  ''' <summary>
  ''' Получить свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="parameter">Параметр.</param>
  ''' <returns>Результат.</returns>
  Protected Function GetRcwProperty(propertyName As String, parameter As Object) As Object
    Return ComUtils.GetRcwProperty(RcwObject, propertyName, parameter)
  End Function

  ''' <summary>
  ''' Получить свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <returns>Результат.</returns>
  Protected Function GetRcwProperty(propertyName As String, Optional parameters As Object() = Nothing) As Object
    Return ComUtils.GetRcwProperty(RcwObject, propertyName, parameters)
  End Function

  ''' <summary>
  ''' Установить свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="value">Значение.</param>
  Protected Sub SetRcwProperty(propertyName As String, value As Object)
    ComUtils.SetRcwProperty(RcwObject, propertyName, value)
  End Sub

#End Region

#Region "Конструкторы"

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  Protected Sub New()
  End Sub

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  ''' <param name="rcwObject">COM-объект IS-Builder.</param>
  ''' <param name="scope">Область видимости.</param>
  Protected Sub New(rcwObject As Object, scope As IScope)
    Me.RcwObject = rcwObject
    typeName = Information.TypeName(rcwObject)
    Me.Scope = scope

    If scope IsNot Nothing Then
      DirectCast(scope, Scope).Add(Me)
    End If
  End Sub

#End Region

End Class
