using IsbInterop.Accessory;
using IsbInterop.Base;
using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Searches
{
  /// <summary>
  /// Описание поиска.
  /// </summary>
  public interface ISearchDescription: IBaseIsbObject 
  {
    /// <summary>
    /// Выполняет поиск.
    /// </summary>
    /// <returns>Объект Contents.</returns>
    IContents<TI> Execute<TI>() where TI : IObjectInfo;

    /// <summary>
    /// Выполняет поиск и показывает его результаты.
    /// </summary>
    /// <param name="mode">Режим отображения результатов поиска.</param>
    /// <param name="suppressQuerySearchCriteria">Признак подавления показа диалога для заполнения значений критериев поиска:
    /// True, если не нужно показывать диалог,
    /// False, если диалог нужно показывать в зависимости от наличия запрашиваемых реквизитов.</param>
    void Show(TSearchShowMode mode, bool suppressQuerySearchCriteria);
  }
}
