Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.References
Imports IsbInterop.References.Proxies

Namespace Data.Proxies

  ''' <summary>
  ''' Обертка над IDataSet.
  ''' </summary>
  Friend Class DataSet
    Inherits Query
    Implements IDataSet

#Region "Поля и свойства"

    ''' <summary>
    ''' Имя таблицы детального раздела.
    ''' </summary>
    Public ReadOnly Property SqlTableName As String Implements IDataSet.SqlTableName
      Get
        Return DirectCast(GetRcwProperty("SQLTableName"), String)
      End Get
    End Property

    ''' <summary>
    ''' Состояние.
    ''' </summary>
    Public ReadOnly Property State As TDataSetState Implements IDataSet.State
      Get
        Return GetRcwProperty("State")
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Добавляет запись.
    ''' </summary>
    Public Sub Append() Implements IDataSet.Append
      InvokeRcwInstanceMethod("Append")
    End Sub

    ''' <summary>
    ''' Применяет изменения.
    ''' </summary>
    Public Sub ApplyUpdates() Implements IDataSet.ApplyUpdates
      InvokeRcwInstanceMethod("ApplyUpdates")
    End Sub

    ''' <summary>
    ''' Закрывает запись.
    ''' </summary>
    Public Sub CloseRecord() Implements IDataSet.CloseRecord
      InvokeRcwInstanceMethod("CloseRecord")
    End Sub

    ''' <summary>
    ''' Получает компоненту.
    ''' </summary>
    ''' <returns>Компонента.</returns>
    Public Function GetComponent() As IComponent Implements IDataSet.GetComponent
      Dim requisiteRcw = GetRcwProperty("Component")
      Return New Component(requisiteRcw, Scope)
    End Function

    ''' <summary>
    ''' Получает реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Public Function GetRequisite(requisiteName As String) As IRequisite Implements IDataSet.GetRequisite
      Dim requisiteRcw = GetRcwProperty("Requisites", requisiteName)
      Return New Requisite(requisiteRcw, Scope)
    End Function

    ''' <summary>
    ''' Открывает запись.
    ''' </summary>
    Public Sub OpenRecord() Implements IDataSet.OpenRecord
      InvokeRcwInstanceMethod("OpenRecord")
    End Sub

    ''' <summary>
    ''' Обновляет детальный раздел.
    ''' </summary>
    Public Sub Refresh() Implements IDataSet.Refresh
      InvokeRcwInstanceMethod("Refresh")
    End Sub

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIDataSet">COM-объект IDataSet.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwIDataSet As Object, scope As IScope)
      MyBase.New(rcwIDataSet, scope)
    End Sub

#End Region

  End Class
End Namespace