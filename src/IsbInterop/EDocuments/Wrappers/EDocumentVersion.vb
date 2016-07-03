Imports IsbInterop.DataTypes.Enumerable

Namespace EDocuments.Wrappers
  ''' <summary>
  ''' Обертка над IEDocumentVersion.
  ''' </summary>
  Friend Class EDocumentVersion
    Inherits IsbComObjectWrapper
    Implements IEDocumentVersion

    ''' <summary>
    ''' Текущее сосотяние версии.
    ''' </summary>
    Public ReadOnly Property CurrentState() As TEDocumentVersionState Implements IEDocumentVersion.CurrentState
      Get
        Dim state As Integer = CInt(Me.GetRcwProperty("CurrentState"))

        If [Enum].IsDefined(GetType(TEDocumentVersionState), state) Then
          Return DirectCast(state, TEDocumentVersionState)
        Else
          Return TEDocumentVersionState.vsUnknown
        End If
      End Get
    End Property

    ''' <summary>
    ''' Скрытая версия.
    ''' </summary>
    Public ReadOnly Property IsHidden() As Boolean Implements IEDocumentVersion.IsHidden
      Get
        Return CBool(Me.GetRcwProperty("IsHidden"))
      End Get
    End Property

    ''' <summary>
    ''' Номер версии.
    ''' </summary>
    Public ReadOnly Property Number() As Integer Implements IEDocumentVersion.Number
      Get
        Return CInt(Me.GetRcwProperty("Number"))
      End Get
    End Property

    ''' <summary>
    ''' Размер версии.
    ''' </summary>
    Public ReadOnly Property Size() As Integer Implements IEDocumentVersion.Size
      Get
        Return CInt(Me.GetRcwProperty("Size"))
      End Get
    End Property

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    Public Sub New(version As Object)
      MyBase.New(version)
    End Sub
  End Class
End Namespace