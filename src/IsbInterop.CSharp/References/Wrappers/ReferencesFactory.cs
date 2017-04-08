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
      var referenceFactory = new ReferenceFactory(rcwReferenceFactory, this.Scope);

      return referenceFactory;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwReferencesFactory">COM-объект ReferencesFactory.</param>
    /// <param name="scope">Область видимости.</param>
    internal ReferencesFactory(object rcwReferencesFactory, IScope scope) : base(rcwReferencesFactory, scope) { }
  }
}
