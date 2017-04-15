Namespace ServiceForms.Wrappers

  ''' <summary>
  ''' Обертка над IServiceFactory.
  ''' </summary>
  Public Class ServiceFactory
    Inherits IsbComObjectWrapper
    Implements IServiceFactory

    ''' <summary>
    ''' Получает проводник системы.
    ''' </summary>
    ''' <param name="isMain">Признак получения главной формы проводника системы.</param>
    ''' <returns>Проводник системы.</returns>
    Public Function GetExplorer(isMain As Boolean) As IEdmsExplorer Implements IServiceFactory.GetExplorer
      Dim rcwExplorer = InvokeRcwInstanceMethod("GetExplorer", isMain)
      Return New EdmsExplorer(rcwExplorer, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIServiceFactory">COM-объект IServiceFactory.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwIServiceFactory As Object, scope As IScope)
      MyBase.New(rcwIServiceFactory, scope)
    End Sub
  End Class
End Namespace