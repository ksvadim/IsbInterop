using System;

namespace IsbInterop.Presentation.Wrappers
{
  /// <summary>
  /// Обертка над IAction.
  /// </summary>
  internal class Action : IsbComObjectWrapper, IAction
  {
    /// <summary>
    /// Выполнить действие.
    /// </summary>
    /// <returns>True, если действие было выполнено, иначе false.</returns>
    public bool Execute()
    {
      var result = (bool)this.InvokeRcwInstanceMethod("Execute", null, null);
      return result;
    }

    /// <summary>
    /// Выполнить действие.
    /// </summary>
    /// <param name="timeout">Таймаут.</param>
    /// <returns>True, если действие было выполнено, иначе false.</returns>
    public bool Execute(TimeSpan timeout)
    {
      var result = (bool)this.InvokeRcwInstanceMethod("Execute", null, timeout);
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
