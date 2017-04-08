Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Wrappers

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
      If application IsNot Nothing Then
        application.Dispose()
      End If

      Me.disposed = True
    End If
  End Sub

#End Region

  ''' <summary>
  ''' Приложение IsBuilder.
  ''' </summary>
  Public ReadOnly application As IApplication

  ''' <summary>
  ''' Параметры подключения.
  ''' </summary>
  Private ReadOnly connectionParams As String

  ''' <summary>
  ''' Признак необходимости добавления информации о соединении в кэш.
  ''' </summary>
  Private ReadOnly storeInCache As Boolean

  ''' <summary>
  ''' Создать область видимости.
  ''' </summary>
  ''' <returns>Область видимости.</returns>
  Public Function CreateScope() As IScope
    Dim rcwApp = IsbApplicationManager.Instance.GetRcwApplication(connectionParams, storeInCache)
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
    Me.application = New Application(rcwApp, Nothing)
    Me.connectionParams = connectionParams
    Me.storeInCache = storeInCache
  End Sub
End Class
