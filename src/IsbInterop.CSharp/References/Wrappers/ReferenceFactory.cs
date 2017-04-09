using IsbInterop.Base.Wrappers;
using IsbInterop.Properties;

namespace IsbInterop.References.Wrappers
{
  /// <summary>
  /// Обертка над IReferenceFactory.
  /// </summary>
  internal class ReferenceFactory : Factory<IReference, IReferenceInfo>, IReferenceFactory
  {
    #region Поля и свойства

    /// <summary>
    /// Получить имя фабрики.
    /// </summary>
    public string Name
    {
      get { return (string)this.GetRcwProperty("Name"); }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Создать запись справочника.
    /// </summary>
    /// <returns>Запись справочника.</returns>
    public IReference CreateNew()
    {
      var rcwReferenceEntry = this.InvokeRcwInstanceMethod("CreateNew");
      return new Reference(rcwReferenceEntry, this.Scope);
    }

    /// <summary>
    /// Получить историю записи справочника.
    /// Возвращает компоненту История работы с записью для записи справочника. 
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект IComponent.</returns>
    public IComponent GetHistory(int id)
    {
      var rcwComponent = this.GetRcwProperty("History", id);
      return new Component(rcwComponent, this.Scope);
    }

    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IReference GetObjectById(int id)
    {
      var rcwObject = this.GetRcwObjectById(id);

      return new Reference(rcwObject, this.Scope);
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
    /// Удалить запись справочника по ИД.
    /// </summary>
    /// <param name="id">ИД записи справочника.</param>
    public void DeleteById(int id)
    {
      this.InvokeRcwInstanceMethod("DeleteById", id);
    }

    /// <summary>
    /// Получить компоненту справочника.
    /// </summary>
    /// <returns>Компонента справочника.</returns>
    public IReference GetComponent()
    {
      var rcwReference = this.InvokeRcwInstanceMethod("GetComponent");
      return new Reference(rcwReference, this.Scope);
    }

    /// <summary>
    /// Получить запись справочника по коду.
    /// </summary>
    /// <param name="referenceEntryCode">Код записи справочника.</param>
    /// <returns>Запись справочника.</returns>
    public IReference GetObjectByCode(string referenceEntryCode)
    {
      var rcwReferenceEntry = this.InvokeRcwInstanceMethod("GetObjectByCode", referenceEntryCode);
      return new Reference(rcwReferenceEntry, this.Scope);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIReferenceFactory">COM-объект IReferenceFactory.</param>
    /// <param name="scope">Область видимости.</param>
    internal ReferenceFactory(object rcwIReferenceFactory, IScope scope) : base(rcwIReferenceFactory, scope) { }

    #endregion
  }
}
