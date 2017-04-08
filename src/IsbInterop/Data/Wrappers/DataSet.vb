Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.References
Imports IsbInterop.References.Wrappers

Namespace Data.Wrappers

  ''' <summary>
  ''' Обертка над IDataSet.
  ''' </summary>
  Friend Class DataSet
    Inherits Query
    Implements IDataSet
    Implements IRequisiteAutoCleaner

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

#Region "IDisposable"

    Private disposed As Boolean = False

    ''' <summary>
    ''' Очистка.
    ''' </summary>
    ''' <param name="disposing">Флаг вызова метода Dispose.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
      If disposed Then
        Return
      End If

      If disposing Then
        requisiteContainer.DisposeRequisites()
      End If

      disposed = True

      MyBase.Dispose(disposing)
    End Sub

#End Region

#Region "IRequisiteContainer"

    Private ReadOnly requisiteContainer As IRequisiteContainer = New RequisiteContainer()

    ''' <summary>
    ''' Контейнер реквизитов.
    ''' </summary>
    Private ReadOnly Property LocalRequisiteContainer As IRequisiteContainer Implements IRequisiteAutoCleaner.RequisiteContainer
      Get
        Return requisiteContainer
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Добавить запись.
    ''' </summary>
    Public Sub Append() Implements IDataSet.Append
      InvokeRcwInstanceMethod("Append")
    End Sub

    ''' <summary>
    ''' Применить изменения.
    ''' </summary>
    Public Sub ApplyUpdates() Implements IDataSet.ApplyUpdates
      InvokeRcwInstanceMethod("ApplyUpdates")
    End Sub

    ''' <summary>
    ''' Закрыть запись.
    ''' </summary>
    Public Sub CloseRecord() Implements IDataSet.CloseRecord
      InvokeRcwInstanceMethod("CloseRecord")
    End Sub

    ''' <summary>
    ''' Получить компоненту.
    ''' </summary>
    ''' <returns>Компонента.</returns>
    Public Function GetComponent() As IComponent Implements IDataSet.GetComponent
      Dim requisiteRcw = GetRcwProperty("Component")
      Return New Component(requisiteRcw, Scope)
    End Function

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Public Function GetRequisite(requisiteName As String) As IRequisite Implements IDataSet.GetRequisite, IRequisiteAutoCleaner.GetRequisite
      Dim requisite = requisiteContainer.GetRequisite(requisiteName, AddressOf InternalGetRequisite)
      Return requisite
    End Function

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Private Function InternalGetRequisite(requisiteName As String) As Requisite
      Dim requisiteRcw = GetRcwProperty("Requisites", requisiteName)
      Return New Requisite(requisiteRcw, Scope)
    End Function

    ''' <summary>
    ''' Открыть запись.
    ''' </summary>
    Public Sub OpenRecord() Implements IDataSet.OpenRecord
      InvokeRcwInstanceMethod("OpenRecord")
    End Sub

    ''' <summary>
    ''' Обновить детальный раздел.
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