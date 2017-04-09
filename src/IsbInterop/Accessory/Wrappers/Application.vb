Imports IsbInterop.ComponentTokens
Imports IsbInterop.ComponentTokens.Wrappers
Imports IsbInterop.Data
Imports IsbInterop.Data.Wrappers
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.EDocuments
Imports IsbInterop.EDocuments.Wrappers
Imports IsbInterop.Folders
Imports IsbInterop.Folders.Wrappers
Imports IsbInterop.References
Imports IsbInterop.References.Wrappers
Imports IsbInterop.Scripts
Imports IsbInterop.Scripts.Wrappers
Imports IsbInterop.Searches
Imports IsbInterop.Searches.Wrappers
Imports IsbInterop.ServiceForms
Imports IsbInterop.ServiceForms.Wrappers
Imports IsbInterop.Tasks
Imports IsbInterop.Tasks.Wrappers

Namespace Accessory.Wrappers
  ''' <summary>
  ''' Обертка над IApplication.
  ''' </summary>
  Friend Class Application
    Inherits IsbComObjectWrapper
    Implements IApplication

#Region "Поля и свойства"

    ''' <summary>
    ''' ИД процесса Application.
    ''' </summary>
    Public ReadOnly Property PID As Integer Implements IApplication.PID
      Get
        Return GetRcwProperty("PID")
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Фабрика вариантов запуска.
    ''' </summary>
    Public ReadOnly Property ComponentTokenFactory As IComponentTokenFactory Implements IApplication.ComponentTokenFactory
      Get
        Dim rcwIComponentTokenFactory = GetRcwProperty("ComponentTokenFactory")
        Return New ComponentTokenFactory(rcwIComponentTokenFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Объект-соединение, посредством которого приложение связано с SQL-сервером.
    ''' </summary>
    Public ReadOnly Property Connection As IConnection Implements IApplication.Connection
      Get
        Dim rcwIConnection = GetRcwProperty("Connection")
        Return New Connection(rcwIConnection, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика электронных документов.
    ''' </summary>
    ''' <returns>Фабрика электронных документов.</returns>
    Public ReadOnly Property EDocumentFactory As IEDocumentFactory Implements IApplication.EDocumentFactory
      Get
        Dim rcwIEDocumentFactory = GetRcwProperty("EDocumentFactory")
        Return New EDocumentFactory(rcwIEDocumentFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика папок.
    ''' </summary>
    Public ReadOnly Property FolderFactory As IFolderFactory Implements IApplication.FolderFactory
      Get
        Dim rcwIFolderFactory = GetRcwProperty("FolderFactory")
        Return New FolderFactory(rcwIFolderFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика заданий.
    ''' </summary>
    Public ReadOnly Property JobFactory As IJobFactory Implements IApplication.JobFactory
      Get
        Dim rcwIJobFactory = GetRcwProperty("JobFactory")
        Return New JobFactory(rcwIJobFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика типов справочников.
    ''' </summary>
    Public ReadOnly Property GetReferencesFactory As IReferencesFactory Implements IApplication.ReferencesFactory
      Get
        Dim rcwIReferencesFactory = GetRcwProperty("ReferencesFactory")
        Return New ReferencesFactory(rcwIReferencesFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика сценариев.
    ''' </summary>
    Public ReadOnly Property ScriptFactory As IScriptFactory Implements IApplication.ScriptFactory
      Get
        Dim rcwIScriptFactory = GetRcwProperty("ScriptFactory")
        Return New ScriptFactory(rcwIScriptFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Получить фабрику поисков.
    ''' </summary>
    Public ReadOnly Property SearchFactory As ISearchFactory Implements IApplication.SearchFactory
      Get
        Dim rcwISearchFactory = GetRcwProperty("SearchFactory")
        Return New SearchFactory(rcwISearchFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика служебных объектов.
    ''' </summary>
    Public ReadOnly Property GetServiceFactory As IServiceFactory Implements IApplication.ServiceFactory
      Get
        Dim rcwIServiceFactory = GetRcwProperty("ServiceFactory")
        Return New ServiceFactory(rcwIServiceFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Фабрика задач.
    ''' </summary>
    ''' <returns>Фабрика задач.</returns>
    Public ReadOnly Property TaskFactory() As ITaskFactory Implements IApplication.TaskFactory
      Get
        Dim rcwITaskFactory = GetRcwProperty("TaskFactory")
        Return New TaskFactory(rcwITaskFactory, Scope)
      End Get
    End Property

    ''' <summary>
    ''' Создает блокировку.
    ''' </summary>
    ''' <param name="objectType">Тип объекта.</param>
    ''' <param name="objectId">ИД объекта.</param>
    ''' <returns>Объект-блокировка.</returns>
    Public Function CreateLock(objectType As TCompType, objectId As Integer) As ILock Implements IApplication.CreateLock
      Dim rcwILock = InvokeRcwInstanceMethod("CreateLock", New Object() {objectType, objectId})
      Return New Lock(rcwILock, Scope)
    End Function

    ''' <summary>
    ''' Завершает работу с приложением.
    ''' </summary>
    Public Sub DoFinalize() Implements IApplication.DoFinalize
      Me.InvokeRcwInstanceMethod("Finalize")
    End Sub

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwApplication">COM-объект IApplication.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwApplication As Object, scope As IScope)
      MyBase.New(rcwApplication, scope)
    End Sub

#End Region

  End Class
End Namespace
