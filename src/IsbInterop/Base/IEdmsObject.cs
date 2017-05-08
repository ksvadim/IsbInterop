using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Base
{
  /// <summary>
  /// Базовый объект ЭДО.
  /// </summary>
  public interface IEdmsObject<out TI> : IObject<TI> where TI : IObjectInfo
  {
    /// <summary>
    /// Переводит объект в режим редактирования.
    /// При этом объект блокируется от изменений другими пользователями.
    /// Если объект уже заблокирован, то будет сгенерировано исключение.
    /// </summary>
    /// <remarks>
    /// Метод является системным, использовать его не рекомендуется.
    /// При обращении к объекту метод вызывается автоматически.
    /// </remarks>
    void EnterEditMode();

    /// <summary>
    /// Переводит объект из режима редактирования в режим просмотра.
    /// После выполнения метода объект становится доступным для изменения другим пользователям.
    /// </summary>
    /// <remarks>Метод является системным, использовать его не рекомендуется.
    /// При освобождении объекта метод вызывается автоматически.</remarks>
    void LeaveEditMode();

    /// <summary>
    /// Проверяет возможность редактирования документа.
    /// </summary>
    /// <param name="editMode">Режим редактирования.</param>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <returns>True, если редактирование возможно, иначе false.</returns>
    bool TryEdit(TEditMode editMode, out string errorMessage);
  }
}
