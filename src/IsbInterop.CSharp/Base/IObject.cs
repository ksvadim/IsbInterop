using IsbInterop.Data;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Presentation;

namespace IsbInterop.Base
{
  /// <summary>
  /// Базовый объект.
  /// </summary>
  public interface IObject<out T> : IIsbComObjectWrapper where T : IObjectInfo
  {
    /// <summary>
    /// Признак открытости набора данных.
    /// </summary>
    bool Active { get; }
    
    /// <summary>
    /// ИД объекта.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Имя объекта.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Имя таблицы объекта.
    /// </summary>
    string SqlTableName { get; }

    /// <summary>
    /// Состояние.
    /// </summary>
    TDataSetState State { get; }

    /// <summary>
    /// Тип объекта системы.
    /// </summary>
    TCompType ComponentType { get; }

    /// <summary>
    /// Добавить условие ограничения в запрос набора данных.
    /// </summary>
    /// <param name="condition">Условие ограничения выборки.</param>
    /// <returns>Идентификатор условия в запросе.</returns>
    int AddWhere(string condition);

    /// <summary>
    /// Удалить условие ограничения набора данных.
    /// </summary>
    /// <param name="conditionId">Идентификатор условия в запросе, полученный при вызове метода AddWhere.</param>
    void DelWhere(int conditionId);

    /// <summary>
    /// Получить детальный раздел.
    /// </summary>
    /// <param name="dataSetNumber">Номер детального раздела.</param>
    /// <returns>Детальный раздел.</returns>
    IDataSet GetDetailDataSet(int dataSetNumber);

    /// <summary>
    /// Получить форму-карточку текущего представления объекта.
    /// </summary>
    /// <returns>Форма-карточка.</returns>
    IForm GetForm();

    /// <summary>
    /// Получить информацию об объекте.
    /// </summary>
    /// <returns>Info-объект.</returns>
    T GetInfo();

    /// <summary>
    /// Получить реквизит набора данных.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    IRequisite GetRequisite(string requisiteName);

    /// <summary>
    /// Обновить набор данных.
    /// </summary>
    void Refresh();

    /// <summary>
    /// Завершить работу с объектом.
    /// </summary>
    void DoFinalize();

    /// <summary>
    /// Сохранить объект.
    /// </summary>
    void Save();
  }
}
