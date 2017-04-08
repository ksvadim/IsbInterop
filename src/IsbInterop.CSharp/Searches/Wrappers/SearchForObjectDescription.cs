﻿using IsbInterop.Base;
using System;

namespace IsbInterop.Searches.Wrappers
{
  /// <summary>
  /// Обертка над ISearchForComObjectDescription.
  /// </summary>
  internal class SearchForObjectDescription : SearchDescription, ISearchForObjectDescription
  {
    /// <summary>
    /// Инициализировать поиск.
    /// </summary>
    /// <param name="objectInfo">Информация об объекте поиска.</param>
    public void InitializeSearch(IObjectInfo objectInfo)
    {
      if (objectInfo == null)
        throw new ArgumentNullException("objectInfo");

      this.InvokeRcwInstanceMethod("InitializeSearch", ((IUnsafeRcwHolder)objectInfo).RcwObject);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwISearchForObjectDescription">COM-объект ISearchForObjectDescription.</param>
    /// <param name="scope">Область видимости.</param>
    internal SearchForObjectDescription(object rcwISearchForObjectDescription, IScope scope) : base(rcwISearchForObjectDescription, scope) { }
  }
}
