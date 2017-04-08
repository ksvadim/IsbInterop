Namespace References.Wrappers

    ''' <summary>
    ''' Обертка над IReferenceInfo.
    ''' </summary>
    Friend Class ReferenceInfo
        Inherits CompRecordInfo
        Implements IReferenceInfo

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwIReferenceInfo">COM-объект IReferenceInfo.</param>
        ''' <param name="scope">Область видимости.</param>
        Public Sub New(rcwIReferenceInfo As Object, scope As IScope)
            MyBase.New(rcwIReferenceInfo, scope)
        End Sub

    End Class
End Namespace