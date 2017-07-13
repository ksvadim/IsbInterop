using IsbInterop.Base.Proxies;

namespace IsbInterop.References.Proxies
{
  /// <summary>
  /// Обертка над IReferenceFactory.
  /// </summary>
  internal class ReferenceFactory : Factory<IReference, IReferenceInfo>, IReferenceFactory
  {
    #region Поля и свойства

    /// <summary>
    /// Имя фабрики.
    /// </summary>
    public string Name => (string)GetRcwProperty("Name");

    #endregion

    #region Методы

    /// <summary>
    /// Создает запись справочника.
    /// </summary>
    /// <returns>Запись справочника.</returns>
    public IReference CreateNew()
    {
      var rcwReferenceEntry = InvokeRcwInstanceMethod("CreateNew");
      return new Reference(rcwReferenceEntry, Scope);
    }

    /// <summary>
    /// Получает историю записи справочника.
    /// Возвращает компоненту История работы с записью для записи справочника. 
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект IComponent.</returns>
    public IComponent GetHistory(int id)
    {
      var rcwComponent = GetRcwProperty("History", id);
      return new Component(rcwComponent, Scope);
    }

    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IReference GetObjectById(int id)
    {
      var rcwObject = GetRcwObjectById(id);

      return new Reference(rcwObject, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IReferenceInfo GetObjectInfo(int id)
    {
      var rcwIEdocumentInfo = GetRcwObjectInfo(id);
      return new ReferenceInfo(rcwIEdocumentInfo, Scope);
    }

    /// <summary>
    /// Удаляет запись справочника по ИД.
    /// </summary>
    /// <param name="id">ИД записи справочника.</param>
    public void DeleteById(int id)
    {
      InvokeRcwInstanceMethod("DeleteById", id);
    }

    /// <summary>
    /// Получает компоненту справочника.
    /// </summary>
    /// <returns>Компонента справочника.</returns>
    public IReference GetComponent()
    {
      var rcwReference = InvokeRcwInstanceMethod("GetComponent");
      return new Reference(rcwReference, Scope);
    }

    /// <summary>
    /// Получает запись справочника по коду.
    /// </summary>
    /// <param name="referenceEntryCode">Код записи справочника.</param>
    /// <returns>Запись справочника.</returns>
    public IReference GetObjectByCode(string referenceEntryCode)
    {
      var rcwReferenceEntry = InvokeRcwInstanceMethod("GetObjectByCode", referenceEntryCode);
      return new Reference(rcwReferenceEntry, Scope);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIReferenceFactory">COM-объект IReferenceFactory.</param>
    /// <param name="scope">Область видимости.</param>
    internal ReferenceFactory(object rcwIReferenceFactory, IScope scope)
      : base(rcwIReferenceFactory, scope) { }

    #endregion
  }
}
