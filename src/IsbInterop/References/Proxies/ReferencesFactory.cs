namespace IsbInterop.References.Proxies
{
  /// <summary>
  /// Обертка над IReferencesFactory.
  /// </summary>
  internal class ReferencesFactory : BaseIsbObject, IReferencesFactory
  {
    /// <summary>
    /// Получает фабрику справочника.
    /// </summary>
    /// <param name="referenceFactoryName">Имя фабрики справочника.</param>
    /// <returns>Фабрика справочника.</returns>
    public IReferenceFactory GetReferenceFactory(string referenceFactoryName)
    {
      var rcwReferenceFactory = GetRcwProperty("ReferenceFactory", referenceFactoryName);
      var referenceFactory = new ReferenceFactory(rcwReferenceFactory, Scope);

      return referenceFactory;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwReferencesFactory">COM-объект ReferencesFactory.</param>
    /// <param name="scope">Область видимости.</param>
    internal ReferencesFactory(object rcwReferencesFactory, IScope scope)
      : base(rcwReferencesFactory, scope) { }
  }
}
