using IsbInterop.Base.Proxies;
using IsbInterop.References;
using IsbInterop.References.Proxies;

namespace IsbInterop.Edms.Proxies
{
  /// <summary>
  /// Обертка над IEdmsObjectFactory.
  /// </summary>
  /// <typeparam name="T">Тип объекта фабрики.</typeparam>
  /// <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  internal abstract class EdmsObjectFactory<T, TI> : Factory<T, TI>, IEdmsObjectFactory<T, TI>
    where T : IBaseIsbObject
    where TI : IEdmsObjectInfo
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
    public void DeleteById(int id)
    {
      InvokeRcwInstanceMethod("DeleteByID", id);
    }

    /// <summary>
    /// Получает историю работы с объектом.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>История работы с объектом.</returns>
    /// <remarks>
    /// Получает историю работы с объектом типа Kind с идентификатором ID.
    /// Если такого объекта не существует, то будет сгенерировано исключение.
    /// </remarks>
    public IComponent GetHistory(int id)
    {
      var rcwComponent = GetRcwProperty("History", id);
      return new Component(rcwComponent, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwEdmsObjectFactory">COM-объект фабрики.</param>
    /// <param name="scope">Область видимости.</param>
    protected EdmsObjectFactory(object rcwEdmsObjectFactory, IScope scope) : base(rcwEdmsObjectFactory, scope) { }
  }
}
