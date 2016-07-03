Namespace DataTypes.Enumerable
    ''' <summary>
    ''' Состояние детального раздела.
    ''' </summary>
    Public Enum TDataSetState
        ''' <summary>
        ''' Режим редактирования.
        ''' </summary>
        dssEdit = 0

        ''' <summary>
        ''' Режим вставки.
        ''' </summary>
        dssInsert = 1

        ''' <summary>
        ''' Режим просмотра.
        ''' </summary>
        dssBrowse = 2

        ''' <summary>
        ''' Режим неактивного набора данных.
        ''' </summary>
        dssInActive = 3
    End Enum
End Namespace