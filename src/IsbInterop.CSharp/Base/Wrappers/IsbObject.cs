using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;
using IsbInterop.Data;
using IsbInterop.Data.Wrappers;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Presentation;
using IsbInterop.Presentation.Wrappers;

namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IObject.
  /// </summary>
  internal abstract class IsbObject<TI> : BaseIsbObject, IObject<TI>
    where TI : IObjectInfo
  {
    #region IDisposable

    //private bool disposed = false;

    //// TODO ksvadim: Лучше вызывать метод Finalize явно, где это нужно (например при освобождении документа).
    //// Если показать форму-список через ComponentShow и затем сразу вызывается Finalize у IComponent, то возникает ошибка.
    ///// <summary>
    ///// Освободить объект.
    ///// </summary>
    ///// <param name="disposing">Признак, что метод Dispose вызван явно.</param>
    //protected override void Dispose(bool disposing)
    //{
    //  if (disposed)
    //    return;

    //  if (disposing)
    //  {
    //    if (RcwObject != null)
    //      DoFinalize();
    //  }

    //  disposed = true;

    //  base.Dispose(disposing);
    //}

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Признак открытости набора данных.
    /// </summary>
    public bool Active => (bool)GetRcwProperty("Active");

    /// <summary>
    /// Тип объекта.
    /// </summary>
    public TCompType ComponentType => (TCompType)GetRcwProperty("ComponentType");

    /// <summary>
    /// ИД.
    /// </summary>
    public int Id => (int)GetRcwProperty("ID");

    /// <summary>
    /// Имя объекта.
    /// </summary>
    public string Name => (string)GetRcwProperty("Name");

    /// <summary>
    /// Имя таблицы в базе данных.
    /// </summary>
    public string SqlTableName => (string)GetRcwProperty("SQLTableName");

    /// <summary>
    /// Состояние набора данных.
    /// </summary>
    public TDataSetState State => (TDataSetState)GetRcwProperty("State");

    #endregion

    #region Методы

    /// <summary>
    /// Добавляет условие ограничения в запрос набора данных.
    /// </summary>
    /// <param name="queryWhereSection">Секция where запроса.</param>
    /// <returns>ИД условия в запросе.</returns>
    public int AddWhere(string queryWhereSection)
    {
      return (int)InvokeRcwInstanceMethod("AddWhere", queryWhereSection);
    }

    /// <summary>
    /// Удаляет условие ограничения набора данных.
    /// </summary>
    /// <param name="queryConditionId">ИД условия в запросе.</param>
    public void DelWhere(int queryConditionId)
    {
      InvokeRcwInstanceMethod("DelWhere", queryConditionId);
    }

    /// <summary>
    /// Завершает работу с объектом.
    /// </summary>
    public void DoFinalize()
    {
      // Для записей справочников, записей DataSet: если внутри using изменили запись и свалился наш код с исключением,
      // то Finalize пытается закрыть запись, но закрыть несохраненную запись нельзя.
      // Клиентский код должен корректно обрабатывать такие ситуации.
      InvokeRcwInstanceMethod("Finalize");
    }

    /// <summary>
    /// Получает детальный раздел набора данных.
    /// </summary>
    /// <param name="dataSetNumber">Номер детального раздела.</param>
    /// <returns>Детальный раздел.</returns>
    public IDataSet GetDetailDataSet(int dataSetNumber)
    {
      var rcwDataSet = InvokeRcwInstanceMethod("DetailDataSet", dataSetNumber);
      return new DataSet(rcwDataSet, Scope);
    }

    /// <summary>
    /// Получает окружение.
    /// </summary>
    /// <typeparam name="TP">Тип параметров.</typeparam>
    /// <returns>Список переменных окружения объекта.</returns>
    public IList<TP> GetEnvironment<TP>() where TP : IBaseIsbObject
    {
      var rcwEnvironment = GetRcwProperty("Environment");
      return new List<TP>(rcwEnvironment, Scope);
    }

    /// <summary>
    /// Получает форму-карточку текущего представления объекта.
    /// </summary>
    /// <returns>Форма-карточка.</returns>
    public IForm GetForm()
    {
      var rcwForm = GetRcwProperty("Form");
      return new Form(rcwForm, Scope);
    }

    /// <summary>
    /// Получает параметры объекта.
    /// </summary>
    /// <typeparam name="TP">Тип параметра.</typeparam>
    /// <returns>Список параметров объекта.</returns>
    public IList<TP> GetParams<TP>() where TP : IBaseIsbObject
    {
      var rcwParams = GetRcwProperty("Params");
      return new List<TP>(rcwParams, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public abstract TI GetInfo();

    /// <summary>
    /// Получает реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    /// <remarks>Умышленно делаем метод виртуальным, чтобы использовать вместе с IRequisiteAutoCleaner.</remarks>
    public IRequisite GetRequisite(string requisiteName)
    {
      var rcwRequisite = GetRcwProperty("Requisites", requisiteName);
      return DerivedRequisiteFactory.CreateRequisite(rcwRequisite, Scope);
    }

    /// <summary>
    /// Обновить набор данных.
    /// </summary>
    public void Refresh()
    {
      InvokeRcwInstanceMethod("Refresh");
    }

    /// <summary>
    /// Сохраняет объект.
    /// </summary>
    public void Save()
    {
      InvokeRcwInstanceMethod("Save");
    }

    /// <summary>
    /// Получить COM-объект IObjectInfo.
    /// </summary>
    /// <returns>COM-объект IObjectInfo.</returns>
    protected object GetRcwObjectInfo()
    {
      return GetRcwProperty("Info");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="externalObject">Внешний объект.</param>
    /// <param name="scope">Область видимости.</param>
    protected IsbObject(object externalObject, IScope scope) : base(externalObject, scope) { }

    #endregion
  }
}
