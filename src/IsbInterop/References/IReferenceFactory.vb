﻿Imports IsbInterop.Base

Namespace References
  ''' <summary>
  ''' Фабрика справочников.
  ''' </summary>
  Public Interface IReferenceFactory
    Inherits IFactory(Of IReference, IReferenceInfo)

    ''' <summary>
    ''' Получить имя фабрики.
    ''' </summary>
    ReadOnly Property Name() As String

    ''' <summary>
    ''' Получить историю записи справочника.
    ''' Возвращает компоненту История работы с записью для записи справочника. 
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Объект IComponent.</returns>
    Function GetHistory(id As Integer) As IComponent

    ''' <summary>
    ''' Создать запись справочника.
    ''' </summary>
    ''' <returns>Запись справочника.</returns>
    ''' <remarks>
    ''' Результатом метода является объект IReference, 
    ''' набор данных которого содержит одну новую запись и находится в режиме вставки. 
    ''' Метод инициирует процессы открытия справочника и добавления записи справочника.
    ''' После заполнения реквизитов следует либо сохранить изменения методами IObject.Save, IDataSet.ApplyUpdates,
    ''' либо откатить методами IObject.Cancel, IDataSet.CancelUpdates.
    '''</remarks>
    Function CreateNew() As IReference

    ''' <summary>
    ''' Удалить запись справочника по ИД.
    ''' </summary>
    ''' <param name="id">ИД записи справочника.</param>
    Sub DeleteById(id As Integer)

    ''' <summary>
    ''' Получить компоненту справочника.
    ''' </summary>
    ''' <returns>Компонента справочника.</returns>
    Function GetComponent() As IReference

    ''' <summary>
    ''' Получить объект по коду.
    ''' </summary>
    ''' <param name="code">Код.</param>
    ''' <returns>Объект.</returns>
    Function GetObjectByCode(code As String) As IReference
  End Interface
End NameSpace