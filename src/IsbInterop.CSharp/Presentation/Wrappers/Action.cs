using System;

namespace IsbInterop.Presentation.Wrappers
{
  /// <summary>
  /// Обертка над IAction.
  /// </summary>
  internal class Action : BaseIsbObject, IAction
  {
    /// <summary>
    /// Выполняет действие.
    /// </summary>
    /// <returns>True, если действие было выполнено, иначе false.</returns>
    public bool Execute()
    {
      var result = (bool)InvokeRcwInstanceMethod("Execute", null, null);
      return result;
    }

    /// <summary>
    /// Выполняет действие.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>True, если действие было выполнено, иначе false.</returns>
    public bool Execute(TimeSpan timeout)
    {
      var result = (bool)InvokeRcwInstanceMethod("Execute", null, timeout);
      return result;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIForm">СOM-объект IAction.</param>
    /// <param name="scope">Область видимости.</param>
    public Action(object rcwIForm, IScope scope) : base(rcwIForm, scope) { }
  }
}
