﻿Imports IsbInterop.Base.Wrappers

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
    Public ReadOnly Property Name As String Implements IReferenceFactory.Name
      Get
        Return DirectCast(GetRcwProperty("Name"), String)
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Создать запись справочника.
    ''' </summary>
    ''' <returns>Запись справочника.</returns>
    Public Function CreateNew() As IReference Implements IReferenceFactory.CreateNew
      Dim rcwReferenceEntry = InvokeRcwInstanceMethod("CreateNew")
      Return New Reference(rcwReferenceEntry, Scope)
    End Function

    ''' <summary>
    ''' Получить историю записи справочника.
    ''' Возвращает компоненту История работы с записью для записи справочника. 
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Объект IComponent.</returns>
    Public Function GetHistory(id As Integer) As IComponent Implements IReferenceFactory.GetHistory
      Dim rcwComponent = GetRcwProperty("History", id)
      Return New Component(rcwComponent, Scope)
    End Function

    ''' <summary>
    ''' Получить объект по его ИД.
    ''' </summary>
    ''' <param name="id">ИД.</param>
    ''' <returns>Объект.</returns>
    Public Overrides Function GetObjectById(id As Integer) As IReference
      Dim referenceRcw = GetRcwObjectById(id)

      Return New Reference(referenceRcw, Scope)
    End Function

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IReferenceInfo
      Dim rcwIEdocumentInfo = GetRcwObjectInfo(id)
      Return New ReferenceInfo(rcwIEdocumentInfo, Scope)
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
      Dim rcwReference = InvokeRcwInstanceMethod("GetComponent")
      Return New Reference(rcwReference, Scope)
    End Function

    ''' <summary>
    ''' Получить запись справочника по коду.
    ''' </summary>
    ''' <param name="referenceEntryCode">Код записи справочника.</param>
    ''' <returns>Запись справочника.</returns>
    Public Function GetObjectByCode(referenceEntryCode As String) As IReference Implements IReferenceFactory.GetObjectByCode
      Dim rcwReferenceEntry = InvokeRcwInstanceMethod("GetObjectByCode", referenceEntryCode)
      Return New Reference(rcwReferenceEntry, Scope)
    End Function

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIReferenceFactory">COM-объект IReferenceFactory.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwIReferenceFactory As Object, scope As IScope)
      MyBase.New(rcwIReferenceFactory, scope)
    End Sub

#End Region

  End Class
End Namespace