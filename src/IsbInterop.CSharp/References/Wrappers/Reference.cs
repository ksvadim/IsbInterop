using IsbInterop.Data;

namespace IsbInterop.References.Wrappers
{
  /// <summary>
  /// Обертка над IReference.
  /// </summary>
  internal class Reference : Component, IReference, IRequisiteAutoCleaner
  {
    #region IDisposable

    private bool disposed = false;

    /// <summary>
    /// Очистка.
    /// </summary>
    /// <param name="disposing">Флаг вызова метода Dispose.</param>
    protected override void Dispose(bool disposing)
    {
      if (this.disposed)
        return;

      if (disposing)
        this.requisiteContainer.DisposeRequisites();

      this.disposed = true;

      base.Dispose(disposing);
    }

    #endregion

    #region IRequisiteContainer

    /// <summary>
    /// Контейнер реквизитов.
    /// </summary>
    IRequisiteContainer IRequisiteAutoCleaner.RequisiteContainer
    {
      get { return this.requisiteContainer; }
    }
    private readonly RequisiteContainer requisiteContainer = new RequisiteContainer();

    #endregion

    #region Методы

    /// <summary>
    /// Получить реквизит.
    /// </summary>
    /// <param name="requisiteName">Имя реквизита.</param>
    /// <returns>Реквизит.</returns>
    public override IRequisite GetRequisite(string requisiteName)
    {
      var requisite = this.requisiteContainer.GetRequisite(requisiteName, base.GetRequisite);
      return requisite;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="reference">Справочник DIRECTUM.</param>
    public Reference(object reference) : base(reference) { }

    #endregion
  }
}
