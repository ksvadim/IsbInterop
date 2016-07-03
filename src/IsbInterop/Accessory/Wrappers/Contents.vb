Imports IsbInterop.Base

Namespace Accessory.Wrappers
    ''' <summary>
    ''' Обертка над IContents.
    ''' </summary>
    Friend Class Contents(Of TI As IObjectInfo)
        Inherits ForEach(Of TI)
        Implements IContents(Of TI)
        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="contentsObject">Объект IContents.</param>
        Public Sub New(contentsObject As Object)
            MyBase.New(contentsObject)
        End Sub
    End Class
End Namespace
