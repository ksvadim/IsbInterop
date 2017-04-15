namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IObjectInfo.
  /// </summary>
  internal class ObjectInfo : BaseIsbObject, IObjectInfo
  {
    /// <summary>
    /// ИД объекта.
    /// </summary>
    public int Id => (int)GetRcwProperty("ID");

    /// <summary>
    /// Имя объекта.
    /// </summary>
    public string Name => (string)GetRcwProperty("Name");

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwObjectInfo">COM-объект ObjectInfo.</param>
    /// <param name="scope">Область видимости.</param>
    // ReSharper disable once MemberCanBeProtected.Global
    // Для Autofac конструктор должен быть объявлен как public.
    public ObjectInfo(object rcwObjectInfo, IScope scope) : base(rcwObjectInfo, scope) { }
  }
}
