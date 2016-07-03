Imports IsbInterop.Data

''' <summary>
''' Интерфейс объекта, поддерживающего автоматичесую очистку реквизитов.
''' </summary>
Friend Interface IRequisiteAutoCleaner
    Inherits IDisposable
    ''' <summary>
    ''' Контейнер реквизитов.
    ''' </summary>
    ReadOnly Property RequisiteContainer() As IRequisiteContainer

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <remarks>Внимание! Этот метод должен вызывать методы RequisiteContainer
    ''' для получения реквизитов.</remarks>
    Function GetRequisite(requisiteName As String) As IRequisite
End Interface