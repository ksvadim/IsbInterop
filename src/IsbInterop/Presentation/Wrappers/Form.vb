Namespace Presentation.Wrappers

  ''' <summary>
  ''' Обертка над IForm.
  ''' </summary>
  Friend Class Form
    Inherits IsbComObjectWrapper
    Implements IForm

    ''' <summary>
    ''' Получает действия формы.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetActions() As IActionList Implements IForm.GetActions
      Dim rcwActions = GetRcwProperty("Actions")
      Return New ActionList(rcwActions, Scope)
    End Function

    ''' <summary>
    ''' Показывает форму в модальном режиме.
    ''' </summary>
    Public Sub ShowModal() Implements IForm.ShowModal
      InvokeRcwInstanceMethod("ShowModal")
    End Sub

    ''' <summary>
    ''' Показывает форму в немодальном режиме.
    ''' </summary>
    Public Sub ShowNoModal() Implements IForm.ShowNoModal
      InvokeRcwInstanceMethod("ShowNoModal")
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIForm">СOM-объект IForm.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIForm As Object, scope As IScope)
      MyBase.New(rcwIForm, scope)
    End Sub
  End Class
End NameSpace