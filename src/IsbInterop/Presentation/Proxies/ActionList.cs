using IsbInterop.Accessory.Proxies;
using IsbInterop.Collections.Proxies;

namespace IsbInterop.Presentation.Proxies
{
  /// <summary>
  /// Обертка над IActionList.
  /// </summary>
  internal class ActionList : List<IAction>, IActionList
  {
    /// <summary>
    /// Получает действие по имени.
    /// </summary>
    /// <param name="name">Имя действия.</param>
    /// <returns>Действие из списка с именем name, если оно существует, иначе null.</returns>
    public IAction FindAction(string name)
    {
      var actionRcw = InvokeRcwInstanceMethod("FindAction", name);
      return actionRcw != null ? new Action(actionRcw, Scope) : null;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIActionList">COM-объект IActionList.</param>
    /// <param name="scope">Область видимости.</param>
    public ActionList(object rcwIActionList, IScope scope) : base(rcwIActionList, scope) { }
  }
}
