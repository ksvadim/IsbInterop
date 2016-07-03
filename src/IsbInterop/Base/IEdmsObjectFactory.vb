Imports IsbInterop.References

Namespace Base
  ''' <summary>
  ''' Базовая фабрика объектов ЭДО.
  ''' </summary>
  ''' <typeparam name="T">Тип объекта фабрики.</typeparam>
  ''' <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  Public Interface IEdmsObjectFactory(Of Out T As IIsbComObjectWrapper, Out TI As IObjectInfo)
    Inherits IFactory(Of T, TI)
    ''' <summary>
    ''' Метод удаляет объект типа Kind с идентификатором ID. 
    ''' Если такого объекта не существует, то будет сгенерировано исключение. 
    ''' Для фабрики электронных документов IEDocumentFactory метод инициирует процессы «Открытие справочника», 
    ''' «Удаление записи справочника», «Закрытие справочника».
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    Sub DeleteById(id As Integer)

    ''' <summary>
    ''' Получить историю.
    ''' Возвращает историю работы с объектом типа Kind с идентификатором ID. 
    ''' Если такого объекта не существует, то будет сгенерировано исключение.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Объект IComponent.</returns>
    Function GetHistory(id As Integer) As IComponent
  End Interface
End NameSpace