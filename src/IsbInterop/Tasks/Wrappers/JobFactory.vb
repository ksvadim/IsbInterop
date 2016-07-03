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
      Dim edmsObjectRcw = Me.GetRcwObjectById(id, objectType)
      Select Case objectType
        Case (TCompType.ctJob)
          Return New Job(edmsObjectRcw)
        Case (TCompType.ctNotice)
          Return New Notice(edmsObjectRcw)
        Case (TCompType.ctControlJob)
          Return New ControlJob(edmsObjectRcw)
        Case Else
          Return New DefaultCustomJob(edmsObjectRcw)
      End Select
    End Function

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As ICustomJobInfo
      Dim objectType As TCompType
      Dim edmsObjectInfoRcw = Me.GetRcwObjectInfo(id, objectType)
      Select Case objectType
        Case (TCompType.ctJob)
          Return New JobInfo(edmsObjectInfoRcw)
        Case (TCompType.ctNotice)
          Return New NoticeInfo(edmsObjectInfoRcw)
        Case (TCompType.ctControlJob)
          Return New ControlJobInfo(edmsObjectInfoRcw)
        Case Else
          Return New CustomJobInfo(edmsObjectInfoRcw)
      End Select
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    Public Sub New(rcwITaskFactory As Object)
      MyBase.New(rcwITaskFactory)
    End Sub
  End Class
End Namespace