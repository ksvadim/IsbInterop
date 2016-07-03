Imports IsbInterop.References
Imports IsbInterop.References.Wrappers

Namespace Base.Wrappers
    ''' <summary>
    ''' Обертка над IEdmsObjectFactory.
    ''' </summary>
    ''' <typeparam name="T">Тип объекта фабрики.</typeparam>
    ''' <typeparam name="TI">Тип, предоставляющий информацию об объекте ЭДО.</typeparam>
    Friend MustInherit Class EdmsObjectFactory(Of T As IIsbComObjectWrapper, TI As IEdmsObjectInfo)
        Inherits Factory(Of T, TI)
        Implements IEdmsObjectFactory(Of T, TI)
        ''' <summary>
        ''' Метод удаляет объект типа Kind с идентификатором ID. 
        ''' Если такого объекта не существует, то будет сгенерировано исключение. 
        ''' Для фабрики электронных документов IEDocumentFactory метод инициирует процессы «Открытие справочника», «Удаление записи справочника», «Закрытие справочника».
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        Public Sub DeleteById(id As Integer) Implements IEdmsObjectFactory(Of T, TI).DeleteById
            Me.InvokeRcwInstanceMethod("DeleteByID", id)
        End Sub

        ''' <summary>
        ''' Получить историю.
        ''' Возвращает историю работы с объектом типа Kind с идентификатором ID. 
        ''' Если такого объекта не существует, то будет сгенерировано исключение.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <returns>Объект IComponent.</returns>
        Public Function GetHistory(id As Integer) As IComponent Implements IEdmsObjectFactory(Of T, TI).GetHistory
            Dim rcwComponent = Me.GetRcwProperty("History", id)
            Return New Component(rcwComponent)
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwEdmsObjectFactory">COM-объект фабрики.</param>
        Protected Sub New(rcwEdmsObjectFactory As Object)
            MyBase.New(rcwEdmsObjectFactory)
        End Sub
    End Class

End Namespace