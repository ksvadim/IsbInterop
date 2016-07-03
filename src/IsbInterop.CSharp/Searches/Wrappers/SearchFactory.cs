﻿namespace IsbInterop.Searches.Wrappers
{
  /// <summary>
  /// Обертка над ISearchFactory.
  /// </summary>
  internal class SearchFactory : IsbComObjectWrapper, ISearchFactory
  {
    /// <summary>
    /// Загрузить описание поиска.
    /// </summary>
    /// <param name="searchName">Имя поиска.</param>
    /// <returns>Описание поиска с указанным именем.</returns>
    public ISearchForObjectDescription Load(string searchName)
    {
      var rcwSearchForObjectDescription = this.InvokeRcwInstanceMethod("Load", searchName);
      return new SearchForObjectDescription(rcwSearchForObjectDescription);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwISearchFactory">COM-объект ISearchFactory.</param>
    internal SearchFactory(object rcwISearchFactory) : base(rcwISearchFactory) { }
  }
}
