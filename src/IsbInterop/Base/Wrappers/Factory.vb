Imports IsbInterop.DataTypes.Enumerable

Namespace Base.Wrappers
    ''' <summary>
    ''' Обертка над IFactory.
    ''' </summary>
    Public MustInherit Class Factory(Of T As IIsbComObjectWrapper, TI As IObjectInfo)
        Inherits IsbComObjectWrapper
        Implements IFactory(Of T, TI)

#Region "Поля и свойства"

        ''' <summary>
        ''' Тип объектов фабрики.
        ''' </summary>
        Public ReadOnly Property Kind() As TContentKind Implements IFactory(Of T, TI).Kind
            Get
                Dim kindType As Integer = CInt(Me.GetRcwProperty("Kind"))

                If [Enum].IsDefined(GetType(TContentKind), kindType) Then
                    Return DirectCast(kindType, TContentKind)
                Else
                    Return TContentKind.ckUnknown
                End If
            End Get
        End Property

#End Region

#Region "Методы"

        ''' <summary>
        ''' Получить объект фабрики по ИД.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <returns>Объект фабрики.</returns>
        Public MustOverride Function GetObjectById(ByVal id As Integer) As T Implements IFactory(Of T, TI).GetObjectById

        ''' <summary>
        ''' Получить объект фабрики по ИД.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <param name="objectType">Тип объекта.</param>
        ''' <returns>Объект фабрики.</returns>
        Protected Function GetRcwObjectById(id As Integer, ByRef objectType As TCompType) As Object
            Dim rcwFactoryObject = Me.GetRcwObjectById(id)
            objectType = DirectCast(ComUtils.GetRcwProperty(rcwFactoryObject, "ComponentType"), TCompType)

            Return rcwFactoryObject
        End Function

        ''' <summary>
        ''' Получить объект фабрики по ИД.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <returns>Объект фабрики.</returns>
        Protected Function GetRcwObjectById(id As Integer) As Object
            Return Me.InvokeRcwInstanceMethod("GetObjectByID", id)
        End Function

        ''' <summary>
        ''' Получить информацию об объекте.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <returns>Info-объект.</returns>
        Public MustOverride Function GetObjectInfo(ByVal id As Integer) As TI Implements IFactory(Of T, TI).GetObjectInfo

        ''' <summary>
        ''' Получить информацию об объекте.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <param name="objectType">Тип объекта.</param>
        ''' <returns>Info-объект.</returns>
        Protected Function GetRcwObjectInfo(id As Integer, ByRef objectType As TCompType) As Object
            Dim rcwFactoryObject = Me.GetRcwObjectInfo(id)
            objectType = DirectCast(Me.GetRcwProperty("ComponentType"), TCompType)

            Return rcwFactoryObject
        End Function

        ''' <summary>
        ''' Получить информацию об объекте.
        ''' </summary>
        ''' <param name="id">ИД объекта.</param>
        ''' <returns>Info-объект.</returns>
        Protected Function GetRcwObjectInfo(id As Integer) As Object
            Dim rcwObjectInfo = Me.GetRcwProperty("ObjectInfo", id)

            Return rcwObjectInfo
        End Function

#End Region

#Region "Конструкторы"

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwFactory">COM-объект фабрики.</param>
        Protected Sub New(rcwFactory As Object)
            MyBase.New(rcwFactory)
        End Sub

#End Region

    End Class
End Namespace