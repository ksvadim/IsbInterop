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
    /// Добавляет запись.
    /// </summary>
    void Append();

    /// <summary>
    /// Закрывает набор данных компоненты.
    /// </summary>
    void Close();

    /// <summary>
    /// Закрывает запись.
    /// </summary>
    void CloseRecord();

    /// <summary>
    /// Получает форму-список.
    /// </summary>
    /// <returns>Форма-список.</returns>
    IForm GetComponentForm();

    /// <summary>
    /// Переходит на первую запись набора данных.
    /// </summary>
    void First();

    /// <summary>
    /// Переходит на последнюю запись набора данных.
    /// </summary>
    void Last();

    /// <summary>
    /// Переходит на следующую запись набора данных.
    /// </summary>
    void Next();

    /// <summary>
    /// Открывает набор данных компоненты.
    /// </summary>
    void Open();

    /// <summary>
    /// Открывает запись.
    /// </summary>
    void OpenRecord();

    /// <summary>
    /// Переходит на предыдущую запись набора данных.
    /// </summary>
    void Prior();
  }
}
