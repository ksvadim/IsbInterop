Imports IsbInterop.Data
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.Presentation

Namespace Base
  ''' <summary>
  ''' Базовый объект.
  ''' </summary>
  Public Interface IObject(Of Out T As IObjectInfo)
    Inherits IIsbComObjectWrapper
    ''' <summary>
    ''' Признак открытости набора данных.
    ''' </summary>
    ReadOnly Property Active() As Boolean

    ''' <summary>
    ''' ИД объекта.
    ''' </summary>
    ReadOnly Property Id() As Integer

    ''' <summary>
    ''' Имя объекта.
    ''' </summary>
    ReadOnly Property Name() As String

    ''' <summary>
    ''' Имя таблицы объекта.
    ''' </summary>
    ReadOnly Property SqlTableName() As String

    ''' <summary>
    ''' Состояние.
    ''' </summary>
    ReadOnly Property State() As TDataSetState

    ''' <summary>
    ''' Добавить условие ограничения в запрос набора данных.
    ''' </summary>
    ''' <param name="condition">Условие ограничения выборки.</param>
    ''' <returns>Идентификатор условия в запросе.</returns>
    Function AddWhere(condition As String) As Integer

    ''' <summary>
    ''' Удалить условие ограничения набора данных.
    ''' </summary>
    ''' <param name="conditionId">Идентификатор условия в запросе, полученный при вызове метода AddWhere.</param>
    Sub DelWhere(conditionId As Integer)

    ''' <summary>
    ''' Получить детальный раздел.
    ''' </summary>
    ''' <param name="dataSetNumber">Номер детального раздела.</param>
    ''' <returns>Детальный раздел.</returns>
    Function GetDetailDataSet(dataSetNumber As Integer) As IDataSet

    ''' <summary>
    ''' Получить форму-карточку текущего представления объекта.
    ''' </summary>
    ''' <returns>Форма-карточка.</returns>
    Function GetForm() As IForm

    ''' <summary>
    ''' Получить информацию об объекте.
    ''' </summary>
    ''' <returns>Info-объект.</returns>
    Function GetInfo() As T

    ''' <summary>
    ''' Получить реквизит набора данных.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Function GetRequisite(requisiteName As String) As IRequisite

    ''' <summary>
    ''' Обновить набор данных.
    ''' </summary>
    Sub Refresh()

    ''' <summary>
    ''' Завершить работу с объектом.
    ''' </summary>
    ''' <remarks>Имя метод изменено, т.к. в VB.Net Finalize соответствует деструктору.</remarks>
    Sub DoFinalize()

    ''' <summary>
    ''' Сохранить объект.
    ''' </summary>
    Sub Save()
  End Interface
End NameSpace