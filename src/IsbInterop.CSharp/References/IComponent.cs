using IsbInterop.Base;
using IsbInterop.Presentation;

namespace IsbInterop.References
{
  /// <summary>
  /// Компонента.
  /// </summary>
  public interface IComponent : IObject<IObjectInfo>
  {
    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    bool EOF { get; }

    /// <summary>
    /// Количество записей в наборе данных.
    /// </summary>
    int RecordCount { get; }

    /// <summary>
    /// Признак открытости записи набора данных.
    /// </summary>
    /// <remarks>
    /// Свойство устанавливается в True после выполнения метода OpenRecord, в False – после выполнения метода CloseRecord.
    /// </remarks>
    bool RecordOpened { get; }

    /// <summary>
    /// Добавить запись.
    /// </summary>
    void Append();

    /// <summary>
    /// Закрыть набор данных компоненты.
    /// </summary>
    void Close();

    /// <summary>
    /// Закрыть запись.
    /// </summary>
    void CloseRecord();

    /// <summary>
    /// Получить форму-список.
    /// </summary>
    /// <returns>Форма-список.</returns>
    IForm GetComponentForm();

    /// <summary>
    /// Перейти на первую запись набора данных.
    /// </summary>
    void First();

    /// <summary>
    /// Перейти на последнюю запись набора данных.
    /// </summary>
    void Last();

    /// <summary>
    /// Перейти на следующую запись набора данных.
    /// </summary>
    void Next();

    /// <summary>
    /// Открыть набор данных компоненты.
    /// </summary>
    void Open();

    /// <summary>
    /// Открыть запись.
    /// </summary>
    void OpenRecord();

    /// <summary>
    /// Перейти на предыдущую запись набора данных.
    /// </summary>
    void Prior();
  }
}
