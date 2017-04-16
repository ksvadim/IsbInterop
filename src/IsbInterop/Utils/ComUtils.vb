Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace Utils

  ''' <summary>
  ''' Утилиты для работы с COM-объектами.
  ''' </summary>
  Public NotInheritable Class ComUtils

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
      Dim timeout = TimeSpan.FromSeconds(IsbInteropConfiguration.IsbMethodExecutionTimeout)
      Return InvokeRcwInstanceMethod(rcwObject, methodName, parameters, timeout)
    End Function

    ''' <summary>
    ''' Вызывает экземплярный метод COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="methodName">Имя метода.</param>
    ''' <param name="parameters">Параметры.</param>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function InvokeRcwInstanceMethod(rcwObject As Object, methodName As String, parameters As Object(), timeout As TimeSpan) As Object
      Dim result As Object = ThreadUtils.Invoke(
        Function()
          Try
            result = rcwObject.[GetType]().InvokeMember(methodName,
                                                        BindingFlags.InvokeMethod Or BindingFlags.Instance Or BindingFlags.[Public],
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
        End Function, timeout)

      Return result
    End Function

    ''' <summary>
    ''' Вызывает экземплярный метод COM-объекта.
    ''' </summary>
    ''' <param name="rcwObject">COM-объект.</param>
    ''' <param name="methodName">Имя метода.</param>
    ''' <param name="parameters">Параметры.</param>
    ''' <param name="modifiers">Атрибуты параметров.</param>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Friend Shared Function InvokeRcwInstanceMethod(rcwObject As Object, methodName As String, parameters As Object(), modifiers As ParameterModifier(), timeout As TimeSpan) As Object
      Dim result As Object = ThreadUtils.Invoke(
        Function()
          Try
            result = rcwObject.[GetType]().InvokeMember(methodName,
                                                        BindingFlags.InvokeMethod Or BindingFlags.Instance Or BindingFlags.[Public],
                                                        Nothing, rcwObject, parameters, modifiers,
              Nothing, Nothing)
          Catch ex As TargetInvocationException
            Dim errorMessage = String.Format(My.Resources.Resources.CannotExecuteObjectMethodTemplate,
                                             methodName, Information.TypeName(rcwObject))

            If TypeOf ex.InnerException Is COMException Then
              Throw New IsbInteropException(errorMessage, ex.InnerException)
            End If

            Throw New IsbInteropException(errorMessage, ex)
          End Try

          Return result
        End Function, timeout)

      Return result
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
        result = rcwObject.[GetType]().InvokeMember(propertyName,
                                                    BindingFlags.GetProperty Or BindingFlags.Instance Or BindingFlags.[Public],
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
        Dim result = rcwObject.[GetType]().InvokeMember(propertyName,
                                                        BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.[Public],
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
    ''' Приватный конструктор.
    ''' </summary>
    Private Sub New()
    End Sub
  End Class
End Namespace