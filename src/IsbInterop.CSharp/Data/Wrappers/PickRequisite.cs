namespace IsbInterop.Data.Wrappers
{
  /// <summary>
  /// Обертка над IRequisite.
  /// </summary>
  internal class PickRequisite : Requisite, IPickRequisite
  {
    /// <summary>
    /// Список описаний допустимых значений реквизита.
    /// </summary>
    public IPickRequisiteItems Items
    {
      get
      {
        var rcwItems = this.GetRcwProperty("Items");
        return new PickRequisiteItems(rcwItems, this.Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwRequisite">COM-объект реквизит.</param>
    /// <param name="scope">Область видимости.</param>
    internal PickRequisite(object rcwRequisite, IScope scope) : base(rcwRequisite, scope) { }
  }
}
