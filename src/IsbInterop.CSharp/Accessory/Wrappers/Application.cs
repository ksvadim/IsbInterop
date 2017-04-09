using IsbInterop.ComponentTokens;
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

    /// <summary>
    /// Фабрика вариантов запуска.
    /// </summary>
    public IComponentTokenFactory ComponentTokenFactory
    {
      get
      {
        var rcwIComponentTokenFactory = GetRcwProperty("ComponentTokenFactory");
        return new ComponentTokenFactory(rcwIComponentTokenFactory, Scope);
      }
    }

    /// <summary>
    /// Объект-соединение, посредством которого приложение связано с SQL-сервером.
    /// </summary>
    public IConnection Connection
    {
      get
      {
        var rcwIConnection = GetRcwProperty("Connection");
        return new Connection(rcwIConnection, Scope);
      }
    }

    /// <summary>
    /// Фабрика электронных документов.
    /// </summary>
    public IEDocumentFactory EDocumentFactory
    {
      get
      {
        var rcwIEDocumentFactory = GetRcwProperty("EDocumentFactory");
        return new EDocumentFactory(rcwIEDocumentFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика папок.
    /// </summary>
    public IFolderFactory FolderFactory
    {
      get
      {
        var rcwIFolderFactory = GetRcwProperty("FolderFactory");
        return new FolderFactory(rcwIFolderFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика заданий.
    /// </summary>
    public IJobFactory JobFactory
    {
      get
      {
        var rcwIJobFactory = GetRcwProperty("JobFactory");
        return new JobFactory(rcwIJobFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика типов справочников.
    /// </summary>
    public IReferencesFactory ReferencesFactory
    {
      get
      {
        var rcwIReferencesFactory = GetRcwProperty("ReferencesFactory");
        return new ReferencesFactory(rcwIReferencesFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика сценариев.
    /// </summary>
    public IScriptFactory ScriptFactory
    {
      get
      {
        var rcwIScriptFactory = GetRcwProperty("ScriptFactory");
        return new ScriptFactory(rcwIScriptFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика поисков.
    /// </summary>
    public ISearchFactory SearchFactory
    {
      get
      {
        var rcwISearchFactory = GetRcwProperty("SearchFactory");
        return new SearchFactory(rcwISearchFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика служебных объектов.
    /// </summary>
    public IServiceFactory ServiceFactory
    {
      get
      {
        var rcwIServiceFactory = GetRcwProperty("ServiceFactory");
        return new ServiceFactory(rcwIServiceFactory, Scope);
      }
    }

    /// <summary>
    /// Фабрика задач.
    /// </summary>
    public ITaskFactory TaskFactory
    {
      get
      {
        var rcwITaskFactory = GetRcwProperty("TaskFactory");
        return new TaskFactory(rcwITaskFactory, Scope);
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Создает блокировку.
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
    /// Завершает работу с приложением.
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
    /// <remarks>
    /// Используем метод DoFinalize вместо Finalize,
    /// т.к. в VB Finalize это деструктор.
    /// </remarks>
    internal Application(object rcwApplication, IScope scope) : base(rcwApplication, scope) { }

    #endregion
  }
}
