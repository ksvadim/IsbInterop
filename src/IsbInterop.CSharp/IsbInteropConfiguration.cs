using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace IsbInterop
{
  /// <summary>
  /// Конфигурация IsbInterop.
  /// </summary>
  public static class IsbInteropConfiguration
  {
    #region Поля и свойства

    /// <summary>
    /// Таймаут выполнения метода IS-Builder, секунд.
    /// </summary>
    public static int IsbMethodExecutionTimeout => _isbMethodExecutionTimeout.Value;

    private static readonly Lazy<int> _isbMethodExecutionTimeout =
      new Lazy<int>(() =>
      {
        const int defaultMethodExecutionTimeout = 60;
        return GetAppSettingOrDefault("IsbMethodExecutionTimeout", defaultMethodExecutionTimeout, t => t > 0);
      }, true);

    /// <summary>
    /// Таймаут создания приложения IS-Builder, секунд.
    /// </summary>
    public static int IsbAppCreationTimeout => _isbAppCreationTimeout.Value;

    private static readonly Lazy<int> _isbAppCreationTimeout =
      new Lazy<int>(() =>
      {
        const int defaultIsbAppCreationTimeout = 300;
        return GetAppSettingOrDefault("IsbAppCreationTimeout", defaultIsbAppCreationTimeout, t => t > 0);
      }, true);

    /// <summary>
    /// Конфигурация сборки IsbInterop.
    /// </summary>
    private static readonly Lazy<Configuration> StandaloneConfiguration =
      new Lazy<Configuration>(TryGetStandaloneConfiguration, true);

    #endregion

    #region Методы

    /// <summary>
    /// Шифрует строки подключения.
    /// </summary>
    public static void EncryptConnectionStrings()
    {
      var configuration = StandaloneConfiguration.Value;
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

    /// <summary>
    /// Получает настройку секции appSettings.
    /// </summary>
    /// <typeparam name="T">Тип результата.</typeparam>
    /// <param name="settingName">Имя настройки/</param>
    /// <param name="result">Результат.</param>
    /// <returns>True, если удалось получить настройку, иначе false.</returns>
    public static bool TryGetAppSetting<T>(string settingName, ref T result)
    {
      if (settingName == null)
        throw new ArgumentNullException(nameof(settingName));

      string settingValue = null;

      var configuration = StandaloneConfiguration.Value;

      if (configuration != null)
      {
        var setting = configuration.AppSettings.Settings[settingName];
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
    /// Получает строку подключения.
    /// </summary>
    /// <returns>Настройки строки подключения.</returns>
    internal static string GetConnectionString()
    {
      ConnectionStringSettings connectionStringSettings;

      var configuration = StandaloneConfiguration.Value;

      if (configuration != null)
        connectionStringSettings = configuration.ConnectionStrings.ConnectionStrings["IsbInterop"];
      else
        connectionStringSettings = ConfigurationManager.ConnectionStrings["IsbInterop"];

      var connectionString = connectionStringSettings?.ConnectionString;

      return connectionString;
    }

    /// <summary>
    /// Получает конфигурацию сборки IsbInterop.
    /// </summary>
    /// <returns>Конфигурация, если она существует, иначе null.</returns>
    private static Configuration TryGetStandaloneConfiguration()
    {
      var currentAssembly = typeof(IsbApplicationManager).Assembly;
      var assemblyPath = new Uri(currentAssembly.CodeBase).LocalPath;
      var assemblyPathWithoutExtenstion = assemblyPath.Substring(0, assemblyPath.Length - 4);
      var configPath = $"{assemblyPathWithoutExtenstion}.dll.config";

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
    /// Конвертирует строку в заданный тип.
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
    /// Получает значение настройки из секции AppSettings.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <param name="setting">Настройка.</param>
    /// <param name="defaultValue">Значение по умолчанию.</param>
    /// <param name="predicate">Предикат.</param>
    /// <returns>Значение настройки.</returns>
    private static T GetAppSettingOrDefault<T>(string setting, T defaultValue, Func<T, bool> predicate = null)
    {
      T value = defaultValue;

      if (TryGetAppSetting(setting, ref value))
      {
        if (predicate != null && predicate(value))
          return value;
      }

      return defaultValue;
    }

    #endregion
  }
}
