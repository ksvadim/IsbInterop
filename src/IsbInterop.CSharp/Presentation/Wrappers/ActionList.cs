using IsbInterop.Accessory.Wrappers;

namespace IsbInterop.Presentation.Wrappers
{
  /// <summary>
  /// Обертка над IActionList.
  /// </summary>
  internal class ActionList : List<IAction>, IActionList
  {
    /// <summary>
    /// Получить действие по имени.
    /// </summary>
    /// <param name="name">Имя действия.</param>
    /// <returns>Действие из списка с именем name, если оно существует, иначе null.</returns>
    public IAction FindAction(string name)
    {
      var actionRcw = this.InvokeRcwInstanceMethod("FindAction", name);
      return actionRcw != null ? new Action(actionRcw, this.Scope) : null;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIActionList">COM-объект IActionList.</param>
    /// <param name="scope">Область видимости.</param>
    public ActionList(object rcwIActionList, IScope scope) : base(rcwIActionList, scope) { }
  }
}
