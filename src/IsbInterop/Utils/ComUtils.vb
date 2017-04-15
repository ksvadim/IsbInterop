Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace Utils

  ''' <summary>
  ''' Утилиты для работы с COM-объектами.
  ''' </summary>
  Public NotInheritable Class ComUtils
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Таймаут выполнения COM-метода по умолчанию, секунд.
    ''' </summary>
    Private Const DefaultComMethodExecutionTimeout As Integer = 60

    ''' <summary>
    ''' Таймаут выполнения COM-метода, секунд.
    ''' </summary>
    Private Shared ReadOnly comMethodExecutionTimeout As New Lazy(Of Integer)(AddressOf GetComMethodExecutionTimeoutValue, True)

    ''' <summary>
    ''' Вызывает экземплярный метод COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="methodName">Имя метода.</param>
    ''' <param name="parameter">Параметр.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function InvokeRcwInstanceMethod(rcwObject As Object, methodName As String, parameter As Object) As Object
      Return InvokeRcwInstanceMethod(rcwObject, methodName, New Object() {parameter})
    End Function

    ''' <summary>
    ''' Вызывает экземплярный метод COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="methodName">Имя метода.</param>
    ''' <param name="parameters">Параметры.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function InvokeRcwInstanceMethod(rcwObject As Object, methodName As String, Optional parameters As Object() = Nothing) As Object
      Dim result As Object = ThreadUtils.Invoke(Function()
        Try
          result = rcwObject.[GetType]().InvokeMember(methodName, BindingFlags.InvokeMethod Or BindingFlags.Instance Or BindingFlags.[Public],
                                                      Nothing, rcwObject, parameters)
        Catch ex As TargetInvocationException
          Dim errorMessage = String.Format(My.Resources.Resources.CannotExecuteObjectMethodTemplate,
                                           methodName, Information.TypeName(rcwObject))

          If TypeOf ex.InnerException Is COMException Then
            Throw New IsbInteropException(errorMessage, ex.InnerException)
                                                 End If

          Throw New IsbInteropException(errorMessage, ex)
                                                 End Try

        Return result

                                                 End Function, TimeSpan.FromSeconds(comMethodExecutionTimeout.Value))

      Return result
    End Function

    ''' <summary>
    ''' Вызывает экземплярный метод COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="methodName">Имя метода.</param>
    ''' <param name="parameters">Параметры.</param>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function InvokeRcwInstanceMethod(rcwObject As Object, methodName As String, parameters As Object(), timeout As TimeSpan?) As Object
      Dim func As Func(Of Object) = Function()
        Dim result As Object
        Try
          result = rcwObject.[GetType]().InvokeMember(methodName, BindingFlags.InvokeMethod Or BindingFlags.Instance Or BindingFlags.[Public], 
                                                      Nothing, rcwObject, parameters)
        Catch ex As TargetInvocationException
          Dim errorMessage = String.Format(My.Resources.Resources.CannotExecuteObjectMethodTemplate,
                                           methodName, Information.TypeName(rcwObject))

          If TypeOf ex.InnerException Is COMException Then
            Throw New IsbInteropException(errorMessage, ex.InnerException)
            End If

          Throw New IsbInteropException(errorMessage, ex)
            End Try

        Return result

            End Function

      Dim methodResult = If(timeout IsNot Nothing, ThreadUtils.Invoke(func, timeout.Value), func.Invoke())

      Return methodResult
    End Function

    ''' <summary>
    ''' Получает свойство COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="propertyName">Имя свойства.</param>
    ''' <param name="parameter">Параметр.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function GetRcwProperty(rcwObject As Object, propertyName As String, parameter As Object) As Object
      Return GetRcwProperty(rcwObject, propertyName, New Object() {parameter})
    End Function

    ''' <summary>
    ''' Получает свойство COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="propertyName">Имя свойства.</param>
    ''' <param name="parameters">Параметры.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function GetRcwProperty(rcwObject As Object, propertyName As String, Optional parameters As Object() = Nothing) As Object
      Dim result As Object

      Try
        result = rcwObject.[GetType]().InvokeMember(propertyName, BindingFlags.GetProperty Or BindingFlags.Instance Or BindingFlags.[Public],
                                                    Nothing, rcwObject, parameters)
      Catch ex As TargetInvocationException
        Dim errorMessage = String.Format(My.Resources.Resources.CannotGetObjectProperyTemplate, propertyName, Information.TypeName(rcwObject))

        If TypeOf ex.InnerException Is COMException Then
          Throw New IsbInteropException(errorMessage, ex.InnerException)
        End If

        Throw New IsbInteropException(errorMessage, ex)
      End Try

      Return result
    End Function

    ''' <summary>
    ''' Устанавливает свойство COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="propertyName">Имя свойства.</param>
    ''' <param name="value">Значение.</param>
    Public Shared Sub SetRcwProperty(rcwObject As Object, propertyName As String, value As Object)
      Try
        Dim result = rcwObject.[GetType]().InvokeMember(propertyName, BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.[Public],
                                                        Nothing, rcwObject, New Object() {value})
      Catch ex As TargetInvocationException
        Dim errorMessage = String.Format(My.Resources.Resources.CannotSetObjectProperyTemplate, propertyName, Information.TypeName(rcwObject))

        If TypeOf ex.InnerException Is COMException Then
          Throw New IsbInteropException(errorMessage, ex.InnerException)
        End If

        Throw New IsbInteropException(errorMessage, ex)
      End Try
    End Sub

    ''' <summary>
    ''' Получает значение таймаута выполнения COM-метода.
    ''' </summary>
    ''' <returns>Таймаут в секундах.</returns>
    Private Shared Function GetComMethodExecutionTimeoutValue() As Integer
      Dim timeout As Integer = DefaultComMethodExecutionTimeout

      If ConfigurationUtils.TryGetAppSetting("IsbInteropTimeout", timeout) Then
        If timeout <= 0 Then
          timeout = DefaultComMethodExecutionTimeout
        End If
      End If

      Return timeout
    End Function
  End Class
End NameSpace