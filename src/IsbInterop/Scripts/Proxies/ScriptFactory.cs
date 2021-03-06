﻿using IsbInterop.Base;
using IsbInterop.Base.Proxies;
using System;

namespace IsbInterop.Scripts.Proxies
{
  /// <summary>
  /// Обертка над IScriptFactory.
  /// </summary>
  internal class ScriptFactory : Factory<IScript, IObjectInfo>, IScriptFactory
  {
    /// <summary>
    /// Получает сценарий по имени.
    /// </summary>
    /// <param name="scriptName">Имя сценария.</param>
    /// <returns>Сценарий.</returns>
    public IScript GetObjectByName(string scriptName)
    {
      var rcwScript = InvokeRcwInstanceMethod("GetObjectByName", scriptName);
      return new Script(rcwScript, Scope);
    }

    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IScript GetObjectById(int id)
    {
      throw new NotSupportedException("This method is not supported by IS-Builder API.");
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override IObjectInfo GetObjectInfo(int id)
    {
      throw new NotSupportedException("This method is not supported by IS-Builder API.");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIScriptFactory">COM-объект фабрика сценариев.</param>
    /// <param name="scope">Область видимости.</param>
    internal ScriptFactory(object rcwIScriptFactory, IScope scope) : base(rcwIScriptFactory, scope) { }
  }
}
