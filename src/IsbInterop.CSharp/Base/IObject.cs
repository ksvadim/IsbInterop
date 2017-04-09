using IsbInterop.Accessory;
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
    /// Тип объекта системы.
    /// </summary>
    TCompType ComponentType { get; }

    /// <summary>
    /// Форма-карточка текущего представления объекта.
    /// </summary>
    IForm Form { get; }

    /// <summary>
    /// ИД.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Информация об объекте.
    /// </summary>
    T Info { get; }

    /// <summary>
    /// Имя объекта.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Имя таблицы в базе данных.
    /// </summary>
    string SqlTableName { get; }

    /// <summary>
    /// Состояние набора данных.
    /// </summary>
    TDataSetState State { get; }

    /// <summary>
    /// Добавляет условие ограничения в запрос набора данных.
    /// </summary>
    /// <param name="condition">Условие ограничения выборки.</param>
    /// <returns>Идентификатор условия в запросе.</returns>
    int AddWhere(string condition);

    /// <summary>
    /// Удаляет условие ограничения набора данных.
    /// </summary>
    /// <param name="conditionId">Идентификатор условия в запросе, полученный при вызове метода AddWhere.</param>
    void DelWhere(int conditionId);

    /// <summary>
    /// Завершает работу с объектом.
    /// </summary>
    void DoFinalize();

    /// <summary>
    /// Получает детальный раздел набора данных.
    /// </summary>
    /// <param name="dataSetNumber">Номер детального раздела.</param>
    /// <returns>Детальный раздел.</returns>
    IDataSet GetDetailDataSet(int dataSetNumber);

    /// <summary>
    /// Получает окружение.
    /// </summary>
    /// <typeparam name="TP">Тип параметров.</typeparam>
    /// <returns>Список переменных окружения объекта.</returns>
    IList<TP> GetEnvironment<TP>() where TP : IIsbComObjectWrapper;

    /// <summary>
    /// Получает параметры объекта.
    /// </summary>
    /// <typeparam name="TP">Тип параметров.</typeparam>
    /// <returns>Список параметров объекта.</returns>
    IList<TP> GetParams<TP>() where TP : IIsbComObjectWrapper;

    /// <summary>
    /// Получает реквизит набора данных.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    IRequisite GetRequisite(string requisiteName);

    /// <summary>
    /// Обновляет набор данных.
    /// </summary>
    void Refresh();

    /// <summary>
    /// Сохраняет объект.
    /// </summary>
    void Save();
  }
}
