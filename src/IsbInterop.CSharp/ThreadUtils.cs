using System;
using System.Threading;

namespace IsbInterop
{
  /// <summary>
  /// Утилиты для работы с потоком выполнения.
  /// </summary>
  public static class ThreadUtils
  {
    // Альтернативный вариант.
    ///// <summary>
    ///// Выполняет функцию с таймаутом.
    ///// </summary>
    ///// <param name="function">Функция.</param>
    ///// <param name="timeout">Таймаут.</param>
    ///// <returns>Результат.</returns>
    //public static object Execute(Func<object> function, TimeSpan timeout)
    //{
    //  object result = null;
    //  var thread = new Thread(() =>
    //  {
    //    result = function();
    //  });

    //  thread.Start();
    //  var completed = thread.Join(timeout);
    //  if (!completed)
    //    throw new TimeoutException(string.Format("The operation has timed out after {0}.", timeout));

    //  return result;
    //}

    /// <summary>
    /// Выполняет функцию с таймаутом.
    /// </summary>
    /// <typeparam name="T">Тип результата функции.</typeparam>
    /// <param name="function">Функция.</param>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>Результат.</returns>
    public static T Invoke<T>(Func<T> function, TimeSpan timeout)
    {
      var functionResult = function.BeginInvoke(null, null);
      var waitHandle = functionResult.AsyncWaitHandle;
      if (!waitHandle.WaitOne(timeout))
      {
        // IMPORTANT: Always call EndInvoke to complete your asynchronous call.
        // http://msdn.microsoft.com/en-us/library/2e08f6yc(VS.80).aspx
        // (even though we arn't interested in the result)

        ThreadPool.UnsafeRegisterWaitForSingleObject(waitHandle,
            (state, timedOut) => function.EndInvoke(functionResult),
            null, -1, true);

        throw new IsbInteropTimoutException($"The operation has timed out after {timeout}.");
      }

      return function.EndInvoke(functionResult);
    }
  }
}
