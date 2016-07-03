﻿Namespace ServiceForms.Wrappers
  ''' <summary>
  ''' Обертка над IServiceFactory.
  ''' </summary>
  Public Class ServiceFactory
    Inherits IsbComObjectWrapper
    Implements IServiceFactory
    ''' <summary>
    ''' Получить проводник системы.
    ''' </summary>
    ''' <param name="isMain">Признак получения главной формы проводника системы.</param>
    ''' <returns>Проводник системы.</returns>
    Public Function GetExplorer(isMain As Boolean) As IEdmsExplorer Implements IServiceFactory.GetExplorer
      Dim rcwExplorer = Me.InvokeRcwInstanceMethod("GetExplorer", isMain)
      Return New EdmsExplorer(rcwExplorer)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIServiceFactory">COM-объект IServiceFactory.</param>
    Friend Sub New(rcwIServiceFactory As Object)
      MyBase.New(rcwIServiceFactory)
    End Sub
  End Class
End Namespace