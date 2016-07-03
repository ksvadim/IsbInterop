using IsbInterop.Base;

namespace IsbInterop.Searches
{
  /// <summary>
  /// Описание поиска для объекта.
  /// </summary>
  public interface ISearchForObjectDescription : ISearchDescription
  {
    /// <summary>
    /// Инициализировать поиск.
    /// </summary>
    /// <param name="directumObject">Информация об объекте поиска.</param>
    void InitializeSearch(IObjectInfo directumObject);
  }
}
