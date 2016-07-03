Imports IsbInterop.Data

Namespace References.Wrappers
  ''' <summary>
  ''' Обертка над IReference.
  ''' </summary>
  Friend Class Reference
    Inherits Component
    Implements IReference
    Implements IRequisiteAutoCleaner

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
    ''' Кэш реквизитов.
    ''' </summary>
    Private ReadOnly Property LocalRequisiteContainer() As IRequisiteContainer Implements IRequisiteAutoCleaner.RequisiteContainer
      Get
        Return Me.requisiteContainer
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Public Overrides Function GetRequisite(requisiteName As String) As IRequisite Implements IRequisiteAutoCleaner.GetRequisite
      Dim requisite = Me.requisiteContainer.GetRequisite(requisiteName, AddressOf MyBase.GetRequisite)
      Return requisite
    End Function

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="reference">Справочник DIRECTUM.</param>
    Public Sub New(reference As Object)
      MyBase.New(reference)
    End Sub

#End Region

  End Class
End Namespace
