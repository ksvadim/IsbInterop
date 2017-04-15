using IsbInterop.Properties;
using System.Data.SqlClient;

namespace IsbInterop
{
  /// <summary>
  /// Фабрика контекста.
  /// </summary>
  public static class ContextFactory
  {
    #region Константы

    /// <summary>
    /// Формат строки подключения к DIRECTUM.
    /// </summary>
    private const string DirectumConnectionStringFormat = @"ServerName={0};DBName={1};{2}";

    /// <summary>
    /// Часть строки подключения к DIRECTUM при windows-аутентификации.
    /// </summary>
    private const string DirectumOSAuthenticationPartString = "AuthType=OS";

    /// <summary>
    /// Часть строки форматирования для подключения к DIRECTUM при парольной аутентификации.
    /// </summary>
    private const string DirectumPasswordAuthenticationPartStringFormat = @"UserName={0};Password={1}";

    #endregion

    /// <summary>
    /// Создает контекст.
    /// </summary>
    /// <param name="connectionString">Строка подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    /// <returns>Контекст.</returns>
    public static Context CreateContext(string connectionString, bool storeInCache = true)
    {
      var connectionParams = GetConnectionParams(connectionString);
      var rcwApp = IsbApplicationManager.Instance.GetRcwApplication(connectionParams, storeInCache);

      return new Context(rcwApp, connectionParams, storeInCache);
    }

    /// <summary>
    /// Создает контекст.
    /// </summary>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
    /// <returns>Контекст.</returns>
    public static Context CreateContext(bool storeInCache = true)
    {
      var connectionString = ConfigurationUtils.GetConnectionString();
      var connectionParams = GetConnectionParams(connectionString);
      var rcwApp = IsbApplicationManager.Instance.GetRcwApplication(connectionParams, storeInCache);

      return new Context(rcwApp, connectionParams, storeInCache);
    }

    /// <summary>
    /// Получает параметры подключения из строки подключения.
    /// </summary>
    /// <param name="connectionString">Строка подключения.</param>
    /// <returns>Параметры подключения.</returns>
    private static string GetConnectionParams(string connectionString)
    {
      if (connectionString == null)
        throw new FatalIsbInteropException(Resources.UnableToGetDBConnectionParams);

      var builder = new SqlConnectionStringBuilder(connectionString);
      var user = builder.UserID;

      string authenticationPart;

      if (builder.IntegratedSecurity)
        authenticationPart = DirectumOSAuthenticationPartString;
      else
      {
        authenticationPart = string.Format(DirectumPasswordAuthenticationPartStringFormat,
          user, builder.Password);
      }

      var server = builder.DataSource;
      var database = builder.InitialCatalog;

      var isbConnectionParams = string.Format(DirectumConnectionStringFormat, server, database, authenticationPart);
      return isbConnectionParams;
    }
  }
}
