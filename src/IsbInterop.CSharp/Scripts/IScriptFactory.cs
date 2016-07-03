using IsbInterop.Base;

namespace IsbInterop.Scripts
{
  /// <summary>
  /// Фабрика сценариев.
  /// </summary>
  public interface IScriptFactory : IFactory<IScript, IObjectInfo>
  {
    /// <summary>
    /// Получить сценарий по имени.
    /// </summary>
    /// <param name="scriptName">Имя сценария.</param>
    /// <returns>Сценарий.</returns>
    IScript GetObjectByName(string scriptName);
  }
}
