Imports IsbInterop.Data

''' <summary>
''' Контейнер реквизитов.
''' </summary>
Friend Class RequisiteContainer
    Implements IRequisiteContainer
    ''' <summary>
    ''' Кэш реквизитов.
    ''' </summary>
    Private ReadOnly requisitesCache As New Stack(Of IRequisite)()

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <param name="getRequisiteCallback">Callback для получения реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Public Function GetRequisite(requisiteName As String, getRequisiteCallback As Func(Of String, IRequisite)) As IRequisite Implements IRequisiteContainer.GetRequisite
        Dim requisite = getRequisiteCallback(requisiteName)
        Me.requisitesCache.Push(requisite)

        Return requisite
    End Function

    ''' <summary>
    ''' Освободить кэш реквизитов.
    ''' </summary>
    Public Sub DisposeRequisitesCache() Implements IRequisiteContainer.DisposeRequisites
        While requisitesCache.Count > 0
            Dim requisite = requisitesCache.Pop()
            Try
                requisite.Dispose()
                ' Гасим исключение, если объект уже освобожден.
            Catch exception As ObjectDisposedException
            End Try
        End While

        requisitesCache.Clear()
    End Sub
End Class