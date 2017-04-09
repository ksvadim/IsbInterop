using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IEdmsObject.
  /// </summary>
  internal abstract class EdmsObject<TI> : IsbObject<TI>, IEdmsObject<TI>
    where TI : IObjectInfo
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
    public void EnterEditMode()
    {
      InvokeRcwInstanceMethod("EnterEditMode");
    }

    /// <summary>
    /// Переводит объект из режима редактирования в режим просмотра.
    /// После выполнения метода объект становится доступным для изменения другим пользователям.
    /// </summary>
    /// <remarks>Метод является системным, использовать его не рекомендуется.
    /// При освобождении объекта метод вызывается автоматически.</remarks>
    public void LeaveEditMode()
    {
      InvokeRcwInstanceMethod("LeaveEditMode");
    }

    /// <summary>
    /// Проверяет возможность редактирования документа.
    /// </summary>
    /// <param name="editMode">Режим редактирования.</param>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <returns>True, если редактирование возможно, иначе false.</returns>
    public bool TryEdit(TEditMode editMode, out string errorMessage)
    {
      var methodParams = new object[] { (int)editMode, null };
      bool canEdit = (bool)this.InvokeRcwInstanceMethod("TryEdit", methodParams);

      if (canEdit)
        errorMessage = string.Empty;
      else
        errorMessage = (string)methodParams[1];

      return canEdit;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIEdmsObject">COM-объект IEdmsObject.</param>
    /// <param name="scope">Область видимости.</param>
    protected EdmsObject(object rcwIEdmsObject, IScope scope) : base(rcwIEdmsObject, scope) { }
  }
}
