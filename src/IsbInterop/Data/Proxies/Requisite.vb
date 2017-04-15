Imports IsbInterop.DataTypes.Enumerable

Namespace Data.Proxies

  ''' <summary>
  ''' Обертка над IRequisite.
  ''' </summary>
  Friend Class Requisite
    Inherits BaseIsbObject
    Implements IRequisite

#Region "Поля и свойства"

    ''' <summary>
    ''' Значение реквизита в качестве даты.
    ''' </summary>
    Public ReadOnly Property AsDate As DateTime Implements IRequisite.AsDate
      Get
        Return GetRcwProperty("AsDate")
      End Get
    End Property

    ''' <summary>
    ''' Целочисленное значение реквизита.
    ''' </summary>
    Public ReadOnly Property AsInteger As Integer Implements IRequisite.AsInteger
      Get
        Return GetRcwProperty("AsInteger")
      End Get
    End Property

    ''' <summary>
    ''' Строковое значение реквизита.
    ''' </summary>
    Public ReadOnly Property AsString As String Implements IRequisite.AsString
      Get
        Return DirectCast(GetRcwProperty("AsString"), String)
      End Get
    End Property

    ''' <summary>
    ''' Тип реквизита.
    ''' </summary>
    Public ReadOnly Property DataType As TReqDataType Implements IRequisite.DataType
      Get
        Dim requisiteDataType = CInt(GetRcwProperty("DataType"))

        If [Enum].IsDefined(GetType(TReqDataType), requisiteDataType) Then
          Return requisiteDataType
        Else
          Return TReqDataType.rdtUnknown
        End If
      End Get
    End Property

    ''' <summary>
    ''' Имя поля реквизита в базе.
    ''' </summary>
    Public ReadOnly Property FieldName As String Implements IRequisite.FieldName
      Get
        Return DirectCast(GetRcwProperty("FieldName"), String)
      End Get
    End Property

    ''' <summary>
    ''' Признак, указывающий, что реквизит равен null.
    ''' </summary>
    Public ReadOnly Property IsNull As Boolean Implements IRequisite.IsNull
      Get
        Return GetRcwProperty("IsNull")
      End Get
    End Property

    ''' <summary>
    ''' Имя реквизита.
    ''' </summary>
    Public ReadOnly Property Name As String Implements IRequisite.Name
      Get
        Return DirectCast(GetRcwProperty("Name"), String)
      End Get
    End Property

    ''' <summary>
    ''' Значение реквизита.
    ''' </summary>
    Public Property Value As Object Implements IRequisite.Value
      Get
        Return GetRcwProperty("Value")
      End Get
      Set(requisiteValue As Object)
        SetRcwProperty("Value", requisiteValue)
      End Set
    End Property

#End Region

#Region "Конструктор"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwRequisite">COM-объект реквизит.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwRequisite As Object, scope As IScope)
      MyBase.New(rcwRequisite, scope)
    End Sub

#End Region

  End Class
End Namespace