Namespace Presentation
  ''' <summary>
  ''' Форма.
  ''' </summary>
  Public Interface IForm
    Inherits IDisposable
    ''' <summary>
    ''' Получить действия формы.
    ''' </summary>
    ''' <returns>Список действий формы.</returns>
    Function GetActions() As IActionList

    ''' <summary>
    ''' Показать форму в модальном режиме.
    ''' </summary>
    ''' <remarks>
    ''' Для форм справочников и электронных документов перед показом формы 
    ''' выполняются вычисления обработчика события «Форма-карточка. Показ».
    ''' </remarks>
    Sub ShowModal()

    ''' <summary>
    ''' Показать форму в немодальном режиме.
    ''' </summary>
    ''' <remarks>
    ''' Для форм справочников и электронных документов перед показом формы 
    ''' выполняются вычисления обработчика события «Форма-карточка. Показ».
    ''' </remarks>
    Sub ShowNoModal()
  End Interface
End NameSpace