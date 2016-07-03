Namespace Presentation.Wrappers
  ''' <summary>
  ''' Обертка над IForm.
  ''' </summary>
  Friend Class Form
    Inherits IsbComObjectWrapper
    Implements IForm
    ''' <summary>
    ''' Получить действия формы.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetActions() As IActionList Implements IForm.GetActions
      Dim rcwActions = Me.GetRcwProperty("Actions")
      Return New ActionList(rcwActions)
    End Function

    ''' <summary>
    ''' Показать форму в модальном режиме.
    ''' </summary>
    Public Sub ShowModal() Implements IForm.ShowModal
      Me.InvokeRcwInstanceMethod("ShowModal")
    End Sub

    ''' <summary>
    ''' Показать форму в немодальном режиме.
    ''' </summary>
    Public Sub ShowNoModal() Implements IForm.ShowNoModal
      Me.InvokeRcwInstanceMethod("ShowNoModal")
    End Sub

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIForm">СOM-объект IForm.</param>
    Public Sub New(rcwIForm As Object)
      MyBase.New(rcwIForm)
    End Sub
  End Class
End NameSpace