Imports IsbInterop.Base.Wrappers

Namespace References.Wrappers
  ''' <summary>
  ''' Обертка над IReferenceFactory.
  ''' </summary>
  Friend Class ReferenceFactory
    Inherits Factory(Of IReference, IReferenceInfo)
    Implements IReferenceFactory

#Region "Поля и свойства"

    ''' <summary>
    ''' Получить имя фабрики.
    ''' </summary>
    Public ReadOnly Property Name() As String Implements IReferenceFactory.Name
      Get
        Return DirectCast(Me.GetRcwProperty("Name"), String)
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Создать запись справочника.
    ''' </summary>
    ''' <returns>Запись справочника.</returns>
    Public Function CreateNew() As IReference Implements IReferenceFactory.CreateNew
      Dim rcwReferenceEntry = Me.InvokeRcwInstanceMethod("CreateNew")
      Return New Reference(rcwReferenceEntry)
    End Function

    ''' <summary>
    ''' Получить историю записи справочника.
    ''' Возвращает компоненту История работы с записью для записи справочника. 
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Объект IComponent.</returns>
    Public Function GetHistory(id As Integer) As IComponent Implements IReferenceFactory.GetHistory
      Dim rcwComponent = Me.GetRcwProperty("History", id)
      Return New Component(rcwComponent)
    End Function

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As IReference
      Dim referenceRcw = Me.GetRcwObjectById(id)

      Return New Reference(referenceRcw)
    End Function

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IReferenceInfo
      Dim rcwIEdocumentInfo = Me.GetRcwObjectInfo(id)
      Return New ReferenceInfo(rcwIEdocumentInfo)
    End Function

    ''' <summary>
    ''' Удалить запись справочника по ИД.
    ''' </summary>
    ''' <param name="id">ИД записи справочника.</param>
    Public Sub DeleteById(id As Integer) Implements IReferenceFactory.DeleteById
      Me.InvokeRcwInstanceMethod("DeleteById", id)
    End Sub

    ''' <summary>
    ''' Получить компоненту справочника.
    ''' </summary>
    ''' <returns>Компонента справочника.</returns>
    Public Function GetComponent() As IReference Implements IReferenceFactory.GetComponent
      Dim rcwReference = Me.InvokeRcwInstanceMethod("GetComponent")
      Return New Reference(rcwReference)
    End Function

    ''' <summary>
    ''' Получить запись справочника по коду.
    ''' </summary>
    ''' <param name="referenceEntryCode">Код записи справочника.</param>
    ''' <returns>Запись справочника.</returns>
    Public Function GetObjectByCode(referenceEntryCode As String) As IReference Implements IReferenceFactory.GetObjectByCode
      Dim rcwReferenceEntry = Me.InvokeRcwInstanceMethod("GetObjectByCode", referenceEntryCode)
      Return New Reference(rcwReferenceEntry)
    End Function

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIReferenceFactory">COM-объект IReferenceFactory.</param>
    Friend Sub New(rcwIReferenceFactory As Object)
      MyBase.New(rcwIReferenceFactory)
    End Sub

#End Region

  End Class
End Namespace