Imports IsbInterop.Base

Namespace ComponentTokens

  ''' <summary>
  ''' Фабрика задач.
  ''' </summary>
  Public Interface IComponentTokenFactory
    Inherits IEdmsObjectFactory(Of IComponentToken, IComponentTokenInfo)

    ''' <summary>
    ''' Запускает компоненту.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    Sub Execute(objectInfo As IObjectInfo)

    ''' <summary>
    ''' Запускает компоненту в новом процессе.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    Sub ExecuteInNewProcess(objectInfo As IObjectInfo)
  End Interface
End Namespace