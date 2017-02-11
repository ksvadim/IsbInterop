Imports System.Runtime.CompilerServices
Imports IsbInterop.Data
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.References

''' <summary>
''' Утилиты для работы со справочником.
''' </summary>
Public Module ReferenceUtils

    ''' <summary>
    '''  Добавить условие ограничения на реквизит в запрос набора данных справочника.
    ''' </summary>
    ''' <param name="reference">Справочник.</param>
    ''' <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    ''' <param name="restrictValue">Ограничивающее значение.</param>
    ''' <returns>ИД условия в запросе.</returns>
    <Extension>
    Public Function AddWhereWithRequisite(reference As IReference, requisite As IRequisite, restrictValue As Integer) As Integer
        If reference Is Nothing Then
            Throw New ArgumentNullException("reference")
        End If

        If requisite Is Nothing Then
            Throw New ArgumentNullException("requisite")
        End If

        Dim queryWhereSection = String.Format("{0}.{1} = {2}", reference.SqlTableName, requisite.FieldName, restrictValue)

        Return AddWhereSection(reference, queryWhereSection)
    End Function

    ''' <summary>
    '''  Добавить условие ограничения на реквизит в запрос набора данных справочника.
    ''' </summary>
    ''' <param name="reference">Справочник.</param>
    ''' <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    ''' <param name="restrictingValue">Ограничивающее значение.</param>
    ''' <returns>ИД условия в запросе.</returns>
    <Extension>
    Public Function AddWhereWithRequisite(reference As IReference, requisite As IRequisite, restrictingValue As String) As Integer
        If reference Is Nothing Then
            Throw New ArgumentNullException("reference")
        End If

        Dim requisiteSqlFieldValue = GetRequisiteSqlFieldValue(requisite, restrictingValue)
        Dim queryWhereSection = String.Format("{0}.{1} = '{2}'", reference.SqlTableName, requisite.FieldName, requisiteSqlFieldValue)

        Return AddWhereSection(reference, queryWhereSection)
    End Function

    ''' <summary>
    '''  Добавить условие ограничения на реквизит в запрос набора данных справочника.
    ''' </summary>
    ''' <param name="reference">Справочник.</param>
    ''' <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    ''' <param name="restrictingValues">Ограничивающие значения.</param>
    ''' <returns>ИД условия в запросе.</returns>
    <Extension>
    Public Function AddWhereWithRequisite(reference As IReference, requisite As IRequisite, restrictingValues As IEnumerable(Of String)) As Integer
        If reference Is Nothing Then
            Throw New ArgumentNullException("reference")
        End If

        If requisite Is Nothing Then
            Throw New ArgumentNullException("requisite")
        End If

        If Not restrictingValues.Any() Then
            Throw New ArgumentException("restrictingValues")
        End If

        Dim restrictingCondition = String.Join(", ", restrictingValues.[Select](Function(v) String.Format("'{0}'", GetRequisiteSqlFieldValue(requisite, v))))

        Dim queryWhereSection = String.Format("{0}.{1} in ({2})", reference.SqlTableName, requisite.FieldName, restrictingCondition)

        Return AddWhereSection(reference, queryWhereSection)
    End Function

    ''' <summary>
    '''  Добавить условие, что реквизит не ревен Null в запрос набора данных справочника.
    ''' </summary>
    ''' <param name="reference">Справочник.</param>
    ''' <param name="requisite">Реквизит справочника, по которому добавляется ограничение.</param>
    ''' <returns>ИД условия в запросе.</returns>
    <Extension>
    Public Function AddWhereWithRequisiteIsNotNull(reference As IReference, requisite As IRequisite) As Integer
        Dim queryWhereSection = String.Format("{0}.{1} is not null", reference.SqlTableName, requisite.FieldName)

        Return AddWhereSection(reference, queryWhereSection)
    End Function

      ''' <summary>
    ''' Получить значение sql-поля реквизита по именованному значению.
    ''' </summary>
    ''' <param name="requisite">Реквизит.</param>
    ''' <param name="namedValue">Именованное значение.</param>
    ''' <returns>Значение поля реквизита, записываемое в БД.</returns>
    Public Function GetRequisiteSqlFieldValue(requisite As IRequisite, namedValue As String) As String
        Try
            If requisite.DataType <> TReqDataType.rdtPick Then
                Return namedValue
            Else
                Dim possibleValues = DirectCast(requisite, IPickRequisite).Items
                Return possibleValues.IdByValue(namedValue)
            End If
        Catch ex As IsbInteropException
            Dim errorMessage = String.Format(My.Resources.Resources.UnableToGetRequisiteSqlFieldValueTemplate, requisite.Name, namedValue)
            Throw New IsbInteropException(errorMessage, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Добавить секцию Where в запрос набора данных справочника.
    ''' </summary>
    ''' <param name="reference">Справочник.</param>
    ''' <param name="queryWhereSection">Секция where запроса.</param>
    ''' <returns>ИД условия в запросе.</returns>
    Private Function AddWhereSection(reference As IReference, queryWhereSection As String) As Integer
        Try
            Return reference.AddWhere(queryWhereSection)
        Catch ex As IsbInteropException
            Dim errorMessage = String.Format(My.Resources.Resources.UnableToSpecifyDataSetQueryTemplate, reference.Name, queryWhereSection)
            Throw New IsbInteropException(errorMessage, ex.InnerException)
        End Try
    End Function
End Module
