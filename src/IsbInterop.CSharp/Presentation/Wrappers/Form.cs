namespace IsbInterop.Presentation.Wrappers
{
  /// <summary>
  /// Обертка над IForm.
  /// </summary>
  internal class Form : IsbComObjectWrapper, IForm
  {
    /// <summary>
    /// Получить действия формы.
    /// </summary>
    /// <returns></returns>
    public IActionList GetActions()
    {
      var rcwActions = this.GetRcwProperty("Actions");
      return new ActionList(rcwActions, this.Scope);
    }

    /// <summary>
    /// Показать форму в модальном режиме.
    /// </summary>
    /// <remarks>
    /// Для форм справочников и электронных документов перед показом формы 
    /// выполняются вычисления обработчика события «Форма-карточка. Показ».
    /// </remarks>
    public void ShowModal()
    {
      this.InvokeRcwInstanceMethod("ShowModal");
    }

    /// <summary>
    /// Показать форму в немодальном режиме.
    /// </summary>
    public void ShowNoModal()
    {
      this.InvokeRcwInstanceMethod("ShowNoModal");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIForm">СOM-объект IForm.</param>
    /// <param name="scope">Область видимости.</param>
    public Form(object rcwIForm, IScope scope) : base(rcwIForm, scope) { }
  }
}
