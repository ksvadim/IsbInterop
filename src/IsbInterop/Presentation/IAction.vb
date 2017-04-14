Namespace Presentation

  ''' <summary>
  ''' Действие формы.
  ''' </summary>
  Public Interface IAction
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Выполняет действие.
    ''' </summary>
    ''' <returns>True, если действие было выполнено, иначе false.</returns>
    Function Execute() As Boolean

    ''' <summary>
    ''' Выполняет действие.
    ''' </summary>
    ''' <param name="timeout">Таймаут.</param>
    ''' <returns>True, если действие было выполнено, иначе false.</returns>
    Function Execute(timeout As TimeSpan) As Boolean
  End Interface
End Namespace