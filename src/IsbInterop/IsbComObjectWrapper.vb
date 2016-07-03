Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Runtime.ConstrainedExecution

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
  Protected Property RcwObject() As Object
    Get
      If disposed Then
        Throw New ObjectDisposedException(Me.typeName)
      End If

      Return _rcwObject
    End Get
    Private Set(value As Object)
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
  Private ReadOnly Property IUnsafeRcwObjectAccessor_UnsafeRcwObject() As Object Implements IUnsafeRcwObjectAccessor.UnsafeRcwObject
    Get
      Return Me.RcwObject
    End Get
  End Property

#End Region

#Region "IDisposable"

  Private disposed As Boolean

  ''' <summary>
  ''' Финализатор.
  ''' </summary>
  Protected Overrides Sub Finalize()
    Try
      Me.Dispose(False)
    Finally
      MyBase.Finalize()
    End Try
  End Sub

  Public Sub Dispose() Implements IDisposable.Dispose
    Me.Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub

  Protected Overridable Sub Dispose(disposing As Boolean)
    If Me.disposed Then
      Return
    End If

    If disposing Then
      If Me._rcwObject IsNot Nothing Then
        If Marshal.IsComObject(Me._rcwObject) Then
          Marshal.ReleaseComObject(Me._rcwObject)
        End If
        Me._rcwObject = Nothing
      End If

      Me.disposed = True
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
    Return ComUtils.InvokeRcwInstanceMethod(Me.RcwObject, methodName, parameter)
  End Function

  ''' <summary>
  ''' Вызвать экземплярный метод COM-объекта.
  ''' </summary>
  ''' <param name="methodName">Имя метода.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, Optional parameters As Object() = Nothing) As Object
    Return ComUtils.InvokeRcwInstanceMethod(Me.RcwObject, methodName, parameters)
  End Function

  ''' <summary>
  ''' Вызвать экземплярный метод COM-объекта.
  ''' </summary>
  ''' <param name="methodName">Имя метода.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <param name="timeout">Таймаут.</param>
  ''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, parameters As Object(), timeout As TimeSpan?) As Object
    Return ComUtils.InvokeRcwInstanceMethod(Me.RcwObject, methodName, parameters, timeout)
  End Function


  ''' <summary>
  ''' Получить свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="parameter">Параметр.</param>
  ''' <returns>Результат.</returns>
  Protected Function GetRcwProperty(propertyName As String, parameter As Object) As Object
    Return ComUtils.GetRcwProperty(Me.RcwObject, propertyName, parameter)
  End Function

  ''' <summary>
  ''' Получить свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <returns>Результат.</returns>
  Protected Function GetRcwProperty(propertyName As String, Optional parameters As Object() = Nothing) As Object
    Return ComUtils.GetRcwProperty(Me.RcwObject, propertyName, parameters)
  End Function

  ''' <summary>
  ''' Установить свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="value">Значение.</param>
  Protected Sub SetRcwProperty(propertyName As String, value As Object)
    ComUtils.SetRcwProperty(Me.RcwObject, propertyName, value)
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
  Protected Sub New(rcwObject As Object)
    Me.RcwObject = rcwObject
    Me.typeName = Information.TypeName(rcwObject)
  End Sub

#End Region

End Class
