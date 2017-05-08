using IsbInterop.Accessory;
using IsbInterop.Data;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Presentation;

namespace IsbInterop.Base
{
  /// <summary>
  /// Базовый объект.
  /// </summary>
  public interface IObject<out T> : IBaseIsbObject where T : IObjectInfo
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
    /// ИД.
    /// </summary>
    int Id { get; }

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
    IList<TP> GetEnvironment<TP>() where TP : IBaseIsbObject;

    /// <summary>
    /// Получает форму-карточку текущего представления объекта.
    /// </summary>
    /// <returns>Форма-карточка.</returns>
    IForm GetForm();

    /// <summary>
    /// Получает параметры объекта.
    /// </summary>
    /// <typeparam name="TP">Тип параметров.</typeparam>
    /// <returns>Список параметров объекта.</returns>
    IList<TP> GetParams<TP>() where TP : IBaseIsbObject;

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    T GetInfo();

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
