Imports IsbInterop.References
Imports IsbInterop.References.Wrappers

Namespace Base.Wrappers

  ''' <summary>
  ''' Обертка над IEdmsObjectFactory.
  ''' </summary>
  ''' <typeparam name="T">Тип объекта фабрики.</typeparam>
  ''' <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
  Friend MustInherit Class EdmsObjectFactory(Of T As IBaseIsbObject, TI As IEdmsObjectInfo)
    Inherits Factory(Of T, TI)
    Implements IEdmsObjectFactory(Of T, TI)

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
    Public Sub DeleteById(id As Integer) Implements IEdmsObjectFactory(Of T, TI).DeleteById
      InvokeRcwInstanceMethod("DeleteByID", id)
    End Sub

    ''' <summary>
    ''' Получает историю работы с объектом.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Объект IComponent.</returns>
    ''' <remarks>
    ''' Получает историю работы с объектом типа Kind с идентификатором ID.
    ''' Если такого объекта не существует, то будет сгенерировано исключение.
    ''' </remarks>
    Public Function GetHistory(id As Integer) As IComponent Implements IEdmsObjectFactory(Of T, TI).GetHistory
      Dim rcwComponent = GetRcwProperty("History", id)
      Return New Component(rcwComponent, Scope)
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwEdmsObjectFactory">COM-объект фабрики.</param>
    ''' <param name="scope">Область видимости.</param>
    Protected Sub New(rcwEdmsObjectFactory As Object, scope As IScope)
      MyBase.New(rcwEdmsObjectFactory, scope)
    End Sub
  End Class
End Namespace