Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над ICustomWorkInfo.
  ''' </summary>
  Friend Class CustomWorkInfo
    Inherits EdmsObjectInfo
    Implements ICustomWorkInfo

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwICustomWorkInfo">COM-объект ICustomWorkInfo.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwICustomWorkInfo As Object, scope As IScope)
      MyBase.New(rcwICustomWorkInfo, scope)
    End Sub
  End Class
End NameSpace