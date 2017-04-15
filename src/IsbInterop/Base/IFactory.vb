Imports IsbInterop.DataTypes.Enumerable

Namespace Base

  ''' <summary>
  ''' Базовая фабрика.
  ''' </summary>
  ''' <typeparam name="T">Тип объекта фабрики.</typeparam>
  ''' <typeparam name="TI">Тип, предоставляющий информацию об объекте фабрики.</typeparam>
  Public Interface IFactory(Of Out T As IBaseIsbObject, Out TI As IObjectInfo)
    Inherits IBaseIsbObject

    ''' <summary>
    ''' Тип объектов, к которым предоставляет доступ фабрика.
    ''' </summary>
    ReadOnly Property Kind As TContentKind

    ''' <summary>
    ''' Получить объект по ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Function GetObjectById(id As Integer) As T

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Информация об объекте.</returns>
    Function GetObjectInfo(id As Integer) As TI
  End Interface
End Namespace