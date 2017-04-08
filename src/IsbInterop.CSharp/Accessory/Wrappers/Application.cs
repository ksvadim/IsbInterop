﻿using IsbInterop.ComponentTokens;
using IsbInterop.ComponentTokens.Wrappers;
using IsbInterop.Data;
using IsbInterop.Data.Wrappers;
using IsbInterop.DataTypes.Enumerable;
using IsbInterop.EDocuments;
using IsbInterop.EDocuments.Wrappers;
using IsbInterop.Folders;
using IsbInterop.Folders.Wrappers;
using IsbInterop.References;
using IsbInterop.References.Wrappers;
using IsbInterop.Scripts;
using IsbInterop.Scripts.Wrappers;
using IsbInterop.Searches;
using IsbInterop.Searches.Wrappers;
using IsbInterop.ServiceForms;
using IsbInterop.ServiceForms.Wrappers;
using IsbInterop.Tasks;
using IsbInterop.Tasks.Wrappers;

namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над IApplication.
  /// </summary>
  internal class Application : IsbComObjectWrapper, IApplication
  {
    #region Поля и свойства

    /// <summary>
    /// ИД процесса.
    /// </summary>
    public int PID => (int)GetRcwProperty("PID");

    #endregion

    #region Методы

    /// <summary>
    /// Получить фабрику вариантов запуска.
    /// </summary>
    /// <returns>Фабрика вариантов запуска.</returns>
    public IComponentTokenFactory GetComponentTokenFactory()
    {
      var rcwIComponentTokenFactory = GetRcwProperty("ComponentTokenFactory");
      return new ComponentTokenFactory(rcwIComponentTokenFactory, Scope);
    }

    /// <summary>
    /// Создать блокировку.
    /// </summary>
    /// <param name="objectType">Тип объекта.</param>
    /// <param name="objectId">ИД объекта.</param>
    /// <returns>Объект-блокировка.</returns>
    public ILock CreateLock(TCompType objectType, int objectId)
    {
      var rcwILock = InvokeRcwInstanceMethod("CreateLock", new object[] { objectType, objectId });
      return new Lock(rcwILock, Scope);
    }

    /// <summary>
    /// Получить объект-соединение.
    /// </summary>
    /// <returns>Объект-соединение.</returns>
    public IConnection GetConnection()
    {
      var rcwIConnection = GetRcwProperty("Connection");
      return new Connection(rcwIConnection, Scope);
    }

    /// <summary>
    /// Получить фабрику электронных документов.
    /// </summary>
    /// <returns>Фабрика электронных документов.</returns>
    public IEDocumentFactory GetEDocumentFactory()
    {
      var rcwIEDocumentFactory = GetRcwProperty("EDocumentFactory");
      return new EDocumentFactory(rcwIEDocumentFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику папок.
    /// </summary>
    /// <returns>Фабрика папок.</returns>
    public IFolderFactory GetFolderFactory()
    {
      var rcwIFolderFactory = GetRcwProperty("FolderFactory");
      return new FolderFactory(rcwIFolderFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику заданий.
    /// </summary>
    /// <returns>Фабрика заданий.</returns>
    public IJobFactory GetJobFactory()
    {
      var rcwIJobFactory = GetRcwProperty("JobFactory");
      return new JobFactory(rcwIJobFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику типов справочников.
    /// </summary>
    /// <returns>Фабрика типов справочников.</returns>
    public IReferencesFactory GetReferencesFactory()
    {
      var rcwIReferencesFactory = GetRcwProperty("ReferencesFactory");
      return new ReferencesFactory(rcwIReferencesFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику сценариев.
    /// </summary>
    /// <returns>Фабрика сценариев.</returns>
    public IScriptFactory GetScriptFactory()
    {
      var rcwIScriptFactory = GetRcwProperty("ScriptFactory");
      return new ScriptFactory(rcwIScriptFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику поисков.
    /// </summary>
    /// <returns>Фабрика поисков.</returns>
    public ISearchFactory GetSearchFactory()
    {
      var rcwISearchFactory = GetRcwProperty("SearchFactory");
      return new SearchFactory(rcwISearchFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику служебных объектов.
    /// </summary>
    /// <returns>Фабрика служебных объектов.</returns>
    public IServiceFactory GetServiceFactory()
    {
      var rcwIServiceFactory = GetRcwProperty("ServiceFactory");
      return new ServiceFactory(rcwIServiceFactory, Scope);
    }

    /// <summary>
    /// Получить фабрику задач.
    /// </summary>
    /// <returns>Фабрика задач.</returns>
    public ITaskFactory GetTaskFactory()
    {
      var rcwITaskFactory = GetRcwProperty("TaskFactory");
      return new TaskFactory(rcwITaskFactory, Scope);
    }

    /// <summary>
    /// Завершить работу с приложением.
    /// </summary>
    public void DoFinalize()
    {
      this.InvokeRcwInstanceMethod("Finalize");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwApplication">COM-объект IApplication.</param>
    /// <param name="scope">Область видимости.</param>
    internal Application(object rcwApplication, IScope scope) : base(rcwApplication, scope) { }

    #endregion
  }
}
