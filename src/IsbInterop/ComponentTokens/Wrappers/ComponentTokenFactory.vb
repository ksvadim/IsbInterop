Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace ComponentTokens.Wrappers
  ''' <summary>
  ''' Обертка над IComponentTokenFactory.
  ''' </summary>
  Friend Class ComponentTokenFactory
    Inherits EdmsObjectFactory(Of IComponentToken, IComponentTokenInfo)
    Implements IComponentTokenFactory

    ''' <summary>
    ''' Запустить компоненту.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    Public Sub Execute(objectInfo As IObjectInfo) Implements IComponentTokenFactory.Execute
      Me.InvokeRcwInstanceMethod("Execute", DirectCast(objectInfo, IUnsafeRcwObjectAccessor).UnsafeRcwObject)
    End Sub

    ''' <summary>
    ''' Запустить компоненту в новом процессе.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    Public Sub ExecuteInNewProcess(objectInfo As IObjectInfo) Implements IComponentTokenFactory.ExecuteInNewProcess
      Me.InvokeRcwInstanceMethod("ExecuteInNewProcess", DirectCast(objectInfo, IUnsafeRcwObjectAccessor).UnsafeRcwObject)
    End Sub

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As IComponentToken
      Dim rcwComponentToken = Me.GetRcwObjectById(id)
      Return New ComponentToken(rcwComponentToken)
    End Function

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IComponentTokenInfo
      Dim rcwIComponentTokenInfo = Me.GetRcwObjectInfo(id)
      Return New ComponentTokenInfo(rcwIComponentTokenInfo)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIComponentTokenFactory">COM-объект IComponentTokenFactory.</param>
    Public Sub New(rcwIComponentTokenFactory As Object)
      MyBase.New(rcwIComponentTokenFactory)
    End Sub
  End Class
End Namespace