Imports IsbInterop.DataTypes.Enumerable

Namespace EDocuments

  ''' <summary>
  ''' Версия электронного документа.
  ''' </summary>
  Public Interface IEDocumentVersion
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Текущее сосотяние версии.
    ''' </summary>
    ReadOnly Property CurrentState As TEDocumentVersionState

    ''' <summary>
    ''' Скрытая версия.
    ''' </summary>
    ReadOnly Property IsHidden As Boolean

    ''' <summary>
    ''' Номер версии.
    ''' </summary>
    ReadOnly Property Number As Integer

    ''' <summary>
    ''' Размер версии.
    ''' </summary>
    ReadOnly Property Size As Integer
  End Interface
End Namespace