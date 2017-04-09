Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers
Imports IsbInterop.DataTypes.Enumerable

Namespace Tasks.Wrappers

  ''' <summary>
  ''' Обертка над IJobFactory.
  ''' </summary>
  Friend Class JobFactory
    Inherits EdmsObjectFactory(Of ICustomJob(Of ICustomJobInfo), ICustomJobInfo)
    Implements IJobFactory

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As ICustomJob(Of ICustomJobInfo)
      Dim objectType As TCompType
      Dim edmsObjectRcw = GetRcwObjectById(id, objectType)
      Select Case objectType
        Case (TCompType.ctJob)
          Return New Job(edmsObjectRcw, Scope)
        Case (TCompType.ctNotice)
          Return New Notice(edmsObjectRcw, Scope)
        Case (TCompType.ctControlJob)
          Return New ControlJob(edmsObjectRcw, Scope)
        Case Else
          Return New DefaultCustomJob(edmsObjectRcw, Scope)
      End Select
    End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As ICustomJobInfo
      Dim objectType As TCompType
      Dim edmsObjectInfoRcw = GetRcwObjectInfo(id, objectType)

      Select Case objectType
        Case (TCompType.ctJob)
          Return New JobInfo(edmsObjectInfoRcw, Scope)
        Case (TCompType.ctNotice)
          Return New NoticeInfo(edmsObjectInfoRcw, Scope)
        Case (TCompType.ctControlJob)
          Return New ControlJobInfo(edmsObjectInfoRcw, Scope)
        Case Else
          Return New CustomJobInfo(edmsObjectInfoRcw, Scope)
      End Select
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwITaskFactory As Object, scope As IScope)
      MyBase.New(rcwITaskFactory, scope)
    End Sub
  End Class
End Namespace