using IsbInterop.DataTypes.Enumerable;
using IsbInterop.References;

namespace IsbInterop.Data
{
  /// <summary>
  /// Набор данных.
  /// </summary>
  public interface IDataSet : IQuery, IIsbComObjectWrapper
  {
    /// <summary>
    /// Имя таблицы детального раздела.
    /// </summary>
    string SqlTableName { get; }

    /// <summary>
    /// Состояние.
    /// </summary>
    TDataSetState State { get; }

    /// <summary>
    /// Применить изменения.
    /// </summary>
    /// <remarks>
    /// Метод сохраняет изменения набора данных: записывает все добавления, 
    /// изменения и удаления записей набора данных в базу данных. 
    /// После выполнения метода свойство State принимает значение dssBrowse. 
    /// Следует вызывать метод только для главного раздела набора данных. 
    /// Если вызвать метод для детального раздела, то будет сгенерировано исключение.
    /// Метод инициирует процесс «Сохранение записи справочника». 
    /// </remarks>
    void ApplyUpdates();

    /// <summary>
    /// Получить компоненту.
    /// </summary>
    /// <returns>Компонента.</returns>
    IComponent GetComponent();

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    IRequisite GetRequisite(string requisiteName);

    /// <summary>
    /// Открыть запись.
    /// </summary>
    void OpenRecord();

    /// <summary>
    /// Закрыть запись.
    /// </summary>
    void CloseRecord();

    /// <summary>
    /// Добавить запись.
    /// </summary>
    void Append();

    /// <summary>
    /// Обновить детальный раздел.
    /// </summary>
    void Refresh();
  }
}
