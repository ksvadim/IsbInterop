using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;
using IsbInterop.Base;
using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Searches.Wrappers
{
  /// <summary>
  /// Обертка над ISearchDescription.
  /// </summary>
  internal abstract class SearchDescription : IsbComObjectWrapper, ISearchDescription
  {
    /// <summary>
    /// Выполнить поиск.
    /// </summary>
    /// <returns>Объект Contents.</returns>
    public IContents<TI> Execute<TI>() where TI: IObjectInfo
    {
      var rcwContents = this.InvokeRcwInstanceMethod("Execute");
      return new Contents<TI>(rcwContents);
    }

    /// <summary>
    /// Выполнить поиск и показать его результаты.
    /// </summary>
    /// <param name="mode">Режим отображения результатов поиска.</param>
    /// <param name="suppressQuerySearchCriteria">Признак подавления показа диалога для заполнения значений критериев поиска: 
    /// True, если не нужно показывать диалог, 
    /// False, если диалог нужно показывать в зависимости от наличия запрашиваемых реквизитов.</param>
    public void Show(TSearchShowMode mode, bool suppressQuerySearchCriteria)
    {
      this.InvokeRcwInstanceMethod("Show", new object[] { mode, suppressQuerySearchCriteria });
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwISearchDescription">COM-объект ISearchDescription.</param>
    protected SearchDescription(object rcwISearchDescription) : base(rcwISearchDescription) { }
  }
}
