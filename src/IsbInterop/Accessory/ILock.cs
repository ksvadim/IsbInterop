﻿using IsbInterop.DataTypes.Enumerable;
using System;

namespace IsbInterop.Accessory
{
  /// <summary>
  /// Интерфейс блокировки.
  /// </summary>
  public interface ILock
  {
    #region Поля и свойства

    /// <summary>
    /// IP-адрес компьютера пользователя, от имени которого производятся вычисления,
    /// блокирующие объект системы.
    /// Если объект не заблокирован, то свойство возвращает пустую строку.
    /// Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    /// </summary>
    string Hostname { get; }

    /// <summary>
    /// Признак наличия блокировки объекта системы.
    /// При обращении к свойству обновляется информация о блокировке: значения свойств HostName, LockTime, UserName.
    /// </summary>
    bool Locked { get; }

    /// <summary>
    /// Признак принадлежности блокировки данному объекту.
    /// True, если объект заблокирован этим объектом блокировки, иначе False.
    /// </summary>
    bool LockedByThis { get; }

    /// <summary>
    /// Дата и время установки блокировки на объект системы.
    /// Если объект не заблокирован, то дата и время будут равны нулю.
    /// Значение свойства обновляется при  проверке наличия блокировки объекта с помощью вызова свойства Locked.
    /// </summary>
    DateTime LockTime { get; }

    /// <summary>
    /// ИД объекта, для которого был создан объект-блокировка.
    /// </summary>
    int ObjectId { get; }

    /// <summary>
    /// Тип объекта системы.
    /// </summary>
    TCompType ObjectType { get; }

    /// <summary>
    /// Код системы, в которой был создан объект-блокировка.
    /// Значение свойства не зависит от того заблокирован объект или нет.
    /// </summary>
    string SystemCode { get; }

    /// <summary>
    /// Имя пользователя, от имени которого выполняются вычисления, блокирующие объект системы.
    /// Если объект не заблокирован, то свойство возвращает пустую строку.
    /// Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    /// </summary>
    string UserName { get; }

    #endregion

    #region Методы

    /// <summary>
    /// Пытается заблокировать объект в течение указанного времени.
    /// </summary>
    /// <param name="milliseconds">Количество милисекунд, в течение которых производятся попытки
    /// заблокировать объект системы.</param>
    /// <returns>True, если объект заблокирован, иначе будет сгенерировано исключение.</returns>
    bool LockObjectTimeout(int milliseconds);

    /// <summary>
    /// Пытается заблокировать объект системы в течение указанного времени.
    /// Объект можно заблокировать, только если он не заблокирован другим пользователем
    /// и если у пользователя, вызвавшего метод, есть права на изменение объекта.
    /// </summary>
    /// <returns>True, если удалось заблокировать объект, иначе False.</returns>
    bool TryLockObject();

    /// <summary>
    /// Разблокирует объект системы.
    /// Объект можно разблокировать, если он был заблокирован этим же объектом блокировки,
    /// иначе будет сгенерировано исключение.
    /// </summary>
    void UnlockObject();

    #endregion
  }
}