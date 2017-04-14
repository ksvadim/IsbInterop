Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над ICustomJob.
  ''' </summary>
  Friend Class DefaultCustomJob
    Inherits CustomJob(Of ICustomJobInfo)

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As ICustomJobInfo
      Dim rcwIJobInfo = GetRcwObjectInfo()
      Return New CustomJobInfo(rcwIJobInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwICustomJob">COM-объект ICustomJob.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwICustomJob As Object, scope As IScope)
      MyBase.New(rcwICustomJob, scope)
    End Sub
  End Class
End Namespace