Imports IsbInterop.DataTypes.Enumerable

Namespace Data

  ''' <summary>
  ''' Реквизит.
  ''' </summary>
  Public Interface IRequisite
    Inherits IBaseIsbObject

    ''' <summary>
    ''' Целочисленное значение реквизита.
    ''' </summary>
    ReadOnly Property AsInteger As Integer

    ''' <summary>
    ''' Строковое значение реквизита.
    ''' </summary>
    ReadOnly Property AsString As String

    ''' <summary>
    ''' Значение реквизита в качестве даты.
    ''' </summary>
    ReadOnly Property AsDate As DateTime

    ''' <summary>
    ''' Тип реквизита.
    ''' </summary>
    ReadOnly Property DataType As TReqDataType

    ''' <summary>
    ''' Имя поля реквизита в базе.
    ''' </summary>
    ReadOnly Property FieldName As String

    ''' <summary>
    ''' Признак, указывающий, что реквизит равен null.
    ''' </summary>
    ReadOnly Property IsNull As Boolean

    ''' <summary>
    ''' Имя реквизита.
    ''' </summary>
    ReadOnly Property Name As String

    ''' <summary>
    ''' Значение реквизита.
    ''' </summary>
    Property Value As Object
  End Interface
End Namespace