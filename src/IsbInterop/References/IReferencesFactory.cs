namespace IsbInterop.References
{
  /// <summary>
  /// Фабрика типов справочников.
  /// </summary>
  public interface IReferencesFactory : IBaseIsbObject
  {
    /// <summary>
    /// Получает фабрику справочника.
    /// </summary>
    /// <param name="name">Имя фабрики справочника.</param>
    /// <returns>Фабрика справочника с заданным именем.</returns>
    IReferenceFactory GetReferenceFactory(string name);
  }
}
