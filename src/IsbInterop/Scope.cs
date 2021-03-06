﻿using IsbInterop.Accessory;
using IsbInterop.Accessory.Proxies;
using System;
using System.Collections.Generic;
using IsbInterop.System;
using IsbInterop.System.Proxies;

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
    private readonly Stack<IBaseIsbObject> _workingSet = new Stack<IBaseIsbObject>();

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
    public void Add(IBaseIsbObject isbObject)
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
