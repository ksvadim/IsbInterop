using IsbInterop.References;

namespace IsbInterop.Base
{
  /// <summary>
  /// Базовая фабрика объектов ЭДО.
  /// </summary>
  /// <typeparam name="T">Тип объекта фабрики.</typeparam>
  /// <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  public interface IEdmsObjectFactory<out T, out TI> : IFactory<T, TI>
    where T : IIsbComObjectWrapper
    where TI : IObjectInfo
  {
    /// <summary>
    /// Получить историю.
    /// Возвращает историю работы с объектом типа Kind с идентификатором ID. 
    /// Если такого объекта не существует, то будет сгенерировано исключение.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект IComponent.</returns>
    IComponent GetHistory(int id);

    /// <summary>
    /// Метод удаляет объект типа Kind с идентификатором ID. 
    /// Если такого объекта не существует, то будет сгенерировано исключение. 
    /// Для фабрики электронных документов IEDocumentFactory метод инициирует процессы «Открытие справочника», 
    /// «Удаление записи справочника», «Закрытие справочника».
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    void DeleteById(int id);
  }
}
