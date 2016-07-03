using IsbInterop.Data;
using IsbInterop.Data.Wrappers;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Presentation;
using IsbInterop.Presentation.Wrappers;
using IsbInterop.Properties;

namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IObject.
  /// </summary>
  internal abstract class IsbObject<TI> : IsbComObjectWrapper, IObject<TI>
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
    //  if (this.disposed)
    //    return;

    //  if (disposing)
    //  {
    //    if (this.RcwObject != null)
    //      this.DoFinalize();
    //  }

    //  this.disposed = true;

    //  base.Dispose(disposing);
    //}

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Признак открытости набора данных.
    /// </summary>
    public bool Active
    {
      get { return (bool) this.GetRcwProperty("Active"); }
    }

    /// <summary>
    /// ИД объекта.
    /// </summary>
    public int Id
    {
      get { return (int) this.GetRcwProperty("ID"); }
    }

    /// <summary>
    /// Имя объекта.
    /// </summary>
    public string Name
    {
      get { return (string) this.GetRcwProperty("Name"); }
    }

    /// <summary>
    /// Состояние.
    /// </summary>
    public TDataSetState State
    {
      get { return (TDataSetState) this.GetRcwProperty("State"); }
    }

    /// <summary>
    /// Тип объекта.
    /// </summary>
    public TCompType ComponentType
    {
      get { return (TCompType) this.GetRcwProperty("ComponentType"); }
    }

    /// <summary>
    /// Имя таблицы объекта.
    /// </summary>
    public string SqlTableName
    {
      get { return (string) this.GetRcwProperty("SQLTableName"); }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Добавить условие Where к запросу.
    /// </summary>
    /// <param name="queryWhereSection">Секция where запроса.</param>
    /// <returns>ИД условия в запросе.</returns>
    public int AddWhere(string queryWhereSection)
    {
      return (int) this.InvokeRcwInstanceMethod("AddWhere", queryWhereSection);
    }

    /// <summary>
    /// Удалить ограничение из запроса.
    /// </summary>
    /// <param name="queryConditionId">ИД условия в запросе.</param>
    public void DelWhere(int queryConditionId)
    {
      this.InvokeRcwInstanceMethod("DelWhere", queryConditionId);
    }

    /// <summary>
    /// Завершить работу с объектом.
    /// </summary>
    public void DoFinalize()
    {
      // Для записей справочников, записей DataSet: если внутри using изменили запись и свалился наш код с исключением,
      // то Finalize пытается закрыть запись, но закрыть несохраненную запись нельзя.
      // Клиентский код должен корректно обрабатывать такие ситуации.
      this.InvokeRcwInstanceMethod("Finalize");
    }

    /// <summary>
    /// Получить детальный раздел.
    /// </summary>
    /// <param name="dataSetNumber">Номер детального раздела.</param>
    /// <returns>Детальный раздел.</returns>
    public IDataSet GetDetailDataSet(int dataSetNumber)
    {
      var rcwDataSet = this.InvokeRcwInstanceMethod("DetailDataSet", dataSetNumber);

      return new DataSet(rcwDataSet);
    }

    /// <summary>
    /// Получить форму-карточку текущего представления объекта.
    /// </summary>
    /// <returns>Форма-карточка.</returns>
    public IForm GetForm()
    {
      var rcwForm = this.GetRcwProperty("Form");
      return new Form(rcwForm);
    }

    /// <summary>
    /// Получить IObjectInfo.
    /// </summary>
    /// <returns>IObjectInfo.</returns>
    public abstract TI GetInfo();

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    /// <remarks>Умышленно делаем метод виртуальным, чтобы использовать вместе с IRequisiteAutoCleaner.</remarks>
    public virtual IRequisite GetRequisite(string requisiteName)
    {
      var rcwRequisite = this.GetRcwProperty("Requisites", requisiteName);
      return DerivedRequisiteFactory.CreateRequisite(rcwRequisite);
    }

    /// <summary>
    /// Обновить набор данных.
    /// </summary>
    public void Refresh()
    {
      this.InvokeRcwInstanceMethod("Refresh");
    }

    /// <summary>
    /// Сохранить объект.
    /// </summary>
    public void Save()
    {
      this.InvokeRcwInstanceMethod("Save");
    }

    /// <summary>
    /// Получить COM-объект IObjectInfo.
    /// </summary>
    /// <returns>COM-объект IObjectInfo.</returns>
    protected object GetRcwObjectInfo()
    {
      return this.GetRcwProperty("Info");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="externalObject">Внешний объект.</param>
    protected IsbObject(object externalObject) : base(externalObject) { }

    #endregion
  }
}
