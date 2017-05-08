using IsbInterop.DataTypes.Enumerable;
using IsbInterop.References;

namespace IsbInterop.Data
{
  /// <summary>
  /// Набор данных.
  /// </summary>
  public interface IDataSet : IQuery, IBaseIsbObject
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
    /// Применяет изменения.
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
    /// Получает компоненту.
    /// </summary>
    /// <returns>Компонента.</returns>
    IComponent GetComponent();

    /// <summary>
    /// Получает реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    IRequisite GetRequisite(string requisiteName);

    /// <summary>
    /// Открывает запись.
    /// </summary>
    void OpenRecord();

    /// <summary>
    /// Закрывает запись.
    /// </summary>
    void CloseRecord();

    /// <summary>
    /// Добавляет запись.
    /// </summary>
    void Append();

    /// <summary>
    /// Обновляет детальный раздел.
    /// </summary>
    void Refresh();
  }
}
