Imports System.Data.SqlClient

''' <summary>
''' Фабрика контекста.
''' </summary>
Public NotInheritable Class ContextFactory

#Region "Константы"

  ''' <summary>
  ''' Формат строки подключения к DIRECTUM.
  ''' </summary>
  Private Const DirectumConnectionStringFormat As String = "ServerName={0};DBName={1};{2}"

  ''' <summary>
  ''' Часть строки подключения к DIRECTUM при windows-аутентификации.
  ''' </summary>
  Private Const DirectumOSAuthenticationPartString As String = "AuthType=OS"

  ''' <summary>
  ''' Часть строки форматирования для подключения к DIRECTUM при парольной аутентификации.
  ''' </summary>
  Private Const DirectumPasswordAuthenticationPartStringFormat As String = "UserName={0};Password={1}"

#End Region

  ''' <summary>
  ''' Создает контекст.
  ''' </summary>
  ''' <param name="connectionString">Строка подключения.</param>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
  ''' <returns>Контекст.</returns>
  Public Shared Function CreateContext(connectionString As String, Optional storeInCache As Boolean = True) As Context
    Dim connectionParams = GetConnectionParams(connectionString)
    Dim rcwApp = IsbApplicationManager.Instance.GetRcwApplication(connectionParams, storeInCache)

    Return New Context(rcwApp, connectionParams, storeInCache)
  End Function

  ''' <summary>
  ''' Создает контекст.
  ''' </summary>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
  ''' <returns>Контекст.</returns>
  Public Shared Function CreateContext(Optional storeInCache As Boolean = True) As Context
    Dim connectionString = ConfigurationUtils.GetConnectionString()
    Dim connectionParams = GetConnectionParams(connectionString)
    Dim rcwApp = IsbApplicationManager.Instance.GetRcwApplication(connectionParams, storeInCache)

    Return New Context(rcwApp, connectionParams, storeInCache)
  End Function

  ''' <summary>
  ''' Получает параметры подключения из строки подключения.
  ''' </summary>
  ''' <param name="connectionString">Строка подключения.</param>
  ''' <returns>Параметры подключения.</returns>
  Private Shared Function GetConnectionParams(connectionString As String) As String
    If connectionString Is Nothing Then
      Throw New FatalIsbInteropException(My.Resources.Resources.UnableToGetDBConnectionParams)
    End If

    Dim builder = New SqlConnectionStringBuilder(connectionString)
    Dim user = builder.UserID

    Dim authenticationPart As String

    If builder.IntegratedSecurity Then
      authenticationPart = DirectumOSAuthenticationPartString
    Else
      authenticationPart = String.Format(DirectumPasswordAuthenticationPartStringFormat, user, builder.Password)
    End If

    Dim server = builder.DataSource
    Dim database = builder.InitialCatalog

    Dim isbConnectionParams = String.Format(DirectumConnectionStringFormat, server, database, authenticationPart)
    Return isbConnectionParams
  End Function
End Class
