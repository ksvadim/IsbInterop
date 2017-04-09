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
    ReadOnly Property PID As Integer

    ''' <summary>
    ''' Фабрика вариантов запуска.
    ''' </summary>
    ReadOnly Property ComponentTokenFactory As IComponentTokenFactory

    ''' <summary>
    ''' Объект-соединение, посредством которого приложение связано с SQL-сервером.
    ''' </summary>
    ReadOnly Property Connection As IConnection

    ''' <summary>
    ''' Фабрика электронных документов.
    ''' </summary>
    ReadOnly Property EDocumentFactory As IEDocumentFactory

    ''' <summary>
    ''' Фабрика папок.
    ''' </summary>
    ReadOnly Property FolderFactory As IFolderFactory

    ''' <summary>
    ''' Фабрика заданий.
    ''' </summary>
    ''' <returns>Фабрика заданий.</returns>
    ReadOnly Property JobFactory As IJobFactory

    ''' <summary>
    ''' Фабрика типов справочников.
    ''' </summary>
    ReadOnly Property ReferencesFactory As IReferencesFactory

    ''' <summary>
    ''' Фабрика сценариев.
    ''' </summary>
    ReadOnly Property ScriptFactory As IScriptFactory

    ''' <summary>
    ''' Фабрика поисков.
    ''' </summary>
    ReadOnly Property SearchFactory As ISearchFactory

    ''' <summary>
    ''' Фабрика служебных объектов.
    ''' </summary>
    ReadOnly Property ServiceFactory As IServiceFactory

    ''' <summary>
    ''' Фабрика задач.
    ''' </summary>
    ReadOnly Property TaskFactory As ITaskFactory

    ''' <summary>
    ''' Создает блокировку.
    ''' </summary>
    ''' <param name="objectType">Тип объекта.</param>
    ''' <param name="objectId">ИД объекта.</param>
    ''' <returns>Объект-блокировка.</returns>
    Function CreateLock(objectType As TCompType, objectId As Integer) As ILock

    ''' <summary>
    ''' Завершает работу с приложением.
    ''' </summary>
    ''' <remarks>Имя изменено, т.к. в VB.Net Finalize соответствует деструктору.</remarks>
    Sub DoFinalize()
  End Interface
End Namespace