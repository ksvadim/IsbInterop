Namespace References.Wrappers
    ''' <summary>
    ''' Оберка над IReferencesFactory.
    ''' </summary>
    Friend Class ReferencesFactory
        Inherits IsbComObjectWrapper
        Implements IReferencesFactory

        ''' <summary>
        ''' Получить фабрику типов справочников.
        ''' </summary>
        ''' <param name="referenceFactoryName">Имя фабрики типов справочников.</param>
        ''' <returns>Фабрика типов справочников.</returns>
        Public Function GetReferenceFactory(referenceFactoryName As String) As IReferenceFactory Implements IReferencesFactory.GetReferenceFactory
            Dim rcwReferenceFactory = GetRcwProperty("ReferenceFactory", referenceFactoryName)
            Dim referenceFactory = New ReferenceFactory(rcwReferenceFactory, Scope)

            Return referenceFactory
        End Function

        ''' <summary>
        ''' Конструктор.
        ''' </summary>
        ''' <param name="rcwReferencesFactory">COM-объект ReferencesFactory.</param>
        ''' <param name="scope">Область видимости.</param>
        Friend Sub New(rcwReferencesFactory As Object, scope As IScope)
            MyBase.New(rcwReferencesFactory, scope)
        End Sub
    End Class
End Namespace