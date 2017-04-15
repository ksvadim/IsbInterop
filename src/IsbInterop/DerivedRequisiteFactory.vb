Imports IsbInterop.Data
Imports IsbInterop.Data.Proxies
Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.Utils

''' <summary>
''' Фабрика реквизитов, унаследованных от IRequisite.
''' </summary>
Friend NotInheritable Class DerivedRequisiteFactory

  ''' <summary>
  ''' Создает реквизит.
  ''' </summary>
  ''' <param name="rcwRequisite">RCW-объект реквизита.</param>
  ''' <param name="scope">Область видимости.</param>
  ''' <returns>Реквизит с заданным типом.</returns>
  Public Shared Function CreateRequisite(rcwRequisite As Object, scope As IScope) As IRequisite
    Dim type = TReqDataType.rdtUnknown

    Dim dataType = CInt(ComUtils.GetRcwProperty(rcwRequisite, "DataType"))

    If [Enum].IsDefined(GetType(TReqDataType), dataType) Then
      type = DirectCast(dataType, TReqDataType)
    End If

    Select Case type
      Case TReqDataType.rdtPick
        Return New PickRequisite(rcwRequisite, scope)
      Case TReqDataType.rdtDate, TReqDataType.rdtInteger, TReqDataType.rdtNumeric,
          TReqDataType.rdtReference, TReqDataType.rdtString, TReqDataType.rdtText
        Return New Requisite(rcwRequisite, scope)
      Case Else
        Return New Requisite(rcwRequisite, scope)
    End Select
  End Function

  ''' <summary>
  ''' Приватный конструктор.
  ''' </summary>
  Private Sub New()
  End Sub
End Class
