using IsbInterop.Accessory;
using IsbInterop.Collections;

namespace IsbInterop.Presentation
{
  /// <summary>
  /// Список действий.
  /// </summary>
  public interface IActionList : IList<IAction>
  {
    /// <summary>
    /// Получает действие по имени.
    /// </summary>
    /// <param name="name">Имя действия.</param>
    /// <returns>Действие из списка с именем name, если оно существует, иначе null.</returns>
    IAction FindAction(string name);
  }
}
