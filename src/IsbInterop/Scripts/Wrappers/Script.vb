Imports IsbInterop.Accessory
Imports IsbInterop.Accessory.Wrappers
Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace Scripts.Wrappers
  ''' <summary>
  ''' Обертка над IScript.
  ''' </summary>
  Friend Class Script
    Inherits IsbObject(Of IObjectInfo)
    Implements IScript

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <returns>Результат.</returns>
    Public Function Execute() As IIsbComObjectWrapper Implements IScript.Execute
      Dim rcwObjectResult = Me.InvokeRcwInstanceMethod("Execute", Nothing, Nothing)
      Return New EmptyIsbObject(rcwObjectResult)
    End Function

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Public Function Execute(timeout As TimeSpan) As IIsbComObjectWrapper Implements IScript.Execute
      Dim rcwObjectResult = Me.InvokeRcwInstanceMethod("Execute", Nothing, timeout)
      Return New EmptyIsbObject(rcwObjectResult)
    End Function

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    ''' <returns>Результат.</returns>
    ''' <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    Public Function Execute(Of T As IIsbComObjectWrapper)() As T Implements IScript.Execute
      Dim rcwObjectResult = Me.InvokeRcwInstanceMethod("Execute", Nothing, Nothing)
      Return IsbObjectResolver.Resolve(Of T)(rcwObjectResult)
    End Function

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    ''' <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    Public Function Execute(Of T As IIsbComObjectWrapper)(timeout As TimeSpan) As T Implements IScript.Execute
      Dim rcwObjectResult = Me.InvokeRcwInstanceMethod("Execute", Nothing, timeout)
      Return IsbObjectResolver.Resolve(Of T)(rcwObjectResult)
    End Function


    ''' <summary>
    ''' Получить IObjectInfo.
    ''' </summary>
    ''' <returns>IObjectInfo.</returns>
    Public Overrides Function GetInfo() As IObjectInfo
      Throw New NotSupportedException("This method is not supported by IS-Builder API.")
    End Function


    ''' <summary>
    ''' Получить параметры.
    ''' </summary>
    ''' <returns>IsbObjectList.</returns>
    Public Function GetParams() As IList(Of IIsbComObjectWrapper) Implements IScript.GetParams
      Dim parameters = Me.GetRcwProperty("Params")
      Return New List(Of IIsbComObjectWrapper)(parameters)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="script">Скрипт DIRECTUM.</param>
    Public Sub New(script As Object)
      MyBase.New(script)
    End Sub

  End Class
End Namespace