using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace IsbInterop
{
  /// <summary>
  /// Утилиты для работы с конфигурацией.
  /// </summary>
  public static class ConfigurationUtils
  {
    /// <summary>
    /// Конфигурация isbInterop.
    /// </summary>
    private static readonly Lazy<Configuration> isbInteropConfiguration = new Lazy<Configuration>(TryGetIsbInteropConfiguration, true);

    /// <summary>
    /// Получить настройки строки подключения.
    /// </summary>
    /// <returns>Настройки строки подключения.</returns>
    public static string GetConnectionString()
    {
      ConnectionStringSettings connectionStringSettings;

      var standaloneConfiguration = isbInteropConfiguration.Value;
      if (standaloneConfiguration != null)
        connectionStringSettings = standaloneConfiguration.ConnectionStrings.ConnectionStrings["IsbInterop"];
      else
        connectionStringSettings = ConfigurationManager.ConnectionStrings["IsbInterop"];

      var connectionString = connectionStringSettings != null ?
        connectionStringSettings.ConnectionString : null;

      return connectionString;
    }

    /// <summary>
    /// Получить настройку секции appSettings.
    /// </summary>
    /// <typeparam name="T">Тип результата.</typeparam>
    /// <param name="settingName">Имя настройки/</param>
    /// <param name="result">Результат.</param>
    /// <returns>True, если удалось получить настройку, иначе false.</returns>
    public static bool TryGetAppSetting<T>(string settingName, ref T result)
    {
      if (settingName == null)
        throw new ArgumentNullException("settingName");

      string settingValue = null;

      var standaloneConfiguration = isbInteropConfiguration.Value;
      if (standaloneConfiguration != null)
      {
        var setting = standaloneConfiguration.AppSettings.Settings[settingName];
        if (setting != null)
          settingValue = setting.Value;
      }
      else
        settingValue = ConfigurationManager.AppSettings[settingName];

      if (settingValue != null)
        return TryConvert(settingValue, ref result);
      else
        return false;
    }

    /// <summary>
    /// Получить конфигурацию сборки IsbInterop.
    /// </summary>
    /// <returns>Конфигурация, если она существует, иначе null.</returns>
    private static Configuration TryGetIsbInteropConfiguration()
    {
      var currentAssembly = typeof(IsbApplicationManager).Assembly;
      var assemblyPath = new Uri(currentAssembly.CodeBase).LocalPath;
      var assemblyPathWithoutExtenstion = assemblyPath.Substring(0, assemblyPath.Length - 4);
      var configPath = string.Format("{0}.dll.config", assemblyPathWithoutExtenstion);

      // Проверяем, что файл существует, т.к.метод OpenMappedExeConfiguration всегда создает объект конфигурации.
      if (!File.Exists(configPath))
        return null;

      var configMap = new ExeConfigurationFileMap();
      configMap.ExeConfigFilename = configPath;

      Configuration configuration = null;
      try
      {
        configuration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
      }
      catch (ConfigurationErrorsException)
      {
        // We could log.trace this exception if we have logger.
      }

      return configuration;
    }

    /// <summary>
    /// Сконвертировать строку в заданный тип.
    /// </summary>
    /// <typeparam name="T">Тип результата.</typeparam>
    /// <param name="source">Исходное значение.</param>
    /// <param name="result">Результат.</param>
    /// <returns>Экземпляр типа.</returns>
    private static bool TryConvert<T>(string source, ref T result)
    {
      var typeConverter = TypeDescriptor.GetConverter(typeof(T));
      if (typeConverter.CanConvertFrom(typeof(string)))
      {
        try
        {
          result = (T)typeConverter.ConvertFrom(source);
          return true;
        }
        // ReSharper disable once EmptyGeneralCatchClause
        catch (Exception)
        {
        }
      }

      return false;
    }

    /// <summary>
    /// Зашифровать строки подключения.
    /// </summary>
    public static void EncryptConnectionStrings()
    {
      var configuration = isbInteropConfiguration.Value;
      if (configuration == null)
      {
        try
        {
          configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        catch (ConfigurationErrorsException)
        {
          return;
        }
      }

      var configSection = configuration.ConnectionStrings;

      if (configSection == null)
        return;

      try
      {
        if (!configSection.IsReadOnly() && !configSection.ElementInformation.IsLocked && !configSection.SectionInformation.IsLocked)
        {
          if (!configSection.SectionInformation.IsProtected)
            configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

          configSection.SectionInformation.ForceSave = true;

          configuration.Save();
        }
      }
      // ReSharper disable once EmptyGeneralCatchClause
      catch (Exception)
      {
      }
    }
  }
}
