Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers

Namespace Scripts.Wrappers

    ''' <summary>
    ''' Обертка над IScriptFactory.
    ''' </summary>
    Friend Class ScriptFactory
        Inherits Factory(Of IScript, IObjectInfo)
        Implements IScriptFactory

        ''' <summary>
        ''' Получить сценарий по имени.
        ''' </summary>
        ''' <param name="scriptName">Имя сценария.</param>
        ''' <returns>Сценарий.</returns>
        Public Function GetObjectByName(scriptName As String) As IScript Implements IScriptFactory.GetObjectByName
            Dim rcwScript = InvokeRcwInstanceMethod("GetObjectByName", scriptName)
            Return New Script(rcwScript, Scope)
        End Function

        ''' <summary>
        ''' Получить объект по его ИД.
        ''' </summary>
        ''' <param name="id">ИД.</param>
        ''' <returns>Объект.</returns>
        Public Overrides Function GetObjectById(id As Integer) As IScript
            Throw New NotSupportedException("This method is not supported by IS-Builder API.")
        End Function

    ''' <summary>
    ''' Получает информацию об объекте.
    ''' </summary>
    ''' <param name="id">ИД объекта.</param>
    ''' <returns>Info-объект.</returns>
    Public Overrides Function GetObjectInfo(id As Integer) As IObjectInfo
      Throw New NotSupportedException("This method is not supported by IS-Builder API.")
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIScriptFactory">COM-объект фабрика сценариев.</param>
    ''' <param name="scope">Область видимости.</param>
    Friend Sub New(rcwIScriptFactory As Object, scope As IScope)
            MyBase.New(rcwIScriptFactory, scope)
        End Sub
    End Class
End Namespace