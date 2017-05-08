namespace IsbInterop.ServiceForms
{
  /// <summary>
  /// Фабрика служебных объектов.
  /// </summary>
  public interface IServiceFactory : IBaseIsbObject
  {
    /// <summary>
    /// Получает проводник системы.
    /// </summary>
    /// <param name="isMain">Признак получения главной формы проводника системы.</param>
    /// <returns>Проводник системы.</returns>
    IEdmsExplorer GetExplorer(bool isMain);
  }
}
