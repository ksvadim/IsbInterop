Namespace ServiceForms

  ''' <summary>
  ''' Фабрика служебных объектов.
  ''' </summary>
  Public Interface IServiceFactory
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Получает проводник системы.
    ''' </summary>
    ''' <param name="isMain">Признак получения главной формы проводника системы.</param>
    ''' <returns>Проводник системы.</returns>
    Function GetExplorer(isMain As Boolean) As IEdmsExplorer
  End Interface
End NameSpace