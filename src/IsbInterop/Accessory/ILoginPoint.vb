Imports System.Runtime.InteropServices

Namespace Accessory
  ''' <summary>
  ''' Точка входа.
  ''' </summary>
  Public Interface ILoginPoint
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' ИД процесса Application.
    ''' </summary>
    ReadOnly Property PID() As Integer

    ''' <summary>
    ''' Получить объект приложения.
    ''' </summary>
    ''' <param name="connectionParams">Параметры подключения.</param>
    ''' <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш: 
    ''' True, если нужно добавить информацию, иначе False.</param>
    ''' <returns>Объект приложения IApplication, или null.</returns>
    Function GetApplication(connectionParams As String, Optional storeInCache As Boolean = True) As IApplication

    ''' <summary>
    ''' Получить объект приложения.
    ''' </summary>
    ''' <param name="connectionParams">Параметры подключения.</param>
    ''' <param name="errorCode">Код ошибки.</param>
    ''' <returns>Объект приложения IApplication, или null.</returns>
    Function GetApplicationEx(connectionParams As String, <Out()> ByRef errorCode As Integer) As IApplication
  End Interface
End Namespace