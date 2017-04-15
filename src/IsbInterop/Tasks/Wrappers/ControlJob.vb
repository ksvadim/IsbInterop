Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над IControlJob
  ''' </summary>
  Friend Class ControlJob
    Inherits CustomJob(Of IControlJobInfo)
    Implements IControlJob

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As IControlJobInfo
      Dim rcwIControlJobInfo = GetRcwObjectInfo()
      Return New ControlJobInfo(rcwIControlJobInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIControlJob">СOM-объект IControlJob.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIControlJob As Object, scope As IScope)
      MyBase.New(rcwIControlJob, scope)
    End Sub
  End Class
End Namespace