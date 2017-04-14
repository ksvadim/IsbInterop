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
    /// Получает фабрику вариантов запуска.
    /// </summary>
    /// <returns>Фабрика вариантов запуска.</returns>
    IComponentTokenFactory GetComponentTokenFactory();

    /// <summary>
    /// Создает блокировку.
    /// </summary>
    /// <param name="objectType">Тип объекта.</param>
    /// <param name="objectId">ИД объекта.</param>
    /// <returns>Объект-блокировка.</returns>
    ILock CreateLock(TCompType objectType, int objectId);

    /// <summary>
    /// Получает объект-соединение, посредством которого приложение связано с SQL-сервером.
    /// </summary>
    /// <returns>Объект-соединение.</returns>
    IConnection GetConnection();

    /// <summary>
    /// Получает фабрику электронных документов.
    /// </summary>
    /// <returns></returns>
    IEDocumentFactory GetEDocumentFactory();

    /// <summary>
    /// Получает фабрику папок.
    /// </summary>
    /// <returns>Фабрика папок.</returns>
    IFolderFactory GetFolderFactory();

    /// <summary>
    /// Получает фабрику заданий.
    /// </summary>
    /// <returns>Фабрика заданий.</returns>
    IJobFactory GetJobFactory();

    /// <summary>
    /// Получает фабрику типов справочников.
    /// </summary>
    /// <returns>Фабрика типов справочников.</returns>
    IReferencesFactory GetReferencesFactory();

    /// <summary>
    /// Получает фабрику сценариев.
    /// </summary>
    /// <returns>Фабрика сценариев.</returns>
    IScriptFactory GetScriptFactory();

    /// <summary>
    /// Получает фабрику поисков.
    /// </summary>
    /// <returns>Фабрика поисков.</returns>
    ISearchFactory GetSearchFactory();

    /// <summary>
    /// Получает фабрику служебных объектов.
    /// </summary>
    /// <returns>Фабрика служебных объектов.</returns>
    IServiceFactory GetServiceFactory();

    /// <summary>
    /// Получает фабрику задач.
    /// </summary>
    /// <returns>Фабрика задач.</returns>
    ITaskFactory GetTaskFactory();

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
