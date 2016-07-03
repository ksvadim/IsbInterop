Imports IsbInterop.DataTypes.Enumerable

Namespace Data
  ''' <summary>
  ''' Реквизит.
  ''' </summary>
  Public Interface IRequisite
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Значение реквизита.
    ''' </summary>
    Property Value() As Object

    ''' <summary>
    ''' Целочисленное значение реквизита.
    ''' </summary>
    ReadOnly Property AsInteger() As Integer

    ''' <summary>
    ''' Строковое значение реквизита.
    ''' </summary>
    ReadOnly Property AsString() As String

    ''' <summary>
    ''' Значение реквизита в качестве даты.
    ''' </summary>
    ReadOnly Property AsDate() As DateTime

    ''' <summary>
    ''' Имя реквизита.
    ''' </summary>
    ReadOnly Property Name() As String

    ''' <summary>
    ''' Имя поля реквизита в базе.
    ''' </summary>
    ReadOnly Property FieldName() As String

    ''' <summary>
    ''' Признак, указывающий, что реквизит равен null.
    ''' </summary>
    ReadOnly Property IsNull() As Boolean

    ''' <summary>
    ''' Тип реквизита.
    ''' </summary>
    ReadOnly Property DataType() As TReqDataType

  End Interface
End NameSpace