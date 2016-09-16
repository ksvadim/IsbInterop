Imports System.Data.SqlClient
Imports System.Threading
Imports IsbInterop.Accessory

''' <summary>
''' Менеджер приложения IS-Builder.
''' </summary>
''' <remarks>Кэширует экземпляр IApplication.</remarks>
Public Class IsbApplicationManager

#Region "Singleton"

    Private Shared ReadOnly managerInstance As New Lazy(Of IsbApplicationManager)(Function() New IsbApplicationManager(), True)

    ''' <summary>
    ''' Экземпляр одиночки.
    ''' </summary>
    Public Shared ReadOnly Property Instance() As IsbApplicationManager
        Get
            Return managerInstance.Value
        End Get
    End Property


    ''' <summary>
    ''' Приватный конструктор.
    ''' </summary>
    Private Sub New()
    End Sub

#End Region

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

#Region "Поля и свойства"

    ''' <summary>
    ''' Параметры подключения к DIRECTUM из конфигурации приложения.
    ''' </summary>
    Private configConnectionParams As String

    ''' <summary>
    ''' Объект блокировки.
    ''' </summary>
    Private ReadOnly lockRoot As New Object()

    ''' <summary>
    ''' Объект приложения.
    ''' </summary>
    Private application As IApplication

    ''' <summary>
    ''' Объект приложения.
    ''' </summary>
    Private currentLoginPoint As ILoginPoint

    ''' <summary>
    ''' Признак необходимости обновления текущей точки подключения.
    ''' </summary>
    Private Shared needUpdateCurrentLoginPoint As Boolean = False

#End Region

#Region "Методы"

    ''' <summary>
    ''' Получить объект приложения IS-Builder.
    ''' </summary>
    ''' <param name="connectionParams">Строка подключения.</param>
    ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    ''' <returns>Объект приложения.</returns>
    ''' <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
    Public Function GetApplication(connectionParams As String, Optional storeInCache As Boolean = True) As IApplication
        If connectionParams Is Nothing Then
            Throw New ArgumentNullException(NameOf(connectionParams))
        End If

        If Me.currentLoginPoint IsNot Nothing Then
            Try
                Dim id As Integer = Me.currentLoginPoint.PID
            Catch generatedExceptionName As Exception
                Dim lockedHere As Boolean = False
                SyncLock lockRoot
                    If Not needUpdateCurrentLoginPoint Then
                        needUpdateCurrentLoginPoint = True
                        lockedHere = True
                    End If
                End SyncLock
                If lockedHere Then
                    Me.currentLoginPoint = LoginPoint.GetLoginPoint()
                    needUpdateCurrentLoginPoint = False
                    Return InternalGetNewIsbApplication(connectionParams, storeInCache, Me.currentLoginPoint)
                End If
            End Try

            Return InternalGetNewIsbApplication(connectionParams, storeInCache)
        Else
            SyncLock lockRoot
                If Me.currentLoginPoint Is Nothing Then
                    Me.currentLoginPoint = LoginPoint.GetLoginPoint()
                    Return InternalGetNewIsbApplication(connectionParams, storeInCache, Me.currentLoginPoint)
                End If
            End SyncLock
        End If

        Return InternalGetNewIsbApplication(connectionParams, storeInCache)
    End Function

    ''' <summary>
    ''' Получить объект приложения IS-Builder.
    ''' </summary>
    ''' <param name="connectionString">Строка подключения.</param>
    ''' <returns>Объект приложения.</returns>
    ''' <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
    Public Function GetApplicationByConnectionString(connectionString As String) As IApplication
        Dim connectionParams = GetConnectionParams(connectionString)

        Return Me.GetApplication(connectionParams)
    End Function

    ''' <summary>
    ''' Получить объект приложения IS-Builder.
    ''' </summary>
    ''' <returns>Объект приложения.</returns>
    ''' <exception cref="FatalIsbInteropException">Исключение при неудачной попытке получить Application.</exception>
    Public Function GetApplication() As IApplication
        If Thread.VolatileRead(Me.configConnectionParams) Is Nothing Then
            SyncLock lockRoot
                If Me.configConnectionParams Is Nothing Then
                    Me.configConnectionParams = GetConnectionParamsSetting()
                End If
            End SyncLock
        End If

        If Me.application Is Nothing Then
            SyncLock lockRoot
                If Me.application Is Nothing Then
                    Me.application = InternalGetNewIsbApplicationEx(Me.configConnectionParams)
                End If
            End SyncLock
        Else
            Try
                Dim id As Integer = Me.application.PID
            Catch ex As Exception
                Throw New FatalIsbInteropException(My.Resources.Resources.CannotGetIsbApplication, ex)
            End Try
        End If

        Return Me.application
    End Function

    ''' <summary>
    ''' Получить новый объект приложения IS-Builder.
    ''' </summary>
    ''' <param name="currentLoginPoint">Точка подключения.</param>
    ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    ''' <param name="connectionParams">Параметры подключения.</param>
    Private Shared Function InternalGetNewIsbApplication(connectionParams As String,
                                                         Optional storeInCache As Boolean = True,
                                                         Optional currentLoginPoint As ILoginPoint = Nothing) As IApplication
        Dim application As IApplication

        Try
            If currentLoginPoint IsNot Nothing Then
                application = currentLoginPoint.GetApplication(connectionParams, storeInCache)
            Else
                Using newloginPoint = LoginPoint.GetLoginPoint()
                    application = newloginPoint.GetApplication(connectionParams, storeInCache)
                End Using
            End If
        Catch ex As Exception
            Throw New FatalIsbInteropException(My.Resources.Resources.CannotGetIsbApplication, ex)
        End Try

        Return application
    End Function


    ''' <summary>
    ''' Получить новый объект приложения IS-Builder.
    ''' </summary>
    ''' <param name="connectionParams">Параметры подключения.</param>
    Private Shared Function InternalGetNewIsbApplicationEx(connectionParams As String) As IApplication
        Dim errorCode As Integer = 0
        Dim application As IApplication

        Try
            Using newloginPoint = LoginPoint.GetLoginPoint()
                application = newloginPoint.GetApplicationEx(connectionParams, errorCode)
            End Using
        Catch ex As Exception
            Throw New FatalIsbInteropException(My.Resources.Resources.CannotGetIsbApplication, ex)
        End Try

        If application Is Nothing Then
            Throw New FatalIsbInteropException(String.Format(My.Resources.Resources.CannotGetIsbApplicationTemplate,
              String.Format(My.Resources.Resources.InternalErrorCodeStringTemplate, errorCode)))
        End If

        Return application
    End Function

    ''' <summary>
    ''' Получить настройку параметров подключения.
    ''' </summary>
    ''' <returns>Строка с параметрами подключения.</returns>
    Private Shared Function GetConnectionParamsSetting() As String
        Dim connectionString = ConfigurationUtils.GetConnectionString()

        Return GetConnectionParams(connectionString)
    End Function

    ''' <summary>
    ''' Получить параметры подключения из строки подключения.
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

#End Region

End Class