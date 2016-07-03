using IsbInterop.Base;

namespace IsbInterop.References
{
  /// <summary>
  /// Фабрика справочников.
  /// </summary>
  public interface IReferenceFactory : IFactory<IReference, IReferenceInfo>
  {
    /// <summary>
    /// Получить имя фабрики.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Получить историю записи справочника.
    /// Возвращает компоненту История работы с записью для записи справочника. 
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект IComponent.</returns>
    IComponent GetHistory(int id);

    /// <summary>
    /// Создать запись справочника.
    /// </summary>
    /// <returns>Запись справочника.</returns>
    /// <remarks>
    /// Результатом метода является объект IReference, 
    /// набор данных которого содержит одну новую запись и находится в режиме вставки. 
    /// Метод инициирует процессы открытия справочника и добавления записи справочника.
    /// После заполнения реквизитов следует либо сохранить изменения методами IObject.Save, IDataSet.ApplyUpdates,
    /// либо откатить методами IObject.Cancel, IDataSet.CancelUpdates.
    ///</remarks>
    IReference CreateNew();

    /// <summary>
    /// Удалить запись справочника по ИД.
    /// </summary>
    /// <param name="id">ИД записи справочника.</param>
    void DeleteById(int id);

    /// <summary>
    /// Получить компоненту справочника.
    /// </summary>
    /// <returns>Компонента справочника.</returns>
    IReference GetComponent();

    /// <summary>
    /// Получить объект по коду.
    /// </summary>
    /// <param name="code">Код.</param>
    /// <returns>Объект.</returns>
    IReference GetObjectByCode(string code);
  }
}
