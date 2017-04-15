Imports IsbInterop.DataTypes.Enumerable

Namespace EDocuments.Proxies

  ''' <summary>
  ''' Обертка над IEDocumentVersion.
  ''' </summary>
  Friend Class EDocumentVersion
    Inherits BaseIsbObject
    Implements IEDocumentVersion

    ''' <summary>
    ''' Текущее сосотяние версии.
    ''' </summary>
    Public ReadOnly Property CurrentState As TEDocumentVersionState Implements IEDocumentVersion.CurrentState
      Get
        Dim state = CInt(GetRcwProperty("CurrentState"))

        If [Enum].IsDefined(GetType(TEDocumentVersionState), state) Then
          Return state
        Else
          Return TEDocumentVersionState.vsUnknown
        End If
      End Get
    End Property

    ''' <summary>
    ''' Скрытая версия.
    ''' </summary>
    Public ReadOnly Property IsHidden As Boolean Implements IEDocumentVersion.IsHidden
      Get
        Return GetRcwProperty("IsHidden")
      End Get
    End Property

    ''' <summary>
    ''' Номер версии.
    ''' </summary>
    Public ReadOnly Property Number As Integer Implements IEDocumentVersion.Number
      Get
        Return GetRcwProperty("Number")
      End Get
    End Property

    ''' <summary>
    ''' Размер версии.
    ''' </summary>
    Public ReadOnly Property Size As Integer Implements IEDocumentVersion.Size
      Get
        Return GetRcwProperty("Size")
      End Get
    End Property

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="version">Версия документа.</param>
    ''' <param name="scope">Область видимости.</param>
    Public Sub New(version As Object, scope As IScope)
      MyBase.New(version, scope)
    End Sub
  End Class
End Namespace