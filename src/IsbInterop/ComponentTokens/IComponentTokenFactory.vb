Imports IsbInterop.Base

Namespace ComponentTokens
  ''' <summary>
  ''' Фабрика задач.
  ''' </summary>
  Public Interface IComponentTokenFactory
    Inherits IEdmsObjectFactory(Of IComponentToken, IComponentTokenInfo)

    ''' <summary>
    ''' Запустить компоненту.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    ''' <remarks>
    ''' Метод запускает компоненту с помощью варианта запуска, информация о котором была передана в параметре ObjectInfo.
    ''' </remarks>
    Sub Execute(objectInfo As IObjectInfo)

    ''' <summary>
    ''' Запустить компоненту в новом процессе.
    ''' </summary>
    ''' <param name="objectInfo">Информация о варианте запуска компоненты.</param>
    ''' <remarks>
    ''' Метод запускает компоненту в новом процессе Windows с помощью варианта запуска, 
    ''' информация о котором была передана в параметре ObjectInfo. 
    ''' Компонента запускается без ожидания завершения запущенного процесса.
    ''' </remarks>
    Sub ExecuteInNewProcess(objectInfo As IObjectInfo)
  End Interface
End Namespace