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

    private bool _disposed;

    /// <summary>
    /// Финализатор.
    /// </summary>
    ~Context()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (_disposed)
        return;

      if (disposing)
      {
        _application?.Dispose();

        _disposed = true;
      }
    }

    #endregion

    /// <summary>
    /// Приложение IsBuilder.
    /// </summary>
    private readonly IApplication _application;

    /// <summary>
    /// Параметры подключения.
    /// </summary>
    private readonly string _connectionParams;

    /// <summary>
    /// Признак необходимости добавления информации о соединении в кэш.
    /// </summary>
    private readonly bool _storeInCache;

    /// <summary>
    /// Создать область видимости.
    /// </summary>
    /// <returns>Область видимости.</returns>
    public IScope CreateScope()
    {
      var rcwApp = IsbApplicationManager.Instance.GetRcwApplication(_connectionParams, _storeInCache);
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
      _application = new Application(rcwApp, null);
      _connectionParams = connectionParams;
      _storeInCache = storeInCache;
    }
  }
}