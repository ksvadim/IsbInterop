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
    ReadOnly Property Active As Boolean

    ''' <summary>
    ''' Тип объекта.
    ''' </summary>
    ReadOnly Property ComponentType As TCompType

    ''' <summary>
    ''' ИД.
    ''' </summary>
    ReadOnly Property Id As Integer

    ''' <summary>
    ''' Имя объекта.
    ''' </summary>
    ReadOnly Property Name As String

    ''' <summary>
    ''' Имя таблицы в базе данных.
    ''' </summary>
    ReadOnly Property SqlTableName As String

    ''' <summary>
    ''' Состояние набора данных.
    ''' </summary>
    ReadOnly Property State As TDataSetState

    ''' <summary>
    ''' Добавляет условие ограничения в запрос набора данных.
    ''' </summary>
    ''' <param name="condition">Условие ограничения выборки.</param>
    ''' <returns>Идентификатор условия в запросе.</returns>
    Function AddWhere(condition As String) As Integer

    ''' <summary>
    ''' Удаляет условие ограничения набора данных.
    ''' </summary>
    ''' <param name="conditionId">Идентификатор условия в запросе, полученный при вызове метода AddWhere.</param>
    Sub DelWhere(conditionId As Integer)

    ''' <summary>
    ''' Завершает работу с объектом.
    ''' </summary>
    ''' <remarks>Имя метод изменено, т.к. в VB.Net Finalize соответствует деструктору.</remarks>
    Sub DoFinalize()

    ''' <summary>
    ''' Получает детальный раздел набора данных.
    ''' </summary>
    ''' <param name="dataSetNumber">Номер детального раздела.</param>
    ''' <returns>Детальный раздел.</returns>
    Function GetDetailDataSet(dataSetNumber As Integer) As IDataSet

    ''' <summary>
    ''' Получает окружение.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметров.</typeparam>
    ''' <returns>Список переменных окружения объекта.</returns>
    Function GetEnvironment(Of TP As IIsbComObjectWrapper)() As Accessory.IList(Of TP)

    ''' <summary>
    ''' Получает форму-карточку текущего представления объекта.
    ''' </summary>
    ''' <returns>Форма-карточка.</returns>
    Function GetForm() As IForm

    ''' <summary>
    ''' Получает параметры объекта.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметров.</typeparam>
    ''' <returns>Список параметров объекта.</returns>
    Function GetParams(Of TP As IIsbComObjectWrapper)() As Accessory.IList(Of TP)

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <returns>Информация об объекте.</returns>
    Function GetInfo() As T

    ''' <summary>
    ''' Получает реквизит набора данных.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Function GetRequisite(requisiteName As String) As IRequisite

    ''' <summary>
    ''' Обновляет набор данных.
    ''' </summary>
    Sub Refresh()

    ''' <summary>
    ''' Сохраняет объект.
    ''' </summary>
    Sub Save()
  End Interface
End Namespace