namespace IsbInterop.ServiceForms.Wrappers
{
  /// <summary>
  /// Обертка над IServiceFactory.
  /// </summary>
  public class ServiceFactory : IsbComObjectWrapper, IServiceFactory
  {
    /// <summary>
    /// Получить проводник системы.
    /// </summary>
    /// <param name="isMain">Признак получения главной формы проводника системы.</param>
    /// <returns>Проводник системы.</returns>
    public IEdmsExplorer GetExplorer(bool isMain)
    {
      var rcwExplorer = this.InvokeRcwInstanceMethod("GetExplorer", isMain);
      return new EdmsExplorer(rcwExplorer);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIServiceFactory">COM-объект IServiceFactory.</param>
    internal ServiceFactory(object rcwIServiceFactory) : base(rcwIServiceFactory) { }
  }
}
