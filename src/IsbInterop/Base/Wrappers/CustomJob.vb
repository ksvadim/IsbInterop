Namespace Base.Wrappers

  ''' <summary>
  ''' Обертка над ICustomJob.
  ''' </summary>
  Friend MustInherit Class CustomJob(Of TI As ICustomJobInfo)
    Inherits CustomWork(Of TI)
    Implements ICustomJob(Of TI)

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    ''' <param name="scope">Область видимости.</param>
    Protected Sub New(rcwICustomJob As Object, scope As IScope)
      MyBase.New(rcwICustomJob, scope)
    End Sub
  End Class
End NameSpace