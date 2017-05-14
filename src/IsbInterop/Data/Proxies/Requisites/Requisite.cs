using IsbInterop.DataTypes.Enumerable;
using System;
using IsbInterop.Data.Requisites;

namespace IsbInterop.Data.Proxies.Requisites
{
  /// <summary>
  /// Обертка над IRequisite.
  /// </summary>
  internal class Requisite : BaseIsbObject, IRequisite
  {
    #region Поля и свойства

    /// <summary>
    /// Значение реквизита в качестве даты.
    /// </summary>
    public DateTime AsDate => (DateTime)GetRcwProperty("AsDate");

    /// <summary>
    /// Целочисленное значение реквизита.
    /// </summary>
    public int AsInteger => (int)GetRcwProperty("AsInteger");

    /// <summary>
    /// Строковое значение реквизита.
    /// </summary>
    public string AsString => (string)GetRcwProperty("AsString");

    /// <summary>
    /// Тип реквизита.
    /// </summary>
    public TReqDataType DataType
    {
      get
      {
        int dataType = (int)GetRcwProperty("DataType");

        if (Enum.IsDefined(typeof(TReqDataType), dataType))
          return (TReqDataType)dataType;
        else
          return TReqDataType.rdtUnknown;
      }
    }

    /// <summary>
    /// Имя поля реквизита в базе.
    /// </summary>
    public string FieldName => (string)GetRcwProperty("FieldName");

    /// <summary>
    /// Признак, указывающий, что реквизит равен null.
    /// </summary>
    public bool IsNull => (bool)GetRcwProperty("IsNull");

    /// <summary>
    /// Имя реквизита.
    /// </summary>
    public string Name => (string)GetRcwProperty("Name");

    /// <summary>
    /// Значение реквизита.
    /// </summary>
    public object Value
    {
      get { return GetRcwProperty("Value"); }
      set { SetRcwProperty("Value", value); }
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwRequisite">COM-объект реквизит.</param>
    /// <param name="scope"></param>
    internal Requisite(object rcwRequisite, IScope scope) : base(rcwRequisite, scope) { }

    #endregion
  }
}
