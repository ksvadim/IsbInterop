using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Base
{
  /// <summary>
  /// Базовая фабрика.
  /// </summary>
  /// <typeparam name="T">Тип объекта фабрики.</typeparam>
  /// <typeparam name="TI">Тип, предоставляющий информацию об объекте фабрики.</typeparam>
  public interface IFactory<out T, out TI> : IIsbComObjectWrapper 
    where T : IIsbComObjectWrapper
    where TI :IObjectInfo
  {
    /// <summary>
    /// Тип объектов, к которым предоставляет доступ фабрика.
    /// </summary>
    TContentKind Kind { get; }

    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    T GetObjectById(int id);

    /// <summary>
    /// Получить информацию об объекте по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Информация об объекте.</returns>
    TI GetObjectInfo(int id);
  }
}
