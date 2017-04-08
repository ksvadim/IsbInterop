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
    private readonly Stack<IIsbComObjectWrapper> workingSet = new Stack<IIsbComObjectWrapper>();

    /// <summary>
    /// Приложение IS-Builder.
    /// </summary>
    public IApplication Application { get; }

    #region IDisposable

    /// <summary>
    /// Выполнить очистку.
    /// </summary>
    public void Dispose()
    {
      foreach (var isbObject in workingSet)
      {
        try
        {
          isbObject.Dispose();
        }
        catch (ObjectDisposedException)
        {
          // Гасим исключение, если объект уже освобожден.
        }
      }

      workingSet.Clear();
    }

    #endregion

    /// <summary>
    /// Добавить объект в область видимости.
    /// </summary>
    /// <param name="isbObject">Объект IS-Builder.</param>
    public void Add(IIsbComObjectWrapper isbObject)
    {
      workingSet.Push(isbObject);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwApp">RCW-объект IApplication.</param>
    public Scope(object rcwApp)
    {
      this.Application = new Application(rcwApp, this);
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
