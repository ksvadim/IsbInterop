﻿Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace Scripts.Wrappers

  ''' <summary>
  ''' Обертка над IScript.
  ''' </summary>
  Friend Class Script
    Inherits IsbObject(Of IObjectInfo)
    Implements IScript

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <returns>Результат.</returns>
    Public Function Execute() As IIsbComObjectWrapper Implements IScript.Execute
      Dim rcwObjectResult = InvokeRcwInstanceMethod("Execute", Nothing, Nothing)
      Return New BaseIsbObjectWrapper(rcwObjectResult, Scope)
    End Function

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Public Function Execute(timeout As TimeSpan) As IIsbComObjectWrapper Implements IScript.Execute
      Dim rcwObjectResult = InvokeRcwInstanceMethod("Execute", Nothing, timeout)
      Return New BaseIsbObjectWrapper(rcwObjectResult, Scope)
    End Function

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    ''' <returns>Результат.</returns>
    ''' <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    Public Function Execute(Of T As IIsbComObjectWrapper)() As T Implements IScript.Execute
      Dim rcwObjectResult = InvokeRcwInstanceMethod("Execute", Nothing, Nothing)
      Return IsbObjectResolver.Resolve(Of T)(rcwObjectResult, Scope)
    End Function

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    ''' <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    Public Function Execute(Of T As IIsbComObjectWrapper)(timeout As TimeSpan) As T Implements IScript.Execute
      Dim rcwObjectResult = InvokeRcwInstanceMethod("Execute", Nothing, timeout)
      Return IsbObjectResolver.Resolve(Of T)(rcwObjectResult, Scope)
    End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Public Overrides Function GetInfo() As IObjectInfo
      Throw New NotSupportedException("This method is not supported by IS-Builder API.")
    End Function

    ''' <summary>
    ''' Получает параметры.
    ''' </summary>
    ''' <returns>IsbObjectList.</returns>
    Public Overloads Function GetParams() As Accessory.IList(Of IIsbComObjectWrapper) Implements IScript.GetParams
      Return MyBase.GetParams(Of IIsbComObjectWrapper)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="script">Скрипт DIRECTUM.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(script As Object, scope As IScope)
      MyBase.New(script, scope)
    End Sub
  End Class
End Namespace