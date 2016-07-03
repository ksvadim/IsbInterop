Imports IsbInterop.Base

Namespace Scripts
  ''' <summary>
  ''' Фабрика сценариев.
  ''' </summary>
  Public Interface IScriptFactory
    Inherits IFactory(Of IScript, IObjectInfo)

    ''' <summary>
    ''' Получить сценарий по имени.
    ''' </summary>
    ''' <param name="scriptName">Имя сценария.</param>
    ''' <returns>Сценарий.</returns>
    Function GetObjectByName(scriptName As String) As IScript
  End Interface
End NameSpace