namespace IsbInterop.References.Wrappers
{
  /// <summary>
  /// Обертка над IReferencesFactory.
  /// </summary>
  internal class ReferencesFactory : IsbComObjectWrapper, IReferencesFactory
  {
    /// <summary>
    /// Получить фабрику типов справочников.
    /// </summary>
    /// <param name="referenceFactoryName">Имя фабрики типов справочников.</param>
    /// <returns>Фабрика типов справочников.</returns>
    public IReferenceFactory GetReferenceFactory(string referenceFactoryName)
    {
      var rcwReferenceFactory = this.GetRcwProperty("ReferenceFactory", referenceFactoryName);
      var referenceFactory = new ReferenceFactory(rcwReferenceFactory);

      return referenceFactory;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwReferencesFactory">COM-объект ReferencesFactory.</param>
    internal ReferencesFactory(object rcwReferencesFactory) : base(rcwReferencesFactory) { }
  }
}
