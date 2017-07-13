using System;

namespace IsbInterop.Presentation
{
  /// <summary>
  /// Форма.
  /// </summary>
  public interface IForm : IDisposable
  {
    /// <summary>
    /// Получает действия формы.
    /// </summary>
    /// <returns>Список действий формы.</returns>
    IActionList GetActions();

    /// <summary>
    /// Показывает форму в модальном режиме.
    /// </summary>
    /// <remarks>
    /// Для форм справочников и электронных документов перед показом формы 
    /// выполняются вычисления обработчика события «Форма-карточка. Показ».
    /// </remarks>
    void ShowModal();

    /// <summary>
    /// Показывает форму в немодальном режиме.
    /// </summary>
    /// <remarks>
    /// Для форм справочников и электронных документов перед показом формы 
    /// выполняются вычисления обработчика события «Форма-карточка. Показ».
    /// </remarks>
    void ShowNoModal();
  }
}
