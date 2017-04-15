Imports IsbInterop.References

Namespace Base

  ''' <summary>
  ''' Базовая фабрика объектов ЭДО.
  ''' </summary>
  ''' <typeparam name="T">Тип объекта фабрики.</typeparam>
  ''' <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  Public Interface IEdmsObjectFactory(Of Out T As IBaseIsbObject, Out TI As IObjectInfo)
    Inherits IFactory(Of T, TI)

    ''' <summary>
    ''' Удаляет объект.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <remarks>
    ''' Метод удаляет объект типа Kind с идентификатором ID. 
    ''' Если такого объекта не существует, то будет сгенерировано исключение. 
    ''' Для фабрики электронных документов IEDocumentFactory метод инициирует процессы:
    ''' «Открытие справочника», «Удаление записи справочника», «Закрытие справочника».
    ''' </remarks>
    Sub DeleteById(id As Integer)

    ''' <summary>
    ''' Получает историю работы с объектом.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Объект IComponent.</returns>
    ''' <remarks>
    ''' Получает историю работы с объектом типа Kind с идентификатором ID.
    ''' Если такого объекта не существует, то будет сгенерировано исключение.
    ''' </remarks>
    Function GetHistory(id As Integer) As IComponent
  End Interface
End Namespace