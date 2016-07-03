Namespace Accessory
  ''' <summary>
  ''' Список.
  ''' </summary>
  Public Interface IList(Of Out T As IIsbComObjectWrapper)
    Inherits IForEach(Of T)
    ''' <summary>
    ''' Получить значение элемента списка по индексу.
    ''' </summary>
    ''' <param name="index">Индекс элемента в списке.</param>
    ''' <returns>Значение элемента с указанным индексом.</returns>
    Function GetValues(index As Integer) As T

    ''' <summary>
    ''' Установить значение элемента.
    ''' </summary>
    ''' <param name="name">Имя элемента.</param>
    ''' <param name="value">Значение элемента.</param>
    Sub SetVar(name As String, value As Object)
  End Interface
End NameSpace