
Imports IsbInterop.Accessory

''' <summary>
''' Менеджер приложения IS-Builder.
''' </summary>
''' <remarks>Кэширует экземпляр IApplication.</remarks>
Friend Class IsbApplicationManager

#Region "Singleton"

  ''' <summary>
  ''' Экземпляр одиночки.
  ''' </summary>
  Public Shared ReadOnly Property Instance As IsbApplicationManager
    Get
      Return _instance.Value
    End Get
  End Property

  Private Shared ReadOnly _instance As New Lazy(Of IsbApplicationManager)(Function() New IsbApplicationManager(), True)

  ''' <summary>
  ''' Приватный конструктор.
  ''' </summary>
  Private Sub New()
  End Sub

#End Region

#Region "Поля и свойства"

  ''' <summary>
  ''' Объект блокировки.
  ''' </summary>
  Private Shared ReadOnly lockRoot As New Object()

  ''' <summary>
  ''' Объект блокировки для получения LoginPoint.
  ''' </summary>
  Private Shared ReadOnly loginPointLocker As New Object()

  ''' <summary>
  ''' Точка подключения.
  ''' </summary>
  Private currentLoginPoint As ILoginPoint

  ''' <summary>
  ''' Признак необходимости обновления текущей точки подключения.
  ''' </summary>
  Private Shared _needUpdateCurrentLoginPoint As Boolean = False

#End Region

#Region "Методы"

  ''' <summary>
  ''' Получить RCW-объект приложения IS-Builder.
  ''' </summary>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
  ''' <returns>RCW-объект приложения.</returns>
  ''' <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
  Friend Function GetRcwApplication(connectionParams As String, storeInCache As Boolean) As Object
    If connectionParams Is Nothing Then
      Throw New ArgumentNullException(NameOf(connectionParams))
    End If

    If currentLoginPoint IsNot Nothing Then
      Try
        Dim id As Integer = currentLoginPoint.PID
      Catch generatedExceptionName As Exception
        Dim lockedHere As Boolean = False

        SyncLock lockRoot
          If Not _needUpdateCurrentLoginPoint Then
            _needUpdateCurrentLoginPoint = True
            lockedHere = True
          End If
        End SyncLock

        If lockedHere Then
          SyncLock loginPointLocker
            currentLoginPoint = LoginPoint.GetLoginPoint()
            _needUpdateCurrentLoginPoint = False
            Return InternalGetNewIsbApplication(connectionParams, storeInCache, DirectCast(currentLoginPoint, LoginPoint))
          End SyncLock
        Else
          SyncLock loginPointLocker
            Return InternalGetNewIsbApplication(connectionParams, storeInCache, currentLoginPoint)
          End SyncLock
        End If
      End Try

      Return InternalGetNewIsbApplication(connectionParams, storeInCache, currentLoginPoint)
    Else
      SyncLock lockRoot
        If currentLoginPoint Is Nothing Then
          currentLoginPoint = LoginPoint.GetLoginPoint()
        End If

        Return InternalGetNewIsbApplication(connectionParams, storeInCache, currentLoginPoint)
      End SyncLock
    End If
  End Function

  ''' <summary>
  ''' Получить новый объект приложения IS-Builder.
  ''' </summary>
  ''' <param name="currentLoginPoint">Текущая точка подключения.</param>
  ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
  ''' <param name="connectionParams">Параметры подключения.</param>
  ''' <returns>RCW-объект IAppliction.</returns>
  Private Shared Function InternalGetNewIsbApplication(connectionParams As String, storeInCache As Boolean, currentLoginPoint As ILoginPoint) As Object
    Dim errorCode As Integer = 0
    Dim rcwApplication As Object

    Try
      rcwApplication = If(storeInCache,
        DirectCast(currentLoginPoint, LoginPoint).GetRcwApplication(connectionParams),
        DirectCast(currentLoginPoint, LoginPoint).GetRcwApplicationEx(connectionParams, errorCode))
    Catch ex As Exception
      Throw New FatalIsbInteropException(My.Resources.Resources.CannotGetIsbApplication, ex)
    End Try

    If rcwApplication Is Nothing Then
      If storeInCache Then
        Throw New FatalIsbInteropException(My.Resources.Resources.CannotGetIsbApplication)
      Else
        Throw New FatalIsbInteropException(String.Format(My.Resources.Resources.CannotGetIsbApplicationTemplate,
                                                         String.Format(My.Resources.Resources.InternalErrorCodeStringTemplate, errorCode)))
      End If
    End If

    Return rcwApplication
  End Function

#End Region

End Class
