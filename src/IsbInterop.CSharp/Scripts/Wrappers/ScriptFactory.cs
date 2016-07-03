using IsbInterop.Base;
using IsbInterop.Base.Wrappers;
using System;

namespace IsbInterop.Scripts.Wrappers
{
  /// <summary>
  /// Обертка над IScriptFactory.
  /// </summary>
  internal class ScriptFactory : Factory<IScript, IObjectInfo>, IScriptFactory
  {
    /// <summary>
    /// Получить сценарий по имени.
    /// </summary>
    /// <param name="scriptName">Имя сценария.</param>
    /// <returns>Сценарий.</returns>
    public IScript GetObjectByName(string scriptName)
    {
      var rcwScript = this.InvokeRcwInstanceMethod("GetObjectByName", scriptName);
      return new Script(rcwScript);
    }

    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override IScript GetObjectById(int id)
    {
      throw new NotSupportedException("This method is not supported by IS-Builder API.");
    }

    /// <summary>
    /// Получить информацию об объекте.
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
    internal ScriptFactory(object rcwIScriptFactory) : base(rcwIScriptFactory) { }
  }
}
