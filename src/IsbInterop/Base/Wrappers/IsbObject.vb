Imports IsbInterop.Data
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.Presentation
Imports IsbInterop.Presentation.Wrappers

Namespace Base.Wrappers
  ''' <summary>
  ''' Обертка над IObject.
  ''' </summary>
  Friend MustInherit Class IsbObject(Of TI As IObjectInfo)
    Inherits IsbComObjectWrapper
    Implements IObject(Of TI)

    #Region "Поля и свойства"

    ''' <summary>
    ''' Признак открытости набора данных.
    ''' </summary>
    Public ReadOnly Property Active As Boolean Implements IObject(Of TI).Active
      Get
        Return GetRcwProperty("Active")
      End Get
    End Property

    ''' <summary>
    ''' ИД объекта.
    ''' </summary>
    Public ReadOnly Property Id As Integer Implements IObject(Of TI).Id
      Get
        Return GetRcwProperty("ID")
      End Get
    End Property

    ''' <summary>
    ''' Имя объекта.
    ''' </summary>
    Public ReadOnly Property Name As String Implements IObject(Of TI).Name
      Get
        Return DirectCast(GetRcwProperty("Name"), String)
      End Get
    End Property

    ''' <summary>
    ''' Состояние.
    ''' </summary>
    Public ReadOnly Property State As TDataSetState Implements IObject(Of TI).State
      Get
        Return GetRcwProperty("State")
      End Get
    End Property

    ''' <summary>
    ''' Тип объекта.
    ''' </summary>
    Public ReadOnly Property ComponentType As TCompType
      Get
        Return GetRcwProperty("ComponentType")
      End Get
    End Property

    ''' <summary>
    ''' Имя таблицы объекта.
    ''' </summary>
    Public ReadOnly Property SqlTableName As String Implements IObject(Of TI).SqlTableName
      Get
        Return DirectCast(GetRcwProperty("SQLTableName"), String)
      End Get
    End Property

    #End Region

    #Region "Методы"

    ''' <summary>
    ''' Добавить условие Where к запросу.
    ''' </summary>
    ''' <param name="queryWhereSection">Секция where запроса.</param>
    ''' <returns>ИД условия в запросе.</returns>
    Public Function AddWhere(queryWhereSection As String) As Integer Implements IObject(Of TI).AddWhere
      Return InvokeRcwInstanceMethod("AddWhere", queryWhereSection)
    End Function

    ''' <summary>
    ''' Удалить ограничение из запроса.
    ''' </summary>
    ''' <param name="queryConditionId">ИД условия в запросе.</param>
    Public Sub DelWhere(queryConditionId As Integer) Implements IObject(Of TI).DelWhere
      InvokeRcwInstanceMethod("DelWhere", queryConditionId)
    End Sub

    ''' <summary>
    ''' Завершить работу с объектом.
    ''' </summary>
    Public Sub DoFinalize() Implements IObject(Of TI).DoFinalize
      ' Для записей справочников, записей DataSet: если внутри using изменили запись и свалился наш код с исключением,
      ' то Finalize пытается закрыть запись, но закрыть несохраненную запись нельзя.
      ' Клиентский код должен корректно обрабатывать такие ситуации.
      InvokeRcwInstanceMethod("Finalize")
    End Sub

    ''' <summary>
    ''' Получить детальный раздел.
    ''' </summary>
    ''' <param name="dataSetNumber">Номер детального раздела.</param>
    ''' <returns>Детальный раздел.</returns>
    Public Function GetDetailDataSet(dataSetNumber As Integer) As IDataSet Implements IObject(Of TI).GetDetailDataSet
      Dim rcwDataSet = InvokeRcwInstanceMethod("DetailDataSet", dataSetNumber)

      Return New Data.Wrappers.DataSet(rcwDataSet, Scope)
    End Function

    ''' <summary>
    ''' Получить окружение.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметров.</typeparam>
    ''' <returns>Список переменных окружения объекта.</returns>
    Public Function GetEnvironment(Of TP As IIsbComObjectWrapper)() As  Accessory.IList(Of TP) Implements IObject(Of TI).GetEnvironment
      Dim rcwEnvironment = GetRcwProperty("Environment")
      Return New Accessory.Wrappers.List(Of TP)(rcwEnvironment, Scope)
    End Function

    ''' <summary>
    ''' Получить форму-карточку текущего представления объекта.
    ''' </summary>
    ''' <returns>Форма-карточка.</returns>
    Public Function GetForm() As IForm Implements IObject(Of TI).GetForm
      Dim rcwForm = GetRcwProperty("Form")
      Return New Form(rcwForm, Scope)
    End Function

    ''' <summary>
    ''' Получить параметры объекта.
    ''' </summary>
    ''' <typeparam name="TP">Тип параметров.</typeparam>
    ''' <returns>Список параметров объекта.</returns>
    Public Function GetParams(Of TP As IIsbComObjectWrapper)() As Accessory.IList(Of TP) Implements IObject(Of TI).GetParams
      Dim rcwParams = GetRcwProperty("Params")
      Return New Accessory.Wrappers.List(Of TP)(rcwParams, Scope)
    End Function

    ''' <summary>
    ''' Получить IObjectInfo.
    ''' </summary>
    ''' <returns>IObjectInfo.</returns>
    Public MustOverride Function GetInfo() As TI Implements IObject(Of TI).GetInfo

    ''' <summary>
    ''' Получить реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    ''' <remarks>Умышленно делаем метод виртуальным, чтобы использовать вместе с IRequisiteAutoCleaner.</remarks>
    Public Overridable Function GetRequisite(requisiteName As String) As IRequisite Implements IObject(Of TI).GetRequisite
      Dim rcwRequisite = GetRcwProperty("Requisites", requisiteName)
      Return DerivedRequisiteFactory.CreateRequisite(rcwRequisite, Scope)
    End Function

    ''' <summary>
    ''' Обновить набор данных.
    ''' </summary>
    Public Sub Refresh() Implements IObject(Of TI).Refresh
      InvokeRcwInstanceMethod("Refresh")
    End Sub

    ''' <summary>
    ''' Сохранить объект.
    ''' </summary>
    Public Sub Save() Implements IObject(Of TI).Save
      InvokeRcwInstanceMethod("Save")
    End Sub

    ''' <summary>
    ''' Получить COM-объект IObjectInfo.
    ''' </summary>
    ''' <returns>COM-объект IObjectInfo.</returns>
    Protected Function GetRcwObjectInfo() As Object
      Return GetRcwProperty("Info")
    End Function

    #End Region

    #Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="externalObject">Внешний объект.</param>
    ''' <param name="scope">Область видимости.</param>
    Protected Sub New(externalObject As Object, scope As IScope)
      MyBase.New(externalObject, scope)
    End Sub

    #End Region

  End Class
End Namespace