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
        Public Sub New(rcwIReferenceInfo As Object)
            MyBase.New(rcwIReferenceInfo)
        End Sub

    End Class
End Namespace