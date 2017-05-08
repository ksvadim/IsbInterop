using IsbInterop.DataTypes.Enumerable;
using IsbInterop.References;
using IsbInterop.References.Proxies;

namespace IsbInterop.Data.Proxies
{
  /// <summary>
  /// Обертка над IDataSet.
  /// </summary>
  internal class DataSet : Query, IDataSet
  {
    #region Поля и свойства

    /// <summary>
    /// Имя таблицы детального раздела.
    /// </summary>
    public string SqlTableName => (string)GetRcwProperty("SQLTableName");

    /// <summary>
    /// Состояние.
    /// </summary>
    public TDataSetState State => (TDataSetState)GetRcwProperty("State");

    #endregion

    #region Методы

    /// <summary>
    /// Добавляет запись.
    /// </summary>
    public void Append()
    {
      InvokeRcwInstanceMethod("Append");
    }

    /// <summary>
    /// Применяет изменения.
    /// </summary>
    public void ApplyUpdates()
    {
      InvokeRcwInstanceMethod("ApplyUpdates");
    }

    /// <summary>
    /// Закрывает запись.
    /// </summary>
    public void CloseRecord()
    {
      InvokeRcwInstanceMethod("CloseRecord");
    }

    /// <summary>
    /// Получает компоненту.
    /// </summary>
    /// <returns>Компонента.</returns>
    public IComponent GetComponent()
    {
      var requisiteRcw = GetRcwProperty("Component");
      return new Component(requisiteRcw, Scope);
    }

    /// <summary>
    /// Получает реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    public IRequisite GetRequisite(string requisiteName)
    {
      var requisiteRcw = GetRcwProperty("Requisites", requisiteName);
      return new Requisite(requisiteRcw, Scope);
    }

    /// <summary>
    /// Открывает запись.
    /// </summary>
    public void OpenRecord()
    {
      InvokeRcwInstanceMethod("OpenRecord");
    }

    /// <summary>
    /// Обновляет детальный раздел.
    /// </summary>
    public void Refresh()
    {
      InvokeRcwInstanceMethod("Refresh");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIDataSet">COM-объект IDataSet.</param>
    /// <param name="scope">Область видимости.</param>
    internal DataSet(object rcwIDataSet, IScope scope) : base(rcwIDataSet, scope) { }

    #endregion
  }
}
