using IsbInterop.Accessory;
using System;
using IsbInterop.Accessory.Wrappers;

namespace IsbInterop
{
  /// <summary>
  /// Контекст.
  /// </summary>
  public class Context : IDisposable
  {
    #region IDisposable

    private bool disposed;

    /// <summary>
    /// Финализатор.
    /// </summary>
    ~Context()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;

      if (disposing)
      {
        application?.Dispose();

        this.disposed = true;
      }
    }

    #endregion

    /// <summary>
    /// Приложение IsBuilder.
    /// </summary>
    public readonly IApplication application;

    /// <summary>
    /// Параметры подключения.
    /// </summary>
    private readonly string connectionParams;

    /// <summary>
    /// Признак необходимости добавления информации о соединении в кэш.
    /// </summary>
    private readonly bool storeInCache;

    /// <summary>
    /// Создать область видимости.
    /// </summary>
    /// <returns>Область видимости.</returns>
    public IScope CreateScope()
    {
      var rcwApp = IsbApplicationManager.Instance.GetRcwApplication(connectionParams, storeInCache);
      var scope = new Scope(rcwApp);

      return scope;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwApp">RCW-объект IApplication.</param>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    public Context(object rcwApp, string connectionParams, bool storeInCache)
    {
      this.application = new Application(rcwApp, null);
      this.connectionParams = connectionParams;
      this.storeInCache = storeInCache;
    }
  }
}