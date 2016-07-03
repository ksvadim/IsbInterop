namespace IsbInterop.References
{
  /// <summary>
  /// Фабрика типов справочников.
  /// </summary>
  public interface IReferencesFactory : IIsbComObjectWrapper
  {
    /// <summary>
    /// Получить фабрику справочника.
    /// </summary>
    /// <param name="name">Имя фабрика справочника.</param>
    /// <returns>Фабрика справочника с заданным именем.</returns>
    IReferenceFactory GetReferenceFactory(string name);
  }
}
