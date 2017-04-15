namespace IsbInterop.ServiceForms.Wrappers
{
  /// <summary>
  /// Обертка над IServiceFactory.
  /// </summary>
  public class ServiceFactory : IsbComObjectWrapper, IServiceFactory
  {
    /// <summary>
    /// Получает проводник системы.
    /// </summary>
    /// <param name="isMain">Признак получения главной формы проводника системы.</param>
    /// <returns>Проводник системы.</returns>
    public IEdmsExplorer GetExplorer(bool isMain)
    {
      var rcwExplorer = InvokeRcwInstanceMethod("GetExplorer", isMain);
      return new EdmsExplorer(rcwExplorer, Scope);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIServiceFactory">COM-объект IServiceFactory.</param>
    /// <param name="scope">Область видимости.</param>
    internal ServiceFactory(object rcwIServiceFactory, IScope scope)
      : base(rcwIServiceFactory, scope) { }
  }
}
