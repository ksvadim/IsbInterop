Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers
  ''' <summary>
  ''' Обертка над IControlJob
  ''' </summary>
  Friend Class ControlJob
    Inherits CustomJob(Of IControlJobInfo)
    Implements IControlJob
    ''' <summary>
    ''' Получить IControlJobInfo.
    ''' </summary>
    ''' <returns>IControlJobInfo.</returns>
    Public Overrides Function GetInfo() As IControlJobInfo
      Dim rcwIControlJobInfo = Me.GetRcwObjectInfo()
      Return New ControlJobInfo(rcwIControlJobInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIControlJob">СOM-объект IControlJob.</param>
    Public Sub New(rcwIControlJob As Object)
      MyBase.New(rcwIControlJob)
    End Sub
  End Class
End NameSpace