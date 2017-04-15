Namespace Accessory

  ''' <summary>
  ''' Список.
  ''' </summary>
  Public Interface IList(Of Out T As IBaseIsbObject)
    Inherits IForEach(Of T)

    ''' <summary>
    ''' Добавляет элемент в список.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметра.</typeparam>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Sub Add(Of TP As IBaseIsbObject)(name As String, value As TP)

    ''' <summary>
    ''' Добавляет элемент в список.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Sub Add(name As String, value As Object)

    ''' <summary>
    ''' Получает значение элемента списка по индексу.
    ''' </summary>
    ''' <param name="index">Индекс элемента в списке.</param>
    ''' <returns>Значение элемента с указанным индексом.</returns>
    Function GetValues(index As Integer) As T

    ''' <summary>
    ''' Получает значение элемента по имени.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <returns>Значение элемента.</returns>
    Function GetValueByName(name As String) As T

    ''' <summary>
    ''' Установливает значение элемента.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Sub SetVar(name As String, value As Object)
  End Interface
End Namespace