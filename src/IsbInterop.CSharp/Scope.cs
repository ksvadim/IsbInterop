using IsbInterop.Accessory;
using IsbInterop.Accessory.Wrappers;
using System;
using System.Collections.Generic;

namespace IsbInterop
{
  /// <summary>
  /// Область видимости.
  /// </summary>
  internal class Scope : IScope
  {
    /// <summary>
    /// Рабочий набор.
    /// </summary>
    private readonly Stack<IIsbComObjectWrapper> _workingSet = new Stack<IIsbComObjectWrapper>();

    /// <summary>
    /// Приложение IS-Builder.
    /// </summary>
    public IApplication Application { get; }

    #region IDisposable

    /// <summary>
    /// Выполняет очистку.
    /// </summary>
    public void Dispose()
    {
      while (_workingSet.Count > 0)
      {
        var requisite = _workingSet.Pop();
        try
        {
          requisite.Dispose();
        }
        catch (ObjectDisposedException)
        {
          // Гасим исключение, если объект уже освобожден.
        }
      }

      _workingSet.Clear();
    }

    #endregion

    /// <summary>
    /// Добавляет объект в область видимости.
    /// </summary>
    /// <param name="isbObject">Объект IS-Builder.</param>
    public void Add(IIsbComObjectWrapper isbObject)
    {
      _workingSet.Push(isbObject);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwApp">RCW-объект IApplication.</param>
    public Scope(object rcwApp)
    {
      Application = new Application(rcwApp, this);
    }
  }

  /// <summary>
  /// Интерфейс области видимости.
  /// </summary>
  public interface IScope : IDisposable
  {
    /// <summary>
    /// Приложение IS-Builder.
    /// </summary>
    IApplication Application { get; }
  }
}
