Imports IsbInterop.DataTypes.Enumerable

Namespace Base
  ''' <summary>
  ''' Базовая фабрика.
  ''' </summary>
  ''' <typeparam name="T">Тип объекта фабрики.</typeparam>
  ''' <typeparam name="TI">Тип, предоставляющий информацию об объекте фабрики.</typeparam>
  Public Interface IFactory(Of Out T As IIsbComObjectWrapper, Out TI As IObjectInfo)
    Inherits IIsbComObjectWrapper
    'Public Interface IFactory(Of Out T As IIsbComObjectWrapper)
    '    Inherits IIsbComObjectWrapper
    ''' <summary>
    ''' Тип объектов, к которым предоставляет доступ фабрика.
    ''' </summary>
    ReadOnly Property Kind() As TContentKind

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Function GetObjectById(id As Integer) As T

    ''' <summary>
    ''' Получить информацию об объекте по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Информация об объекте.</returns>
    Function GetObjectInfo(id As Integer) As TI
    'Function GetObjectInfo(Of TI As IObjectInfo)(id As Integer) As TI
  End Interface
End NameSpace