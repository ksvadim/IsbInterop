﻿using IsbInterop.Data;
using IsbInterop.Data.Proxies;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Utils;
using System;
using IsbInterop.Data.Proxies.Requisites;
using IsbInterop.Data.Requisites;

namespace IsbInterop
{
  /// <summary>
  /// Фабрика реквизитов, унаследованных от IRequisite.
  /// </summary>
  internal static class DerivedRequisiteFactory
  {
    /// <summary>
    /// Создает реквизит.
    /// </summary>
    /// <param name="rcwRequisite">RCW-объект реквизита.</param>
    /// <param name="scope">Область видимости.</param>
    /// <returns>Реквизит с заданным типом.</returns>
    public static IRequisite CreateRequisite(object rcwRequisite, IScope scope)
    {
      var type = TReqDataType.rdtUnknown;

      int dataType = (int)ComUtils.GetRcwProperty(rcwRequisite, "DataType");

      if (Enum.IsDefined(typeof(TReqDataType), dataType))
        type = (TReqDataType)dataType;

      switch (type)
      {
        case TReqDataType.rdtPick:
          return new PickRequisite(rcwRequisite, scope);
        case TReqDataType.rdtDate:
        case TReqDataType.rdtInteger:
        case TReqDataType.rdtNumeric:
        case TReqDataType.rdtReference:
        case TReqDataType.rdtString:
        case TReqDataType.rdtText:
        default:
          return new Requisite(rcwRequisite, scope);
      }
    }
  }
}
