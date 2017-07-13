using IsbInterop.DataTypes.Enumerable;
using System;

namespace IsbInterop.Data.Requisites
{
  /// <summary>
  /// Реквизит.
  /// </summary>
  public interface IRequisite : IBaseIsbObject
  {
    /// <summary>
    /// Целочисленное значение реквизита.
    /// </summary>
    int AsInteger { get; }

    /// <summary>
    /// Строковое значение реквизита.
    /// </summary>
    string AsString { get; }

    /// <summary>
    /// Значение реквизита в качестве даты.
    /// </summary>
    DateTime AsDate { get; }

    /// <summary>
    /// Тип реквизита.
    /// </summary>
    TReqDataType DataType { get; }

    /// <summary>
    /// Имя поля реквизита в базе.
    /// </summary>
    string FieldName { get; }

    /// <summary>
    /// Имя реквизита.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Признак, указывающий, что реквизит равен null.
    /// </summary>
    bool IsNull { get; }

    /// <summary>
    /// Значение реквизита.
    /// </summary>
    object Value { get; set; }
  }
}
