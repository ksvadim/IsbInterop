using IsbInterop.DataTypes.Enumerable;
using IsbInterop.Utils;
using System;

namespace IsbInterop.Base.Proxies
{
  /// <summary>
  /// Обертка над IFactory.
  /// </summary>
  public abstract class Factory<T, TI> : BaseIsbObject, IFactory<T, TI>
    where T : IBaseIsbObject
    where TI : IObjectInfo
  {
    #region Поля и свойства

    /// <summary>
    /// Тип объектов фабрики.
    /// </summary>
    public TContentKind Kind
    {
      get
      {
        int kindType = (int)GetRcwProperty("Kind");

        if (Enum.IsDefined(typeof(TContentKind), kindType))
          return (TContentKind)kindType;
        else
          return TContentKind.ckUnknown;
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Получить объект фабрики по ИД.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект фабрики.</returns>
    public abstract T GetObjectById(int id);

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public abstract TI GetObjectInfo(int id);

    /// <summary>
    /// Получает объект по ИД.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <param name="objectType">Тип объекта.</param>
    /// <returns>Объект фабрики.</returns>
    protected object GetRcwObjectById(int id, out TCompType objectType)
    {
      var rcwFactoryObject = GetRcwObjectById(id);
      objectType = (TCompType)ComUtils.GetRcwProperty(rcwFactoryObject, "ComponentType");

      return rcwFactoryObject;
    }

    /// <summary>
    /// Получает объект по ИД.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Объект фабрики.</returns>
    protected object GetRcwObjectById(int id)
    {
      return InvokeRcwInstanceMethod("GetObjectByID", id);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <param name="objectType">Тип объекта.</param>
    /// <returns>Info-объект.</returns>
    protected object GetRcwObjectInfo(int id, out TCompType objectType)
    {
      var rcwFactoryObject = GetRcwObjectInfo(id);
      objectType = (TCompType)GetRcwProperty("ComponentType");

      return rcwFactoryObject;
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    protected object GetRcwObjectInfo(int id)
    {
      var rcwObjectInfo = GetRcwProperty("ObjectInfo", id);

      return rcwObjectInfo;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwFactory">COM-объект фабрики.</param>
    /// <param name="scope">Область видимости.</param>
    protected Factory(object rcwFactory, IScope scope) : base(rcwFactory, scope) { }

    #endregion
  }
}
