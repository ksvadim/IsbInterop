Namespace Accessory

  ''' <summary>
  ''' Однонаправленный список.
  ''' </summary>
  Public Interface IForEach(Of Out T As IIsbComObjectWrapper)
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Количество элементов в списке.
    ''' </summary>
    ReadOnly Property Count As Integer

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    ReadOnly Property EOF As Boolean

    ''' <summary>
    ''' Значение текущего элемента списка.
    ''' </summary>
    ReadOnly Property Value As T

    ''' <summary>
    ''' Перейти к следующему объекту набора данных.
    ''' </summary>
    Sub [Next]()

    ''' <summary>
    ''' Установить указатель текущего элемента списка на первый элемент списка.
    ''' </summary>
    Sub Reset()
  End Interface
End Namespace