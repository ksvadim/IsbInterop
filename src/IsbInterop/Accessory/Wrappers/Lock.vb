Imports IsbInterop.DataTypes.Enumerable

Namespace Accessory.Wrappers

  ''' <summary>
  ''' Обертка над ILock.
  ''' </summary>
  Public Class Lock
    Inherits BaseIsbObject
    Implements ILock

#Region "Поля и свойства"

    ''' <summary>
    ''' IP-адрес компьютера пользователя, от имени которого производятся вычисления,
    ''' блокирующие объект системы.
    ''' Если объект не заблокирован, то свойство возвращает пустую строку.
    ''' Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    ''' </summary>
    Public ReadOnly Property Hostname As String Implements ILock.Hostname
      Get
        Return DirectCast(GetRcwProperty("Hostname"), String)
      End Get
    End Property

    ''' <summary>
    ''' Признак наличия блокировки объекта системы.
    ''' При обращении к свойству обновляется информация о блокировке: значения свойств HostName, LockTime, UserName.
    ''' </summary>
    Public ReadOnly Property Locked As Boolean Implements ILock.Locked
      Get
        Return CBool(GetRcwProperty("Locked"))
      End Get
    End Property

    ''' <summary>
    ''' Признак принадлежности блокировки данному объекту.
    ''' True, если объект заблокирован этим объектом блокировки, иначе False.
    ''' </summary>
    Public ReadOnly Property LockedByThis As Boolean Implements ILock.LockedByThis
      Get
        Return CBool(GetRcwProperty("LockedByThis"))
      End Get
    End Property

    ''' <summary>
    ''' Дата и время установки блокировки на объект системы.
    ''' Если объект не заблокирован, то дата и время будут равны нулю.
    ''' Значение свойства обновляется при  проверке наличия блокировки объекта с помощью вызова свойства Locked.
    ''' </summary>
    Public ReadOnly Property LockTime As DateTime Implements ILock.LockTime
      Get
        Return DirectCast(GetRcwProperty("LockTime"), DateTime)
      End Get
    End Property

    ''' <summary>
    ''' ИД объекта, для которого был создан объект-блокировка.
    ''' </summary>
    Public ReadOnly Property ObjectId As Integer Implements ILock.ObjectId
      Get
        Return CInt(GetRcwProperty("ObjectID"))
      End Get
    End Property

    ''' <summary>
    ''' Тип объекта системы.
    ''' </summary>
    Public ReadOnly Property ObjectType As TCompType Implements ILock.ObjectType
      Get
        Return DirectCast(GetRcwProperty("ObjectType"), TCompType)
      End Get
    End Property

    ''' <summary>
    ''' Код системы, в которой был создан объект-блокировка.
    ''' Значение свойства не зависит от того заблокирован объект или нет.
    ''' </summary>
    Public ReadOnly Property SystemCode As String Implements ILock.SystemCode
      Get
        Return DirectCast(GetRcwProperty("SystemCode"), String)
      End Get
    End Property

    ''' <summary>
    ''' Имя пользователя, от имени которого выполняются вычисления, блокирующие объект системы.
    ''' Если объект не заблокирован, то свойство возвращает пустую строку.
    ''' Значение свойства обновляется при проверке наличия блокировки объекта с помощью вызова свойства Locked.
    ''' </summary>
    Public ReadOnly Property UserName As String Implements ILock.UserName
      Get
        Return DirectCast(GetRcwProperty("UserName"), String)
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Попытаться заблокировать объект в течение указанного времени.
    ''' </summary>
    ''' <param name="milliseconds">Количество милисекунд, в течение которых производятся попытки
    ''' заблокировать объект системы.</param>
    ''' <returns>True, если объект заблокирован, иначе будет сгенерировано исключение.</returns>
    Public Function LockObjectTimeout(milliseconds As Integer) As Boolean Implements ILock.LockObjectTimeout
      Dim result = CBool(InvokeRcwInstanceMethod("LockObjectTimeout", milliseconds))
      Return result
    End Function

    ''' <summary>
    ''' Попытаться заблокировать объект системы в течение указанного времени.
    ''' Объект можно заблокировать, только если он не заблокирован другим пользователем
    ''' и если у пользователя, вызвавшего метод, есть права на изменение объекта.
    ''' </summary>
    ''' <returns>True, если удалось заблокировать объект, иначе False.</returns>
    Public Function TryLockObject() As Boolean Implements ILock.TryLockObject
      Dim result = CBool(InvokeRcwInstanceMethod("TryLockObject"))
      Return result
    End Function

    ''' <summary>
    ''' Разблокировать объект системы.
    ''' Объект можно разблокировать, если он был заблокирован этим же объектом блокировки,
    ''' иначе будет сгенерировано исключение.
    ''' </summary>
    Public Sub UnlockObject() Implements ILock.UnlockObject
      InvokeRcwInstanceMethod("UnlockObject")
    End Sub

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwILock">COM-объект ILock.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwILock As Object, scope As IScope)
      MyBase.New(rcwILock, scope)
    End Sub

#End Region

  End Class
End Namespace
