namespace IsbInterop.Presentation.Proxies
{
  /// <summary>
  /// Обертка над IForm.
  /// </summary>
  internal class Form : BaseIsbObject, IForm
  {
    /// <summary>
    /// Получает действия формы.
    /// </summary>
    /// <returns></returns>
    public IActionList GetActions()
    {
      var rcwActions = GetRcwProperty("Actions");
      return new ActionList(rcwActions, Scope);
    }

    /// <summary>
    /// Показывает форму в модальном режиме.
    /// </summary>
    /// <remarks>
    /// Для форм справочников и электронных документов перед показом формы 
    /// выполняются вычисления обработчика события «Форма-карточка. Показ».
    /// </remarks>
    public void ShowModal()
    {
      InvokeRcwInstanceMethod("ShowModal");
    }

    /// <summary>
    /// Показывает форму в немодальном режиме.
    /// </summary>
    public void ShowNoModal()
    {
      InvokeRcwInstanceMethod("ShowNoModal");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIForm">СOM-объект IForm.</param>
    /// <param name="scope">Область видимости.</param>
    public Form(object rcwIForm, IScope scope) : base(rcwIForm, scope) { }
  }
}
