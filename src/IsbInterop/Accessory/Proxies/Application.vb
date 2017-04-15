Imports IsbInterop.ComponentTokens
Imports IsbInterop.ComponentTokens.Proxies
Imports IsbInterop.Data
Imports IsbInterop.Data.Proxies
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.EDocuments
Imports IsbInterop.EDocuments.Proxies
Imports IsbInterop.Folders
Imports IsbInterop.Folders.Proxies
Imports IsbInterop.References
Imports IsbInterop.References.Proxies
Imports IsbInterop.Scripts
Imports IsbInterop.Scripts.Proxies
Imports IsbInterop.Searches
Imports IsbInterop.Searches.Proxies
Imports IsbInterop.ServiceForms
Imports IsbInterop.ServiceForms.Proxies
Imports IsbInterop.Tasks
Imports IsbInterop.Tasks.Proxies

Namespace Accessory.Proxies

  ''' <summary>
  ''' Обертка над IApplication.
  ''' </summary>
  Friend Class Application
    Inherits BaseIsbObject
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
    ''' Получает фабрику вариантов запуска.
    ''' </summary>
    ''' <returns>Фабрика вариантов запуска.</returns>
    Public Function GetComponentTokenFactory() As IComponentTokenFactory Implements IApplication.GetComponentTokenFactory
      Dim rcwIComponentTokenFactory = GetRcwProperty("ComponentTokenFactory")
      Return New ComponentTokenFactory(rcwIComponentTokenFactory, Scope)
    End Function

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
    ''' Получает объект-соединение, посредством которого приложение связано с SQL-сервером.
    ''' </summary>
    ''' <returns>Объект-соединение.</returns>
    Public Function GetConnection() As IConnection Implements IApplication.GetConnection
      Dim rcwIConnection = GetRcwProperty("Connection")
      Return New Connection(rcwIConnection, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику электронных документов.
    ''' </summary>
    ''' <returns>Фабрика электронных документов.</returns>
    Public Function GetEDocumentFactory() As IEDocumentFactory Implements IApplication.GetEDocumentFactory
      Dim rcwIEDocumentFactory = GetRcwProperty("EDocumentFactory")
      Return New EDocumentFactory(rcwIEDocumentFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику папок.
    ''' </summary>
    ''' <returns>Фабрика папок.</returns>
    Function GetFolderFactory() As IFolderFactory Implements IApplication.GetFolderFactory
      Dim rcwIFolderFactory = GetRcwProperty("FolderFactory")
      Return New FolderFactory(rcwIFolderFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику заданий.
    ''' </summary>
    ''' <returns>Фабрика заданий</returns>
    Public Function GetJobFactory() As IJobFactory Implements IApplication.GetJobFactory
      Dim rcwIJobFactory = GetRcwProperty("JobFactory")
      Return New JobFactory(rcwIJobFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику типов справочников.
    ''' </summary>
    ''' <returns>Фабрика типов справочников.</returns>
    Public Function GetReferencesFactory() As IReferencesFactory Implements IApplication.GetReferencesFactory
      Dim rcwIReferencesFactory = GetRcwProperty("ReferencesFactory")
      Return New ReferencesFactory(rcwIReferencesFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику сценариев.
    ''' </summary>
    ''' <returns>Фабрика сценариев.</returns>
    Public Function GetScriptFactory() As IScriptFactory Implements IApplication.GetScriptFactory
      Dim rcwIScriptFactory = GetRcwProperty("ScriptFactory")
      Return New ScriptFactory(rcwIScriptFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику поисков.
    ''' </summary>
    ''' <returns>Фабрика поисков.</returns>
    Public Function GetSearchFactory() As ISearchFactory Implements IApplication.GetSearchFactory
      Dim rcwISearchFactory = GetRcwProperty("SearchFactory")
      Return New SearchFactory(rcwISearchFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику служебных объектов.
    ''' </summary>
    ''' <returns>Фабрика служебных объектов.</returns>
    Public Function GetServiceFactory() As IServiceFactory Implements IApplication.GetServiceFactory
      Dim rcwIServiceFactory = GetRcwProperty("ServiceFactory")
      Return New ServiceFactory(rcwIServiceFactory, Scope)
    End Function

    ''' <summary>
    ''' Получает фабрику задач.
    ''' </summary>
    ''' <returns>Фабрика задач.</returns>
    Public Function GetTaskFactory() As ITaskFactory Implements IApplication.GetTaskFactory
      Dim rcwITaskFactory = GetRcwProperty("TaskFactory")
      Return New TaskFactory(rcwITaskFactory, Scope)
    End Function

    ''' <summary>
    ''' Завершает работу с приложением.
    ''' </summary>
    Public Sub DoFinalize() Implements IApplication.DoFinalize
      InvokeRcwInstanceMethod("Finalize")
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
