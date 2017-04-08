Imports IsbInterop.Base

Namespace Scripts
  ''' <summary>
  ''' Сценарий.
  ''' </summary>
  Public Interface IScript
    Inherits IObject(Of IObjectInfo)

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <returns>Результат.</returns>
    Function Execute() As IIsbComObjectWrapper

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    Function Execute(timeout As TimeSpan) As IIsbComObjectWrapper

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <returns>Результат.</returns>
    Function Execute(Of T As IIsbComObjectWrapper)() As T

    ''' <summary>
    ''' Выполнить скрипт.
    ''' </summary>
    ''' <typeparam name="T">Тип возвращаемого объекта.</typeparam>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>Результат.</returns>
    ''' <exception cref="IsbInteropException">Выбрасывает исключение, если не удалось привести результат к указанному типу.</exception>
    Function Execute(Of T As IIsbComObjectWrapper)(timeout As TimeSpan) As T

    ''' <summary>
    ''' Получить параметры.
    ''' </summary>
    ''' <returns>IsbObjectList.</returns>
    Overloads Function GetParams() As Accessory.IList(Of IIsbComObjectWrapper)
  End Interface
End Namespace