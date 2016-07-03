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
    /// Получить фабрику вариантов запуска.
    /// </summary>
    /// <returns>Фабрика вариантов запуска.</returns>
    IComponentTokenFactory GetComponentTokenFactory();

    /// <summary>
    /// Создать блокировку.
    /// </summary>
    /// <param name="objectType">Тип объекта.</param>
    /// <param name="objectId">ИД объекта.</param>
    /// <returns>Объект-блокировка.</returns>
    ILock CreateLock(TCompType objectType, int objectId);

    /// <summary>
    /// Получить объект-соединение.
    /// </summary>
    /// <returns>Объект-соединение.</returns>
    IConnection GetConnection();

    /// <summary>
    /// Получить фабрику электронных документов.
    /// </summary>
    /// <returns></returns>
    IEDocumentFactory GetEDocumentFactory();

    /// <summary>
    /// Получить фабрику папок.
    /// </summary>
    /// <returns>Фабрика папок.</returns>
    IFolderFactory GetFolderFactory();

    /// <summary>
    /// Получить фабрику заданий.
    /// </summary>
    /// <returns>Фабрика заданий.</returns>
    IJobFactory GetJobFactory();

    /// <summary>
    /// Получить фабрику типов справочников.
    /// </summary>
    /// <returns>Фабрика типов справочников.</returns>
    IReferencesFactory GetReferencesFactory();

    /// <summary>
    /// Получить фабрику сценариев.
    /// </summary>
    /// <returns>Фабрика сценариев.</returns>
    IScriptFactory GetScriptFactory();

    /// <summary>
    /// Получить фабрику поисков.
    /// </summary>
    /// <returns></returns>
    ISearchFactory GetSearchFactory();

    /// <summary>
    /// Получить фабрику служебных объектов.
    /// </summary>
    /// <returns>Фабрика служебных объектов.</returns>
    IServiceFactory GetServiceFactory();

    /// <summary>
    /// Получить фабрику задач.
    /// </summary>
    /// <returns>Фабрика задач.</returns>
    ITaskFactory GetTaskFactory();

    /// <summary>
    /// Завершить работу с приложением.
    /// </summary>
    void DoFinalize();
  }
}
