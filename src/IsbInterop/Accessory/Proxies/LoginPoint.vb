Imports System.Reflection
Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Proxies
Imports IsbInterop.Utils

' LoginPoint - публичный класс, он должен быть виден из namespace IsbInterop.
' ReSharper disable once CheckNamespace

''' <summary>
''' Обертка над ILoginPoint.
''' </summary>
Public Class LoginPoint
  Inherits BaseIsbObject
  Implements ILoginPoint

#Region "Поля и свойства"

  ''' <summary>
  ''' ИД процесса.
  ''' </summary>
  Public ReadOnly Property PID As Integer Implements ILoginPoint.PID
    Get
      Return GetRcwProperty("PID")
    End Get
  End Property

#End Region

#Region "Методы"

  ''' <summary>
  ''' Получает объект ILoginPoint.
  ''' </summary>
  ''' <returns>ILoginPoint.</returns>
  ''' <exception cref="FatalIsbInteropException">Исключение при неудачной попытке получить LoginPoint.</exception>
  Public Shared Function GetLoginPoint() As ILoginPoint
    Dim comType = Type.GetTypeFromProgID("SBLogon.LoginPoint")
    If comType Is Nothing Then
      Throw New IsbInteropException(String.Format(My.Resources.Resources.UnableToGetObject, "SBLogon.LoginPoint"))
    End If

    Try
      Dim rcwLoginPoint = Activator.CreateInstance(comType)
      Dim loginPoint = New LoginPoint(rcwLoginPoint)

      Return loginPoint
    Catch ex As Exception
      Throw New FatalIsbInteropException(My.Resources.Resources.UnableToGetLoginPoint, ex)
    End Try
  End Function

  ''' <summary>
  ''' Получает объект приложения.
  ''' </summary>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш:
  ''' True, если нужно добавить информацию, иначе False.</param>
  ''' <returns>Объект приложения IApplication, или null.</returns>
  Public Function GetApplication(connectionParams As String, Optional storeInCache As Boolean = True) As IApplication Implements ILoginPoint.GetApplication
    Dim rcwApplication = GetRcwApplication(connectionParams, storeInCache)

    Return If(rcwApplication Is Nothing, Nothing, New Application(rcwApplication, Nothing))
  End Function

  ''' <summary>
  ''' Получить объект приложения.
  ''' </summary>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <param name="errorCode">Код ошибки.</param>
  ''' <returns>Объект приложения IApplication, либо null, если его не удалось получить.</returns>
  Public Function GetApplicationEx(connectionParams As String, ByRef errorCode As Integer) As IApplication Implements ILoginPoint.GetApplicationEx
    Dim rcwApplication = GetRcwApplicationEx(connectionParams, errorCode)

    Return If(rcwApplication Is Nothing, Nothing, New Application(rcwApplication, Nothing))
  End Function

  ''' <summary>
  ''' Получает RCW-объект приложения.
  ''' </summary>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш:
  ''' True, если нужно добавить информацию, иначе False.</param>
  ''' <returns>RCW-объект IApplication.</returns>
  Friend Function GetRcwApplication(connectionParams As String, Optional storeInCache As Boolean = True) As Object
    Dim parameters = New Object() {connectionParams, storeInCache}

    Dim timeout = TimeSpan.FromSeconds(IsbInteropConfiguration.IsbAppCreationTimeout)
    Dim rcwApplication = ComUtils.InvokeRcwInstanceMethod(RcwObject, "GetApplication", parameters, timeout)

    Return rcwApplication
  End Function

  ''' <summary>
  ''' Получить RCW-объект приложения.
  ''' </summary>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <param name="errorCode">Код ошибки.</param>
  ''' <returns>Объект приложения IApplication, либо null, если его не удалось получить.</returns>
  Friend Function GetRcwApplicationEx(connectionParams As String, ByRef errorCode As Integer) As Object
    Const defaultErrorCode As Integer = -1

    Dim parameters = New Object() {connectionParams, defaultErrorCode}

    Dim p = New ParameterModifier(2)
    p(1) = True
    Dim mods As ParameterModifier() = {p}

    Dim timeout = TimeSpan.FromSeconds(IsbInteropConfiguration.IsbAppCreationTimeout)
    Dim rcwApplication = ComUtils.InvokeRcwInstanceMethod(RcwObject, "GetApplication", parameters, mods, timeout)

    errorCode = CInt(parameters(1))

    Return rcwApplication
  End Function

#End Region

#Region "Конструкторы"

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  ''' <param name="rcwLoginPoint">COM-объект LoginPoint.</param>
  Private Sub New(rcwLoginPoint As Object)
    MyBase.New(rcwLoginPoint, Nothing)
  End Sub

#End Region

End Class