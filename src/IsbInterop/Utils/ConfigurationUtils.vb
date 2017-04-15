Imports System.ComponentModel
Imports System.Configuration
Imports System.IO

Namespace Utils

  ''' <summary>
  ''' Утилиты для работы с конигурацией.
  ''' </summary>
  Public NotInheritable Class ConfigurationUtils

    ''' <summary>
    ''' Конфигурация isbInterop.
    ''' </summary>
    Private Shared ReadOnly isbInteropConfiguration As New Lazy(Of Configuration)(AddressOf TryGetIsbInteropConfiguration, True)

    ''' <summary>
    ''' Получат настройки строки подключения.
    ''' </summary>
    ''' <returns>Настройки строки подключения.</returns>
    Public Shared Function GetConnectionString() As String
      Dim connectionStringSettings As ConnectionStringSettings

      Dim standaloneConfiguration = isbInteropConfiguration.Value
      If standaloneConfiguration IsNot Nothing Then
        connectionStringSettings = standaloneConfiguration.ConnectionStrings.ConnectionStrings("IsbInterop")
      Else
        connectionStringSettings = ConfigurationManager.ConnectionStrings("IsbInterop")
      End If

      Dim connectionString = If(connectionStringSettings IsNot Nothing, connectionStringSettings.ConnectionString, Nothing)

      Return connectionString
    End Function

    ''' <summary>
    ''' Получает настройку секции appSettings.
    ''' </summary>
    ''' <typeparam name="T">Тип результата.</typeparam>
    ''' <param name="settingName">Имя настройки/</param>
    ''' <param name="result">Результат.</param>
    ''' <returns>True, если удалось получить настройку, иначе false.</returns>
    Public Shared Function TryGetAppSetting(Of T)(settingName As String, ByRef result As T) As Boolean
      If settingName Is Nothing Then
        Throw New ArgumentNullException("settingName")
      End If

      Dim settingValue As String = Nothing

      Dim standaloneConfiguration = isbInteropConfiguration.Value
      If standaloneConfiguration IsNot Nothing Then
        Dim setting = standaloneConfiguration.AppSettings.Settings(settingName)
        If setting IsNot Nothing Then
          settingValue = setting.Value
        End If
      Else
        settingValue = ConfigurationManager.AppSettings(settingName)
      End If

      If settingValue IsNot Nothing Then
        Return TryConvert(settingValue, result)
      Else
        Return False
      End If
    End Function

    ''' <summary>
    ''' Получает конфигурацию сборки IsbInterop.
    ''' </summary>
    ''' <returns>Конфигурация, если она существует, иначе null.</returns>
    Private Shared Function TryGetIsbInteropConfiguration() As Configuration
      Dim currentAssembly = GetType(IsbApplicationManager).Assembly
      Dim assemblyPath = New Uri(currentAssembly.CodeBase).LocalPath
      Dim assemblyPathWithoutExtenstion = assemblyPath.Substring(0, assemblyPath.Length - 4)
      Dim configPath = String.Format("{0}.dll.config", assemblyPathWithoutExtenstion)

      ' Проверяем, что файл существует, т.к.метод OpenMappedExeConfiguration всегда создает объект конфигурации.
      If Not File.Exists(configPath) Then
        Return Nothing
      End If

      Dim configMap = New ExeConfigurationFileMap()
      configMap.ExeConfigFilename = configPath

      Dim configuration As Configuration = Nothing
      Try
        configuration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None)
        ' We could log.trace this exception if we have logger.
      Catch generatedExceptionName As ConfigurationErrorsException
      End Try

      Return configuration
    End Function

    ''' <summary>
    ''' Конвертирует строку в заданный тип.
    ''' </summary>
    ''' <typeparam name="T">Тип результата.</typeparam>
    ''' <param name="source">Исходное значение.</param>
    ''' <param name="result">Результат.</param>
    ''' <returns>Экземпляр типа.</returns>
    Private Shared Function TryConvert(Of T)(source As String, ByRef result As T) As Boolean
      Dim typeConverter = TypeDescriptor.GetConverter(GetType(T))
      If typeConverter.CanConvertFrom(GetType(String)) Then
        Try
          result = DirectCast(typeConverter.ConvertFrom(source), T)
          Return True
          ' ReSharper disable once EmptyGeneralCatchClause
        Catch ex As Exception
        End Try
      End If

      Return False
    End Function

    ''' <summary>
    ''' Шифрует строки подключения.
    ''' </summary>
    Public Shared Sub EncryptConnectionStrings()
      Dim configuration = isbInteropConfiguration.Value
      If configuration Is Nothing Then
        Try
          configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Catch generatedExceptionName As ConfigurationErrorsException
          Return
        End Try
      End If

      Dim configSection = configuration.ConnectionStrings

      If configSection Is Nothing Then
        Return
      End If

      Try
        If Not configSection.IsReadOnly() AndAlso Not configSection.ElementInformation.IsLocked AndAlso Not configSection.SectionInformation.IsLocked Then
          If Not configSection.SectionInformation.IsProtected Then
            configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
          End If

          configSection.SectionInformation.ForceSave = True

          configuration.Save()
        End If
        ' ReSharper disable once EmptyGeneralCatchClause
      Catch generatedExceptionName As Exception
      End Try
    End Sub

    ''' <summary>
    ''' Приватный конструктор.
    ''' </summary>
    Private Sub New()
    End Sub
  End Class
End NameSpace