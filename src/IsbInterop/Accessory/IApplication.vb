Imports IsbInterop.ComponentTokens
Imports IsbInterop.Data
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.EDocuments
Imports IsbInterop.Folders
Imports IsbInterop.References
Imports IsbInterop.Scripts
Imports IsbInterop.Searches
Imports IsbInterop.ServiceForms
Imports IsbInterop.Tasks

Namespace Accessory
  ''' <summary>
  ''' Приложение.
  ''' </summary>
  Public Interface IApplication
    Inherits IDisposable
    ''' <summary>
    ''' ИД процесса Application.
    ''' </summary>
    ReadOnly Property PID() As Integer

    ''' <summary>
    ''' Получить фабрику вариантов запуска.
    ''' </summary>
    ''' <returns>Фабрика вариантов запуска.</returns>
    Function GetComponentTokenFactory() As IComponentTokenFactory

    ''' <summary>
    ''' Создать блокировку.
    ''' </summary>
    ''' <param name="objectType">Тип объекта.</param>
    ''' <param name="objectId">ИД объекта.</param>
    ''' <returns>Объект-блокировка.</returns>
    Function CreateLock(objectType As TCompType, objectId As Integer) As ILock

    ''' <summary>
    ''' Получить объект-соединение.
    ''' </summary>
    ''' <returns>Объект-соединение.</returns>
    Function GetConnection() As IConnection

    ''' <summary>
    ''' Получить фабрику электронных документов.
    ''' </summary>
    ''' <returns></returns>
    Function GetEDocumentFactory() As IEDocumentFactory

    ''' <summary>
    ''' Получить фабрику папок.
    ''' </summary>
    ''' <returns>Фабрика папок.</returns>
    Function GetFolderFactory() As IFolderFactory

    ''' <summary>
    ''' Получить фабрику заданий.
    ''' </summary>
    ''' <returns>Фабрика заданий.</returns>
    Function GetJobFactory() As IJobFactory

    ''' <summary>
    ''' Получить фабрику типов справочников.
    ''' </summary>
    ''' <returns>Фабрика типов справочников.</returns>
    Function GetReferencesFactory() As IReferencesFactory

    ''' <summary>
    ''' Получить фабрику сценариев.
    ''' </summary>
    ''' <returns>Фабрика сценариев.</returns>
    Function GetScriptFactory() As IScriptFactory

    ''' <summary>
    ''' Получить фабрику поисков.
    ''' </summary>
    ''' <returns>Фабрика поисков.</returns>
    Function GetSearchFactory() As ISearchFactory

    ''' <summary>
    ''' Получить фабрику служебных объектов.
    ''' </summary>
    ''' <returns>Фабрика служебных объектов.</returns>
    Function GetServiceFactory() As IServiceFactory

    ''' <summary>
    ''' Получить фабрику задач.
    ''' </summary>
    ''' <returns>Фабрика задач.</returns>
    Function GetTaskFactory() As ITaskFactory

    ''' <summary>
    ''' Завершить работу с приложением.
    ''' </summary>
    ''' <remarks>Имя изменено, т.к. в VB.Net Finalize соответствует деструктору.</remarks>
    Sub DoFinalize()
  End Interface
End Namespace