using IsbInterop.DataTypes.Enumerable;
using System;

namespace IsbInterop.Base.Wrappers
{
  /// <summary>
  /// Обертка над IFactory.
  /// </summary>
  public abstract class Factory<T, TI> : IsbComObjectWrapper, IFactory<T, TI>
    where T : IIsbComObjectWrapper
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
      var rcwFactoryObject = this.GetRcwObjectInfo(id);
      objectType = (TCompType)this.GetRcwProperty("ComponentType");

      return rcwFactoryObject;
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    protected object GetRcwObjectInfo(int id)
    {
      var rcwObjectInfo = this.GetRcwProperty("ObjectInfo", id);

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
