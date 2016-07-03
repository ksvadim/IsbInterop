using IsbInterop.DataTypes.Enumerable;
using System;

namespace IsbInterop.Data.Wrappers
{
  /// <summary>
  /// Обертка над IRequisite.
  /// </summary>
  internal class Requisite : IsbComObjectWrapper, IRequisite
  {
    #region Поля и свойства

    /// <summary>
    /// Значение реквизита в качестве даты.
    /// </summary>
    public DateTime AsDate
    {
      get { return (DateTime)this.GetRcwProperty("AsDate"); }
    }

    /// <summary>
    /// Целочисленное значение реквизита.
    /// </summary>
    public int AsInteger
    {
      get { return (int)this.GetRcwProperty("AsInteger"); }
    }

    /// <summary>
    /// Строковое значение реквизита.
    /// </summary>
    public string AsString
    {
      get { return (string)this.GetRcwProperty("AsString"); }
    }

    /// <summary>
    /// Тип реквизита.
    /// </summary>
    public TReqDataType DataType
    {
      get
      {
        int dataType = (int)this.GetRcwProperty("DataType");

        if (Enum.IsDefined(typeof(TReqDataType), dataType))
          return (TReqDataType)dataType;
        else
          return TReqDataType.rdtUnknown;
      }
    }

    /// <summary>
    /// Имя поля реквизита в базе.
    /// </summary>
    public string FieldName
    {
      get { return (string)this.GetRcwProperty("FieldName"); }
    }

    /// <summary>
    /// Признак, указывающий, что реквизит равен null.
    /// </summary>
    public bool IsNull
    {
      get { return (bool)this.GetRcwProperty("IsNull"); }
    }

    /// <summary>
    /// Имя реквизита.
    /// </summary>
    public string Name
    {
      get { return (string)this.GetRcwProperty("Name"); }
    }

    /// <summary>
    /// Значение реквизита.
    /// </summary>
    public object Value
    {
      get { return this.GetRcwProperty("Value"); }
      set { this.SetRcwProperty("Value", value); }
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwRequisite">COM-объект реквизит.</param>
    internal Requisite(object rcwRequisite) : base(rcwRequisite) { }

    #endregion
  }
}
