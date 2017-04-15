Imports IsbInterop.Base

Namespace Scripts

  ''' <summary>
  ''' Сценарий.
  ''' </summary>
  Public Interface IScript
    Inherits IObject(Of IObjectInfo)

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <returns>Результат.</returns>
    Function Execute() As IBaseIsbObject

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Function Execute(timeout As TimeSpan) As IBaseIsbObject

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <returns>Результат.</returns>
    Function Execute(Of T As IBaseIsbObject)() As T

    ''' <summary>
    ''' Выполняет скрипт.
    ''' </summary>
    ''' <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    ''' <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    Function Execute(Of T As IBaseIsbObject)(timeout As TimeSpan) As T

    ''' <summary>
    ''' Получает параметры.
    ''' </summary>
    ''' <returns>IsbObjectList.</returns>
    Overloads Function GetParams() As Accessory.IList(Of IBaseIsbObject)
  End Interface
End Namespace