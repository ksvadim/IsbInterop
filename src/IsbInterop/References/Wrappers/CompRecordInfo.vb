Imports IsbInterop.Base.Wrappers

Namespace References.Wrappers
    ''' <summary>
    ''' Обертка над ICompRecordInfo.
    ''' </summary>
    Friend MustInherit Class CompRecordInfo
        Inherits ObjectInfo
        Implements ICompRecordInfo

        ''' <summary>
        ''' Код записи.
        ''' </summary>
        Public ReadOnly Property Code() As String Implements ICompRecordInfo.Code
            Get
                Return DirectCast(Me.GetRcwProperty("Code"), String)
            End Get
        End Property

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwICompRecordInfo">COM-объект ICompRecordInfo.</param>
        Protected Sub New(rcwICompRecordInfo As Object)
            MyBase.New(rcwICompRecordInfo)
        End Sub
    End Class
End Namespace