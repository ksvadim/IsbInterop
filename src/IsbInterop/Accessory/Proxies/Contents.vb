Imports IsbInterop.Base

Namespace Accessory.Proxies
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
        ''' <param name="scope">Область видимости.</param>
        Public Sub New(contentsObject As Object, scope As IScope)
            MyBase.New(contentsObject, Scope)
        End Sub
    End Class
End Namespace
