Imports IsbInterop.Data

''' <summary>
''' Интерфейс контейнера реквизитов.
''' </summary>
Friend Interface IRequisiteContainer
    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <param name="getRequisiteCallback">Callback для получения реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Function GetRequisite(requisiteName As String, getRequisiteCallback As Func(Of String, IRequisite)) As IRequisite

    ''' <summary>
    ''' Освободить реквизиты.
    ''' </summary>
    Sub DisposeRequisites()
End Interface