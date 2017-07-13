namespace IsbInterop.Searches.Proxies
{
  /// <summary>
  /// Обертка над ISearchFactory.
  /// </summary>
  internal class SearchFactory : BaseIsbObject, ISearchFactory
  {
    /// <summary>
    /// Загружает описание поиска.
    /// </summary>
    /// <param name="searchName">Имя поиска.</param>
    /// <returns>Описание поиска с указанным именем.</returns>
    public ISearchForObjectDescription Load(string searchName)
    {
      var rcwSearchForObjectDescription = InvokeRcwInstanceMethod("Load", searchName);
      return new SearchForObjectDescription(rcwSearchForObjectDescription, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwISearchFactory">COM-объект ISearchFactory.</param>
    /// <param name="scope">Область видимости.</param>
    internal SearchFactory(object rcwISearchFactory, IScope scope) : base(rcwISearchFactory, scope) { }
  }
}
