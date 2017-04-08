using IsbInterop.DataTypes.Enumerable;
using System;

namespace IsbInterop.Accessory.Wrappers
{
  /// <summary>
  /// Обертка над ILock.
  /// </summary>
  public class Lock : IsbComObjectWrapper, ILock
  {
    #region Поля и свойства

    /// <summary>
    /// IP-адрес компьютера пользователя, от имени которого производятся вычисления, 
    /// блокирующие объект системы.
    /// Если объект не заблокирован, то свойство возвращает пустую строку. 
    /// Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    /// </summary>
    public string Hostname
    {
      get { return (string)this.GetRcwProperty("Hostname"); }
    }

    /// <summary>
    /// Признак наличия блокировки объекта системы.
    /// При обращении к свойству обновляется информация о блокировке: значения свойств HostName, LockTime, UserName.
    /// </summary>
    public bool Locked
    {
      get { return (bool)this.GetRcwProperty("Locked"); }
    }

    /// <summary>
    /// Код системы, в которой был создан объект-блокировка.
    /// Значение свойства не зависит от того заблокирован объект или нет.
    /// </summary>
    public string SystemCode
    {
      get { return (string)this.GetRcwProperty("SystemCode"); }
    }

    /// <summary>
    /// Признак принадлежности блокировки данному объекту.
    /// True, если объект заблокирован этим объектом блокировки, иначе False.
    /// </summary>
    public bool LockedByThis
    {
      get { return (bool)this.GetRcwProperty("LockedByThis"); }
    }

    /// <summary>
    /// Дата и время установки блокировки на объект системы.
    /// Если объект не заблокирован, то дата и время будут равны нулю.
    /// Значение свойства обновляется при  проверке наличия блокировки объекта с помощью вызова свойства Locked.
    /// </summary>
    public DateTime LockTime
    {
      get { return (DateTime)this.GetRcwProperty("LockTime"); }
    }

    /// <summary>
    /// ИД объекта, для которого был создан объект-блокировка.
    /// </summary>
    public int ObjectId
    {
      get { return (int)this.GetRcwProperty("ObjectID"); }
    }

    /// <summary>
    /// Тип объекта системы.
    /// </summary>
    public TCompType ObjectType
    {
      get { return (TCompType)this.GetRcwProperty("ObjectType"); }
    }

    /// <summary>
    /// Имя пользователя, от имени которого выполняются вычисления, блокирующие объект системы.
    /// Если объект не заблокирован, то свойство возвращает пустую строку.
    /// Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    /// </summary>
    public string UserName
    {
      get { return (string)this.GetRcwProperty("UserName"); }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Попытаться заблокировать объект в течение указанного времени.
    /// </summary>
    /// <param name="milliseconds">Количество милисекунд, в течение которых производятся попытки
    /// заблокировать объект системы.</param>
    /// <returns>True, если объект заблокирован, иначе будет сгенерировано исключение.</returns>
    public bool LockObjectTimeout(int milliseconds)
    {
      bool result = (bool)this.InvokeRcwInstanceMethod("LockObjectTimeout", milliseconds);
      return result;
    }

    /// <summary>
    /// Попытаться заблокировать объект системы в течение указанного времени..
    /// Объект можно заблокировать, только если он не заблокирован другим пользователем 
    /// и если у пользователя, вызвавшего метод, есть права на изменение объекта.
    /// </summary>
    /// <returns>True, если удалось заблокировать объект, иначе False.</returns>
    public bool TryLockObject()
    {
      bool result = (bool)this.InvokeRcwInstanceMethod("TryLockObject");
      return result;
    }

    /// <summary>
    /// Разблокировать объект системы.
    /// Объект можно разблокировать, если он был заблокирован этим же объектом блокировки, 
    /// иначе будет сгенерировано исключение.
    /// </summary>
    public void UnlockObject()
    {
      this.InvokeRcwInstanceMethod("UnlockObject");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwILock">COM-объект ILock.</param>
    /// <param name="scope">Область видимости.</param>
    internal Lock(object rcwILock, IScope scope) : base(rcwILock, scope) { }

    #endregion
  }
}
