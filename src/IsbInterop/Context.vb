Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Proxies

''' <summary>
''' Контекст.
''' </summary>
Public Class Context
  Implements IDisposable

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
      If _application IsNot Nothing Then
        _application.Dispose()
      End If

      disposed = True
    End If
  End Sub

#End Region

  ''' <summary>
  ''' Приложение IsBuilder.
  ''' </summary>
  Private ReadOnly _application As IApplication

  ''' <summary>
  ''' Параметры подключения.
  ''' </summary>
  Private ReadOnly _connectionParams As String

  ''' <summary>
  ''' Признак необходимости добавления информации о соединении в кэш.
  ''' </summary>
  Private ReadOnly _storeInCache As Boolean

  ''' <summary>
  ''' Создает область видимости.
  ''' </summary>
  ''' <returns>Область видимости.</returns>
  Public Function CreateScope() As IScope
    Dim rcwApp = IsbApplicationManager.Instance.GetRcwApplication(_connectionParams, _storeInCache)
    Dim scope = New Scope(rcwApp)

    Return scope
  End Function

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  ''' <param name="rcwApp">RCW-объект IApplication.</param>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
  Public Sub New(rcwApp As Object, connectionParams As String, storeInCache As Boolean)
    _application = New Application(rcwApp, Nothing)
    _connectionParams = connectionParams
    _storeInCache = storeInCache
  End Sub
End Class
