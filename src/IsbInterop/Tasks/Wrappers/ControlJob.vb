Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над IControlJob
  ''' </summary>
  Friend Class ControlJob
    Inherits CustomJob(Of IControlJobInfo)
    Implements IControlJob

    ''' <summary>
    ''' Информация об объекте.
    ''' </summary>
    Public Overrides ReadOnly Property Info As IControlJobInfo
      Get
        Dim rcwIControlJobInfo = Me.GetRcwObjectInfo()
        Return New ControlJobInfo(rcwIControlJobInfo, Scope)
      End Get
    End Property

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