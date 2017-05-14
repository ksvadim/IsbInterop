using IsbInterop.Data.Requisites;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Properties;
using IsbInterop.References;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsbInterop.Extensions
{
  /// <summary>
  /// Методы расширения для работы со справочником.
  /// </summary>
  public static class ReferenceExtensions
  {
    /// <summary>
    ///  Добавляет условие ограничения на реквизит в запрос набора данных справочника.
    /// </summary>
    /// <param name="reference">Справочник.</param>
    /// <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    /// <param name="restrictValue">Ограничивающее значение.</param>
    /// <returns>ИД условия в запросе.</returns>
    public static int AddWhereWithRequisite(this IReference reference, IRequisite requisite, int restrictValue)
    {
      if (reference == null)
        throw new ArgumentNullException(nameof(reference));

      if (requisite == null)
        throw new ArgumentNullException(nameof(requisite));

      var queryWhereSection = $"{reference.SqlTableName}.{requisite.FieldName} = {restrictValue}";

      return AddWhereSection(reference, queryWhereSection);
    }

    /// <summary>
    ///  Добавляет условие ограничения на реквизит в запрос набора данных справочника.
    /// </summary>
    /// <param name="reference">Справочник.</param>
    /// <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    /// <param name="restrictingValue">Ограничивающее значение.</param>
    /// <returns>ИД условия в запросе.</returns>
    public static int AddWhereWithRequisite(this IReference reference, IRequisite requisite, string restrictingValue)
    {
      if (reference == null)
        throw new ArgumentNullException(nameof(reference));

      var requisiteSqlFieldValue = GetRequisiteSqlFieldValue(requisite, restrictingValue);
      var queryWhereSection = $"{reference.SqlTableName}.{requisite.FieldName} = '{requisiteSqlFieldValue}'";

      return AddWhereSection(reference, queryWhereSection);
    }

    /// <summary>
    ///  Добавляет условие ограничения на реквизит в запрос набора данных справочника.
    /// </summary>
    /// <param name="reference">Справочник.</param>
    /// <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    /// <param name="restrictingValues">Ограничивающие значения.</param>
    /// <returns>ИД условия в запросе.</returns>
    public static int AddWhereWithRequisite(this IReference reference, IRequisite requisite, IEnumerable<string> restrictingValues)
    {
      if (reference == null)
        throw new ArgumentNullException(nameof(reference));

      if (requisite == null)
        throw new ArgumentNullException(nameof(requisite));

      if (!restrictingValues.Any())
        throw new ArgumentException("restrictingValues");

      var restrictingCondition = string.Join(", ",
        restrictingValues.Select(v => $"'{GetRequisiteSqlFieldValue(requisite, v)}'"));

      var queryWhereSection = $"{reference.SqlTableName}.{requisite.FieldName} in ({restrictingCondition})";

      return AddWhereSection(reference, queryWhereSection);
    }

    /// <summary>
    ///  Добавляет условие, что реквизит не ревен Null в запрос набора данных справочника.
    /// </summary>
    /// <param name="reference">Справочник.</param>
    /// <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    /// <returns>ИД условия в запросе.</returns>
    public static int AddWhereWithRequisiteIsNotNull(this IReference reference, IRequisite requisite)
    {
      var queryWhereSection = $"{reference.SqlTableName}.{requisite.FieldName} is not null";

      return AddWhereSection(reference, queryWhereSection);
    }

    /// <summary>
    /// Получает значение sql-поля реквизита по именованному значению.
    /// </summary>
    /// <param name="requisite">Реквизит.</param>
    /// <param name="namedValue">Именованное значение.</param>
    /// <returns>Значение поля реквизита, записываемое в БД.</returns>
    public static string GetRequisiteSqlFieldValue(IRequisite requisite, string namedValue)
    {
      try
      {
        if (requisite.DataType != TReqDataType.rdtPick)
          return namedValue;
        else
        {
          var possibleValues = ((IPickRequisite)requisite).Items;
          return possibleValues.IdByValue(namedValue);
        }
      }
      catch (IsbInteropException ex)
      {
        var errorMessage = string.Format(Resources.UnableToGetRequisiteSqlFieldValueTemplate,
          requisite.Name, namedValue);

        throw new IsbInteropException(errorMessage, ex.InnerException);
      }
    }

    /// <summary>
    /// Добавляет секцию Where в запрос набора данных справочника.
    /// </summary>
    /// <param name="reference">Справочник.</param>
    /// <param name="queryWhereSection">Секция where запроса.</param>
    /// <returns>ИД условия в запросе.</returns>
    private static int AddWhereSection(IReference reference, string queryWhereSection)
    {
      try
      {
        return reference.AddWhere(queryWhereSection);
      }
      catch (IsbInteropException ex)
      {
        var errorMessage = string.Format(Resources.UnableToSpecifyDataSetQueryTemplate,
          reference.Name, queryWhereSection);

        throw new IsbInteropException(errorMessage, ex.InnerException);
      }
    }
  }
}
