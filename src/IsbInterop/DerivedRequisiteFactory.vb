Imports IsbInterop.Data
Imports IsbInterop.Data.Wrappers
Imports IsbInterop.DataTypes.Enumerable

''' <summary>
''' Фабрика реквизитов, унаследованных от IRequisite.
''' </summary>
Friend NotInheritable Class DerivedRequisiteFactory

  ''' <summary>
  ''' Создать реквизит.
  ''' </summary>
  ''' <param name="rcwRequisite">RCW-объект реквизита.</param>
  ''' <returns>Реквизит с заданным типом.</returns>
  Public Shared Function CreateRequisite(rcwRequisite As Object) As IRequisite
    Dim type = TReqDataType.rdtUnknown

    Dim dataType As Integer = CInt(ComUtils.GetRcwProperty(rcwRequisite, "DataType"))

    If [Enum].IsDefined(GetType(TReqDataType), dataType) Then
      type = DirectCast(dataType, TReqDataType)
    End If

    Select Case type
      Case TReqDataType.rdtPick
        Return New PickRequisite(rcwRequisite)
      Case TReqDataType.rdtDate, TReqDataType.rdtInteger, TReqDataType.rdtNumeric,
          TReqDataType.rdtReference, TReqDataType.rdtString, TReqDataType.rdtText
        Return New Requisite(rcwRequisite)
      Case Else
        Return New Requisite(rcwRequisite)
    End Select
  End Function

  ''' <summary>
  ''' Приватный конструктор.
  ''' </summary>
  Private Sub New()
  End Sub
End Class
