﻿Imports IsbInterop.DataTypes.Enumerable

Namespace Accessory
  ''' <summary>
  ''' Блокировка.
  ''' </summary>
  Public Interface ILock
#Region "Поля и свойства"

    ''' <summary>
    ''' IP-адрес компьютера пользователя, от имени которого производятся вычисления, 
    ''' блокирующие объект системы.
    ''' Если объект не заблокирован, то свойство возвращает пустую строку. 
    ''' Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    ''' </summary>
    ReadOnly Property Hostname() As String

    ''' <summary>
    ''' Признак наличия блокировки объекта системы.
    ''' При обращении к свойству обновляется информация о блокировке: значения свойств HostName, LockTime, UserName.
    ''' </summary>
    ReadOnly Property Locked() As Boolean

    ''' <summary>
    ''' Код системы, в которой был создан объект-блокировка.
    ''' Значение свойства не зависит от того заблокирован объект или нет.
    ''' </summary>
    ReadOnly Property SystemCode() As String

    ''' <summary>
    ''' Признак принадлежности блокировки данному объекту.
    ''' True, если объект заблокирован этим объектом блокировки, иначе False.
    ''' </summary>
    ReadOnly Property LockedByThis() As Boolean

    ''' <summary>
    ''' Дата и время установки блокировки на объект системы.
    ''' Если объект не заблокирован, то дата и время будут равны нулю.
    ''' Значение свойства обновляется при  проверке наличия блокировки объекта с помощью вызова свойства Locked.
    ''' </summary>
    ReadOnly Property LockTime() As DateTime

    ''' <summary>
    ''' ИД объекта, для которого был создан объект-блокировка.
    ''' </summary>
    ReadOnly Property ObjectId() As Integer

    ''' <summary>
    ''' Тип объекта системы.
    ''' </summary>
    ReadOnly Property ObjectType() As TCompType

    ''' <summary>
    ''' Имя пользователя, от имени которого выполняются вычисления, блокирующие объект системы.
    ''' Если объект не заблокирован, то свойство возвращает пустую строку.
    ''' Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    ''' </summary>
    ReadOnly Property UserName() As String

#End Region

#Region "Методы"

    ''' <summary>
    ''' Попытаться заблокировать объект в течение указанного времени.
    ''' </summary>
    ''' <param name="milliseconds">Количество милисекунд, в течение которых производятся попытки
    ''' заблокировать объект системы.</param>
    ''' <returns>True, если объект заблокирован, иначе будет сгенерировано исключение.</returns>
    Function LockObjectTimeout(milliseconds As Integer) As Boolean

    ''' <summary>
    ''' Попытаться заблокировать объект системы в течение указанного времени..
    ''' Объект можно заблокировать, только если он не заблокирован другим пользователем 
    ''' и если у пользователя, вызвавшего метод, есть права на изменение объекта.
    ''' </summary>
    ''' <returns>True, если удалось заблокировать объект, иначе False.</returns>
    Function TryLockObject() As Boolean

    ''' <summary>
    ''' Разблокировать объект системы.
    ''' Объект можно разблокировать, если он был заблокирован этим же объектом блокировки, 
    ''' иначе будет сгенерировано исключение.
    ''' </summary>
    Sub UnlockObject()

#End Region
  End Interface
End NameSpace