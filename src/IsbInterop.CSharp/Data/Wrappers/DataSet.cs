using IsbInterop.DataTypes.Enumerable;
using IsbInterop.References;
using IsbInterop.References.Wrappers;

namespace IsbInterop.Data.Wrappers
{
  /// <summary>
  /// Обертка над IDataSet.
  /// </summary>
  internal class DataSet : Query, IDataSet, IRequisiteAutoCleaner
  {
    #region IDisposable

    private bool disposed = false;

    /// <summary>
    /// Очистка.
    /// </summary>
    /// <param name="disposing">Флаг вызова метода Dispose.</param>
    protected override void Dispose(bool disposing)
    {
      if (this.disposed)
        return;

      if (disposing)
        this.requisiteContainer.DisposeRequisites();

      this.disposed = true;

      base.Dispose(disposing);
    }

    #endregion

    #region IRequisiteAutoCleaner

    /// <summary>
    /// Контейнер реквизитов.
    /// </summary>
    IRequisiteContainer IRequisiteAutoCleaner.RequisiteContainer
    {
      get { return this.requisiteContainer; }
    }
    private readonly RequisiteContainer requisiteContainer = new RequisiteContainer();

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Имя таблицы детального раздела.
    /// </summary>
    public string SqlTableName
    {
      get { return (string)this.GetRcwProperty("SQLTableName"); }
    }

    /// <summary>
    /// Состояние.
    /// </summary>
    public TDataSetState State
    {
      get { return (TDataSetState)this.GetRcwProperty("State"); }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Добавить запись.
    /// </summary>
    public void Append()
    {
      this.InvokeRcwInstanceMethod("Append");
    }

    /// <summary>
    /// Применить изменения.
    /// </summary>
    public void ApplyUpdates()
    {
      this.InvokeRcwInstanceMethod("ApplyUpdates");
    }

    /// <summary>
    /// Закрыть запись.
    /// </summary>
    public void CloseRecord()
    {
      this.InvokeRcwInstanceMethod("CloseRecord");
    }

    /// <summary>
    /// Получить компоненту.
    /// </summary>
    /// <returns>Компонента.</returns>
    public IComponent GetComponent()
    {
      var requisiteRcw = this.GetRcwProperty("Component");
      return new Component(requisiteRcw);
    }

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    public IRequisite GetRequisite(string requisiteName)
    {
      var requisite = this.requisiteContainer.GetRequisite(requisiteName, this.InternalGetRequisite);
      return requisite;
    }

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    private IRequisite InternalGetRequisite(string requisiteName)
    {
      var requisiteRcw = this.GetRcwProperty("Requisites", requisiteName);
      return new Requisite(requisiteRcw);
    }

    /// <summary>
    /// Открыть запись.
    /// </summary>
    public void OpenRecord()
    {
      this.InvokeRcwInstanceMethod("OpenRecord");
    }

    /// <summary>
    /// Обновить детальный раздел.
    /// </summary>
    public void Refresh()
    {
      this.InvokeRcwInstanceMethod("Refresh");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIDataSet">COM-объект IDataSet.</param>
    internal DataSet(object rcwIDataSet) : base(rcwIDataSet) { }

    #endregion
  }
}
