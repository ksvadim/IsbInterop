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
    Public Sub New(rcwICustomWorkInfo As Object)
      MyBase.New(rcwICustomWorkInfo)
    End Sub
  End Class
End NameSpace