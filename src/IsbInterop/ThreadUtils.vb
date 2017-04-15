Imports System.Threading

''' <summary>
'''Утилиты для работы с потоком выполнения.
''' </summary>
Public NotInheritable Class ThreadUtils

    ''' <summary>
    ''' Выполняет функцию с таймаутом.
    ''' </summary>
    ''' <typeparam name="T">Тип результата функции.</typeparam>
    ''' <param name="function">Функция.</param>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Public Shared Function Invoke(Of T)([function] As Func(Of T), timeout As TimeSpan) As T
        Dim functionResult = [function].BeginInvoke(Nothing, Nothing)
        Dim waitHandle = functionResult.AsyncWaitHandle
        If Not waitHandle.WaitOne(timeout) Then
            ' IMPORTANT: Always call EndInvoke to complete your asynchronous call.
            ' http://msdn.microsoft.com/en-us/library/2e08f6yc(VS.80).aspx
            ' (even though we arn't interested in the result)

            ThreadPool.UnsafeRegisterWaitForSingleObject(waitHandle, Function(state, timedOut) [function].EndInvoke(functionResult), Nothing, -1, True)

            Throw New IsbInteropTimeoutException(String.Format("The operation has timed out after {0}.", timeout))
        End If

        Return [function].EndInvoke(functionResult)
    End Function

    ''' <summary>
    ''' Приватный конструктор.
    ''' </summary>
    Private Sub New()
    End Sub
End Class
