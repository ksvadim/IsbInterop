Imports IsbInterop.Base.Proxies

Namespace References.Proxies

    ''' <summary>
    ''' Обертка над ICompRecordInfo.
    ''' </summary>
    Friend MustInherit Class CompRecordInfo
        Inherits ObjectInfo
        Implements ICompRecordInfo

        ''' <summary>
        ''' Код записи.
        ''' </summary>
        Public ReadOnly Property Code As String Implements ICompRecordInfo.Code
            Get
                Return DirectCast(GetRcwProperty("Code"), String)
            End Get
        End Property

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwICompRecordInfo">COM-объект ICompRecordInfo.</param>
        ''' <param name="scope">Область видимости.</param>
        Protected Sub New(rcwICompRecordInfo As Object, scope As IScope)
            MyBase.New(rcwICompRecordInfo, scope)
        End Sub
    End Class
End Namespace