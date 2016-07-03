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
    Public ReadOnly Property SqlTableName() As String Implements IDataSet.SqlTableName
      Get
        Return DirectCast(Me.GetRcwProperty("SQLTableName"), String)
      End Get
    End Property

    ''' <summary>
    ''' Состояние.
    ''' </summary>
    Public ReadOnly Property State() As TDataSetState Implements IDataSet.State
      Get
        Return DirectCast(Me.GetRcwProperty("State"), TDataSetState)
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
      If Me.disposed Then
        Return
      End If

      If disposing Then
        Me.requisiteContainer.DisposeRequisites()
      End If

      Me.disposed = True

      MyBase.Dispose(disposing)
    End Sub

#End Region

#Region "IRequisiteContainer"

    Private ReadOnly requisiteContainer As IRequisiteContainer = New RequisiteContainer()

    ''' <summary>
    ''' Контейнер реквизитов.
    ''' </summary>
    Private ReadOnly Property LocalRequisiteContainer() As IRequisiteContainer Implements IRequisiteAutoCleaner.RequisiteContainer
      Get
        Return Me.requisiteContainer
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Добавить запись.
    ''' </summary>
    Public Sub Append() Implements IDataSet.Append
      Me.InvokeRcwInstanceMethod("Append")
    End Sub

    ''' <summary>
    ''' Применить изменения.
    ''' </summary>
    Public Sub ApplyUpdates() Implements IDataSet.ApplyUpdates
      Me.InvokeRcwInstanceMethod("ApplyUpdates")
    End Sub

    ''' <summary>
    ''' Закрыть запись.
    ''' </summary>
    Public Sub CloseRecord() Implements IDataSet.CloseRecord
      Me.InvokeRcwInstanceMethod("CloseRecord")
    End Sub

    ''' <summary>
    ''' Получить компоненту.
    ''' </summary>
    ''' <returns>Компонента.</returns>
    Public Function GetComponent() As IComponent Implements IDataSet.GetComponent
      Dim requisiteRcw = Me.GetRcwProperty("Component")
      Return New Component(requisiteRcw)
    End Function

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Public Function GetRequisite(requisiteName As String) As IRequisite Implements IDataSet.GetRequisite, IRequisiteAutoCleaner.GetRequisite
      Dim requisite = Me.requisiteContainer.GetRequisite(requisiteName, AddressOf Me.InternalGetRequisite)
      Return requisite
    End Function

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Private Function InternalGetRequisite(requisiteName As String) As Requisite
      Dim requisiteRcw = Me.GetRcwProperty("Requisites", requisiteName)
      Return New Requisite(requisiteRcw)
    End Function

    ''' <summary>
    ''' Открыть запись.
    ''' </summary>
    Public Sub OpenRecord() Implements IDataSet.OpenRecord
      Me.InvokeRcwInstanceMethod("OpenRecord")
    End Sub

    ''' <summary>
    ''' Обновить детальный раздел.
    ''' </summary>
    Public Sub Refresh() Implements IDataSet.Refresh
      Me.InvokeRcwInstanceMethod("Refresh")
    End Sub

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIDataSet">COM-объект IDataSet.</param>
    Friend Sub New(rcwIDataSet As Object)
      MyBase.New(rcwIDataSet)
    End Sub

#End Region

  End Class
End Namespace