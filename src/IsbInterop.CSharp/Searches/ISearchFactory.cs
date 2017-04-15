namespace IsbInterop.Searches
{
  /// <summary>
  /// Фабрика поисков.
  /// </summary>
  public interface ISearchFactory : IBaseIsbObject
  {
    /// <summary>
    /// Загружает описание поиска.
    /// </summary>
    /// <param name="searchName">Имя поиска.</param>
    /// <returns>Описание поиска с указанным именем.</returns>
    ISearchForObjectDescription Load(string searchName);
  }
}
