Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports IsbInterop.Utils

''' <summary>
''' Базовый объект.
''' </summary>
Public MustInherit Class IsbComObjectWrapper
  Inherits CriticalFinalizerObject
  Implements IIsbComObjectWrapper
  Implements IUnsafeRcwHolder

#Region "Поля и свойства"

  ''' <summary>
  ''' COM-объект IS-Builder.
  ''' </summary>
  Protected Property RcwObject As Object
    Get
      If _disposed Then
        Throw New ObjectDisposedException(_typeName)
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
  Private ReadOnly _typeName As String

  ''' <summary>
  ''' COM-объект IS-Builder.
  ''' </summary>
  Private ReadOnly Property IUnsafeRcwHolder_RcwObject As Object Implements IUnsafeRcwHolder.RcwObject
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

  Private _disposed As Boolean

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
    If _disposed Then
      Return
    End If

    If disposing Then
      If _rcwObject IsNot Nothing Then
        If Marshal.IsComObject(_rcwObject) Then
          Marshal.ReleaseComObject(_rcwObject)
        End If
        _rcwObject = Nothing
      End If

      _disposed = True
    End If
  End Sub

#End Region

#Region "Методы"

  '''' <summary>
  '''' Вызывает экземплярный метод COM-объекта.
  '''' </summary>
  '''' <param name="methodName">Имя метода.</param>
  '''' <param name="parameter">Параметр.</param>
  '''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, parameter As Object) As Object
    Return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameter)
  End Function

  ''' <summary>
  ''' Вызывает экземплярный метод COM-объекта.
  ''' </summary>
  ''' <param name="methodName">Имя метода.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, Optional parameters As Object() = Nothing) As Object
    Return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameters)
  End Function

  ''' <summary>
  ''' Вызывает экземплярный метод COM-объекта.
  ''' </summary>
  ''' <param name="methodName">Имя метода.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <param name="timeout">Таймаут.</param>
  ''' <returns>Результат.</returns>
  Protected Function InvokeRcwInstanceMethod(methodName As String, parameters As Object(), timeout As TimeSpan?) As Object
    Return ComUtils.InvokeRcwInstanceMethod(RcwObject, methodName, parameters, timeout)
  End Function


  ''' <summary>
  ''' Получает свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="parameter">Параметр.</param>
  ''' <returns>Результат.</returns>
  Protected Function GetRcwProperty(propertyName As String, parameter As Object) As Object
    Return ComUtils.GetRcwProperty(RcwObject, propertyName, parameter)
  End Function

  ''' <summary>
  ''' Получает свойство COM-объекта.
  ''' </summary>
  ''' <param name="propertyName">Имя свойства.</param>
  ''' <param name="parameters">Параметры.</param>
  ''' <returns>Результат.</returns>
  Protected Function GetRcwProperty(propertyName As String, Optional parameters As Object() = Nothing) As Object
    Return ComUtils.GetRcwProperty(RcwObject, propertyName, parameters)
  End Function

  ''' <summary>
  ''' Устанавливает свойство COM-объекта.
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
    RcwObject = rcwObject
    Scope = scope
    _typeName = Information.TypeName(rcwObject)

    If scope IsNot Nothing Then
      DirectCast(scope, Scope).Add(Me)
    End If
  End Sub

#End Region

End Class
