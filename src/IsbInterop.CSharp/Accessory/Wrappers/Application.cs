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
    /// <summary>
    /// ИД процесса.
    /// </summary>
    public int PID
    {
      get { return (int)this.GetRcwProperty("PID"); }
    }

    /// <summary>
    /// Получить фабрику вариантов запуска.
    /// </summary>
    /// <returns>Фабрика вариантов запуска.</returns>
    public IComponentTokenFactory GetComponentTokenFactory()
    {
      var rcwIComponentTokenFactory = this.GetRcwProperty("ComponentTokenFactory");
      return new ComponentTokenFactory(rcwIComponentTokenFactory);
    }

    /// <summary>
    /// Создать блокировку.
    /// </summary>
    /// <param name="objectType">Тип объекта.</param>
    /// <param name="objectId">ИД объекта.</param>
    /// <returns>Объект-блокировка.</returns>
    public ILock CreateLock(TCompType objectType, int objectId)
    {
      var rcwILock = this.InvokeRcwInstanceMethod("CreateLock", new object[] { objectType, objectId });
      return new Lock(rcwILock);
    }

    /// <summary>
    /// Получить объект-соединение.
    /// </summary>
    /// <returns>Объект-соединение.</returns>
    public IConnection GetConnection()
    {
      var rcwIConnection = this.GetRcwProperty("Connection");
      return new Connection(rcwIConnection);
    }

    /// <summary>
    /// Получить фабрику электронных документов.
    /// </summary>
    /// <returns>Фабрика электронных документов.</returns>
    public IEDocumentFactory GetEDocumentFactory()
    {
      var rcwIEDocumentFactory = this.GetRcwProperty("EDocumentFactory");
      return new EDocumentFactory(rcwIEDocumentFactory);
    }

    /// <summary>
    /// Получить фабрику папок.
    /// </summary>
    /// <returns>Фабрика папок.</returns>
    public IFolderFactory GetFolderFactory()
    {
      var rcwIFolderFactory = this.GetRcwProperty("FolderFactory");
      return new FolderFactory(rcwIFolderFactory);
    }

    /// <summary>
    /// Получить фабрику заданий.
    /// </summary>
    /// <returns>Фабрика заданий.</returns>
    public IJobFactory GetJobFactory()
    {
      var rcwIJobFactory = this.GetRcwProperty("JobFactory");
      return new JobFactory(rcwIJobFactory);
    }

    /// <summary>
    /// Получить фабрику типов справочников.
    /// </summary>
    /// <returns>Фабрика типов справочников.</returns>
    public IReferencesFactory GetReferencesFactory()
    {
      var rcwIReferencesFactory = this.GetRcwProperty("ReferencesFactory");
      return new ReferencesFactory(rcwIReferencesFactory);
    }

    /// <summary>
    /// Получить фабрику сценариев.
    /// </summary>
    /// <returns>Фабрика сценариев.</returns>
    public IScriptFactory GetScriptFactory()
    {
      var rcwIScriptFactory = this.GetRcwProperty("ScriptFactory");
      return new ScriptFactory(rcwIScriptFactory);
    }

    /// <summary>
    /// Получить фабрику поисков.
    /// </summary>
    /// <returns>Фабрика поисков.</returns>
    public ISearchFactory GetSearchFactory()
    {
      var rcwISearchFactory = this.GetRcwProperty("SearchFactory");
      return new SearchFactory(rcwISearchFactory);
    }

    /// <summary>
    /// Получить фабрику служебных объектов.
    /// </summary>
    /// <returns>Фабрика служебных объектов.</returns>
    public IServiceFactory GetServiceFactory()
    {
      var rcwIServiceFactory = this.GetRcwProperty("ServiceFactory");
      return new ServiceFactory(rcwIServiceFactory);
    }

    /// <summary>
    /// Получить фабрику задач.
    /// </summary>
    /// <returns>Фабрика задач.</returns>
    public ITaskFactory GetTaskFactory()
    {
      var rcwITaskFactory = this.GetRcwProperty("TaskFactory");
      return new TaskFactory(rcwITaskFactory);
    }

    /// <summary>
    /// Завершить работу с приложением.
    /// </summary>
    public void DoFinalize()
    {
      this.InvokeRcwInstanceMethod("Finalize");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwApplication">COM-объект IApplication.</param>
    internal Application(object rcwApplication) : base(rcwApplication) { }
  }
}
