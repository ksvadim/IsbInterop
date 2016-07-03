using IsbInterop.References;
using IsbInterop.References.Wrappers;

namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IEdmsObjectFactory.
  /// </summary>
  /// <typeparam name="T">Тип объекта фабрики.</typeparam>
  /// <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  internal abstract class EdmsObjectFactory<T, TI> : Factory<T, TI>, IEdmsObjectFactory<T, TI>
    where T : IIsbComObjectWrapper
    where TI : IEdmsObjectInfo
  {
    /// <summary>
    /// Метод удаляет объект типа Kind с идентификатором ID. 
    /// Если такого объекта не существует, то будет сгенерировано исключение. 
    /// Для фабрики электронных документов IEDocumentFactory метод инициирует процессы «Открытие справочника», «Удаление записи справочника», «Закрытие справочника».
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    public void DeleteById(int id)
    {
      this.InvokeRcwInstanceMethod("DeleteByID", id);
    }

    /// <summary>
    /// Получить историю.
    /// Возвращает историю работы с объектом типа Kind с идентификатором ID. 
    /// Если такого объекта не существует, то будет сгенерировано исключение.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект IComponent.</returns>
    public IComponent GetHistory(int id)
    {
      var rcwComponent = this.GetRcwProperty("History", id);
      return new Component(rcwComponent);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwEdmsObjectFactory">COM-объект фабрики.</param>
    protected EdmsObjectFactory(object rcwEdmsObjectFactory) : base(rcwEdmsObjectFactory) { }
  }
}
