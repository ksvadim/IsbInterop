using IsbInterop.Base;
using IsbInterop.References;

namespace IsbInterop.Edms
{
  /// <summary>
  /// Базовая фабрика объектов ЭДО.
  /// </summary>
  /// <typeparam name="T">Тип объекта фабрики.</typeparam>
  /// <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  public interface IEdmsObjectFactory<out T, out TI> : IFactory<T, TI>
    where T : IBaseIsbObject
    where TI : IObjectInfo
  {
    /// <summary>
    /// Удаляет объект.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <remarks>
    /// Метод удаляет объект типа Kind с идентификатором ID.
    /// Если такого объекта не существует, то будет сгенерировано исключение.
    /// Для фабрики электронных документов IEDocumentFactory метод инициирует процессы:
    /// «Открытие справочника», «Удаление записи справочника», «Закрытие справочника».
    /// </remarks>
    void DeleteById(int id);

    /// <summary>
    /// Получает историю работы с объектом.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>История работы с объектом.</returns>
    /// <remarks>
    /// Получает историю работы с объектом типа Kind с идентификатором ID.
    /// Если такого объекта не существует, то будет сгенерировано исключение.
    /// </remarks>
    IComponent GetHistory(int id);
  }
}
