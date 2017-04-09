using IsbInterop.Data;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.EDocuments;
using IsbInterop.Folders;
using IsbInterop.References;
using IsbInterop.Scripts;
using IsbInterop.Searches;
using IsbInterop.ServiceForms;
using IsbInterop.Tasks;
using System;
using IsbInterop.ComponentTokens;

namespace IsbInterop.Accessory
{
  /// <summary>
  /// Приложение.
  /// </summary>
  public interface IApplication : IDisposable
  {
    /// <summary>
    /// ИД процесса Application.
    /// </summary>
    int PID { get; }

    /// <summary>
    /// Фабрика вариантов запуска.
    /// </summary>
    IComponentTokenFactory ComponentTokenFactory { get; }

    /// <summary>
    /// Объект-соединение, посредством которого приложение связано с SQL-сервером.
    /// </summary>
    IConnection Connection { get; }

    /// <summary>
    /// Получить фабрику электронных документов.
    /// </summary>
    IEDocumentFactory EDocumentFactory { get; }

    /// <summary>
    /// Фабрика папок.
    /// </summary>
    IFolderFactory FolderFactory { get; }

    /// <summary>
    /// Фабрика заданий.
    /// </summary>
    IJobFactory JobFactory { get; }

    /// <summary>
    /// Фабрика типов справочников.
    /// </summary>
    IReferencesFactory ReferencesFactory { get; }

    /// <summary>
    /// Фабрика сценариев.
    /// </summary>
    IScriptFactory ScriptFactory { get; }

    /// <summary>
    /// Фабрика поисков.
    /// </summary>
    ISearchFactory SearchFactory { get; }

    /// <summary>
    /// Фабрика служебных объектов.
    /// </summary>
    IServiceFactory ServiceFactory { get; }

    /// <summary>
    /// Фабрика задач.
    /// </summary>
    ITaskFactory TaskFactory { get; }

    /// <summary>
    /// Создает блокировку.
    /// </summary>
    /// <param name="objectType">Тип объекта.</param>
    /// <param name="objectId">ИД объекта.</param>
    /// <returns>Объект-блокировка.</returns>
    ILock CreateLock(TCompType objectType, int objectId);

    /// <summary>
    /// Завершает работу с приложением.
    /// </summary>
    /// <remarks>
    /// Используем метод DoFinalize вместо Finalize,
    /// т.к. в VB Finalize это деструктор.
    /// </remarks>
    void DoFinalize();
  }
}
