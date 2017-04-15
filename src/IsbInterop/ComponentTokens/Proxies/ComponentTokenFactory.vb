Imports IsbInterop.Base
Imports IsbInterop.Base.Proxies

Namespace ComponentTokens.Proxies

  ''' <summary>
  ''' Обертка над IComponentTokenFactory.
  ''' </summary>
  Friend Class ComponentTokenFactory
    Inherits EdmsObjectFactory(Of IComponentToken, IComponentTokenInfo)
    Implements IComponentTokenFactory

    ''' <summary>
    ''' Запускает компоненту.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    Public Sub Execute(objectInfo As IObjectInfo) Implements IComponentTokenFactory.Execute
      InvokeRcwInstanceMethod("Execute", DirectCast(objectInfo, IRcwProxy).RcwObject)
    End Sub

    ''' <summary>
    ''' Запускает компоненту в новом процессе.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    Public Sub ExecuteInNewProcess(objectInfo As IObjectInfo) Implements IComponentTokenFactory.ExecuteInNewProcess
      InvokeRcwInstanceMethod("ExecuteInNewProcess", DirectCast(objectInfo, IRcwProxy).RcwObject)
    End Sub

    ''' <summary>
    ''' Получает объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As IComponentToken
      Dim rcwComponentToken = GetRcwObjectById(id)
      Return New ComponentToken(rcwComponentToken, Scope)
    End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IComponentTokenInfo
      Dim rcwIComponentTokenInfo = GetRcwObjectInfo(id)
      Return New ComponentTokenInfo(rcwIComponentTokenInfo, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIComponentTokenFactory">COM-объект IComponentTokenFactory.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(rcwIComponentTokenFactory As Object, scope As IScope)
      MyBase.New(rcwIComponentTokenFactory, scope)
    End Sub
  End Class
End Namespace