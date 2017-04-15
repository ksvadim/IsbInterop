Imports System.Runtime.CompilerServices
Imports IsbInterop.Data
Imports IsbInterop.DataTypes.Enumerable

Namespace Extensions

  ''' <summary>
  ''' Методы расширения для работы с набором данных.
  ''' </summary>
  Public Module DataSetExtensions

    ''' <summary>
    '''  Добавляет условие ограничения на реквизит в запрос детального набора данных справочника.
    ''' </summary>
    ''' <param name="detailDataSet">Детальный набор данных.</param>
    ''' <param name="requisite">Реквизит, по которому добавляется ограничение.</param>
    ''' <param name="restrictValue">Ограничивающее значение.</param>
    ''' <returns>ИД условия в запросе.</returns>
    <Extension>
    Public Function AddWhereWithRequisite(detailDataSet As IDataSet, requisite As IRequisite, restrictValue As Integer) As Integer
      Dim queryWhereSection = String.Format("{0}.{1} = {2}", detailDataSet.SqlTableName, requisite.FieldName, restrictValue)
      Try
        Dim conditionId As Integer = detailDataSet.AddWhere(queryWhereSection)

        Return conditionId
      Catch ex As IsbInteropException
        Dim componentName As String = "Unknown"
        Try
          Using component = detailDataSet.GetComponent()
            componentName = component.Name
          End Using
          ' Гасим исключение.
        Catch generatedExceptionName As IsbInteropException
        End Try

        Dim errorMessage = String.Format(My.Resources.Resources.UnableToSpecifyDataSetQueryTemplate, componentName, queryWhereSection)
        Throw New IsbInteropException(errorMessage, ex.InnerException)
      End Try
    End Function

    ''' <summary>
    '''  Добавляет условие ограничения на реквизит в запрос детального набора данных справочника.
    ''' </summary>
    ''' <param name="detailDataSet">Детальный набор данных.</param>
    ''' <param name="requisite">Реквизит, по которому добавляется ограничение.</param>
    ''' <param name="restrictValue">Ограничивающее значение.</param>
    ''' <returns>ИД условия в запросе.</returns>
    <Extension>
    Public Function AddWhereWithRequisite(detailDataSet As IDataSet, requisite As IRequisite, restrictValue As String) As Integer
      If detailDataSet Is Nothing Then
        Throw New ArgumentNullException("detailDataSet")
      End If

      Dim dbRestrictValue = restrictValue

      If requisite.DataType = TReqDataType.rdtPick Then
        Dim possibleValues = DirectCast(requisite, IPickRequisite).Items
        Try
          dbRestrictValue = possibleValues.IdByValue(restrictValue)
        Catch ex As IsbInteropException
          Dim errorMessage = String.Format(My.Resources.Resources.UnableToGetRequisiteSqlFieldValueTemplate, requisite.Name, restrictValue)
          Throw New IsbInteropException(errorMessage, ex.InnerException)
        End Try
      End If

      Dim queryWhereSection = String.Format("{0}.{1} = '{2}'", detailDataSet.SqlTableName, requisite.FieldName, dbRestrictValue)

      Try
        Dim conditionId As Integer = detailDataSet.AddWhere(queryWhereSection)

        Return conditionId
      Catch ex As IsbInteropException
        Dim componentName As String = "Unknown"
        Try
          Using component = detailDataSet.GetComponent()
            componentName = component.Name
          End Using
          ' Гасим исключение.
        Catch generatedExceptionName As IsbInteropException
        End Try

        Dim errorMessage = String.Format(My.Resources.Resources.UnableToSpecifyDataSetQueryTemplate, componentName, queryWhereSection)
        Throw New IsbInteropException(errorMessage, ex.InnerException)
      End Try
    End Function

    ''' <summary>
    ''' Удаляет ограничение Where из запроса детального набора данных справочника.
    ''' </summary>
    ''' <param name="detailDataSet">Детальный набор данных.</param>
    ''' <param name="queryConditionId">ИД условия в запросе.</param>
    <Extension>
    Public Sub DeleteAddWhere(detailDataSet As IDataSet, queryConditionId As Integer)
      Try
        detailDataSet.DelWhere(queryConditionId)
      Catch ex As IsbInteropException
        Dim [error] = String.Format(My.Resources.Resources.UnableToDeleteDetailDataSetQueryConstraint)
        Throw New IsbInteropException([error], ex.InnerException)
      End Try
    End Sub
  End Module
End NameSpace