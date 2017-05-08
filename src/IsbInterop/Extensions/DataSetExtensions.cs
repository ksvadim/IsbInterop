using IsbInterop.Data;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Properties;
using System;

namespace IsbInterop.Extensions
{
  /// <summary>
  /// Методы расширения для работы с набором данных.
  /// </summary>
  public static class DataSetExtensions
  {
    /// <summary>
    ///  Добавляет условие ограничения на реквизит в запрос детального набора данных справочника.
    /// </summary>
    /// <param name="detailDataSet">Детальный набор данных.</param>
    /// <param name="requisite">Реквизит, по которому добавляется ограничение.</param>
    /// <param name="restrictValue">Ограничивающее значение.</param>
    /// <returns>ИД условия в запросе.</returns>
    public static int AddWhereWithRequisite(this IDataSet detailDataSet,
      IRequisite requisite, int restrictValue)
    {
      if (detailDataSet == null)
        throw new ArgumentNullException(nameof(detailDataSet));

      var queryWhereSection = $"{detailDataSet.SqlTableName}.{requisite.FieldName} = {restrictValue}";
      try
      {
        int conditionId = detailDataSet.AddWhere(queryWhereSection);

        return conditionId;
      }
      catch (IsbInteropException ex)
      {
        string componentName = "Unknown";

        try
        {
          using (var component = detailDataSet.GetComponent())
          {
            componentName = component.Name;
          }
        }
        catch (IsbInteropException)
        {
          // Гасим исключение.
        }

        var errorMessage = string.Format(Resources.UnableToSpecifyDataSetQueryTemplate,
          componentName, queryWhereSection);

        throw new IsbInteropException(errorMessage, ex.InnerException);
      }
    }

    /// <summary>
    ///  Добавляет условие ограничения на реквизит в запрос детального набора данных справочника.
    /// </summary>
    /// <param name="detailDataSet">Детальный набор данных.</param>
    /// <param name="requisite">Реквизит, по которому добавляется ограничение.</param>
    /// <param name="restrictValue">Ограничивающее значение.</param>
    /// <returns>ИД условия в запросе.</returns>
    public static int AddWhereWithRequisite(this IDataSet detailDataSet,
      IRequisite requisite, string restrictValue)
    {
      if (detailDataSet == null)
        throw new ArgumentNullException(nameof(detailDataSet));

      var dbRestrictValue = restrictValue;

      if (requisite.DataType == TReqDataType.rdtPick)
      {
        var possibleValues = ((IPickRequisite)requisite).Items;
        try
        {
          dbRestrictValue = possibleValues.IdByValue(restrictValue);
        }
        catch (IsbInteropException ex)
        {
          var errorMessage = string.Format(Resources.UnableToGetRequisiteSqlFieldValueTemplate,
            requisite.Name, restrictValue);
          throw new IsbInteropException(errorMessage, ex.InnerException);
        }
      }

      var queryWhereSection = $"{detailDataSet.SqlTableName}.{requisite.FieldName} = '{dbRestrictValue}'";

      try
      {
        int conditionId = detailDataSet.AddWhere(queryWhereSection);

        return conditionId;
      }
      catch (IsbInteropException ex)
      {
        string componentName = "Unknown";
        try
        {
          using (var component = detailDataSet.GetComponent())
          {
            componentName = component.Name;
          }
        }
        catch (IsbInteropException)
        {
          // Гасим исключение.
        }

        var errorMessage = string.Format(Resources.UnableToSpecifyDataSetQueryTemplate,
          componentName, queryWhereSection);

        throw new IsbInteropException(errorMessage, ex.InnerException);
      }
    }

    /// <summary>
    /// Удалить ограничение Where из запроса детального набора данных справочника.
    /// </summary>
    /// <param name="detailDataSet">Детальный набор данных.</param>
    /// <param name="queryConditionId">ИД условия в запросе.</param>
    public static void DeleteAddWhere(this IDataSet detailDataSet, int queryConditionId)
    {
      try
      {
        detailDataSet.DelWhere(queryConditionId);
      }
      catch (IsbInteropException ex)
      {
        var error = string.Format(Resources.UnableToDeleteDetailDataSetQueryConstraint);
        throw new IsbInteropException(error, ex.InnerException);
      }
    }
  }
}
