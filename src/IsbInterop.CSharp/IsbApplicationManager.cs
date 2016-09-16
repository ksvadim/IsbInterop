using IsbInterop.Accessory;
using IsbInterop.Properties;
using System;
using System.Data.SqlClient;

namespace IsbInterop
{
    /// <summary>
    /// Менеджер приложения IS-Builder.
    /// </summary>
    /// <remarks>Кэширует экземпляр IApplication.</remarks>
    public class IsbApplicationManager
    {
        #region Singleton

        private static readonly Lazy<IsbApplicationManager> instance =
          new Lazy<IsbApplicationManager>(() => new IsbApplicationManager(), true);

        /// <summary>
        /// Экземпляр одиночки.
        /// </summary>
        public static IsbApplicationManager Instance { get { return instance.Value; } }

        /// <summary>
        /// Приватный конструктор.
        /// </summary>
        private IsbApplicationManager() { }

        #endregion

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

        #region Поля и свойства

        /// <summary>
        /// Параметры подключения к DIRECTUM из конфигурации приложения.
        /// </summary>
        private string configConnectionParams;

        /// <summary>
        /// Объект блокировки.
        /// </summary>
        private readonly object lockRoot = new object();

        /// <summary>
        /// Объект приложения.
        /// </summary>
        private IApplication application;

        /// <summary>
        /// Точка подключения.
        /// </summary>
        private ILoginPoint currentLoginPoint;

        /// <summary>
        /// Признак необходимости обновления текущей точки подключения.
        /// </summary>
        private static volatile bool needUpdateCurrentLoginPoint = false;

        #endregion

        #region Методы

        /// <summary>
        /// Получить объект приложения IS-Builder.
        /// </summary>
        /// <param name="connectionParams">Параметры подключения.</param>
        /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
        /// <returns>Объект приложения.</returns>
        /// <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
        public IApplication GetApplication(string connectionParams, bool storeInCache = true)
        {
            if (connectionParams == null)
                throw new ArgumentNullException(nameof(connectionParams));

            if (this.currentLoginPoint != null)
            {
                try
                {
                    int id = this.currentLoginPoint.PID;
                }
                catch (Exception)
                {
                    bool lockedHere = false;
                    lock (lockRoot)
                    {
                        if (!needUpdateCurrentLoginPoint)
                        {
                            needUpdateCurrentLoginPoint = true;
                            lockedHere = true;
                        }
                    }
                    if (lockedHere)
                    {
                        this.currentLoginPoint = LoginPoint.GetLoginPoint();
                        needUpdateCurrentLoginPoint = false;
                        return InternalGetNewIsbApplication(connectionParams, storeInCache, this.currentLoginPoint);
                    }
                }

                return InternalGetNewIsbApplication(connectionParams, storeInCache);
            }
            else
            {
                lock (lockRoot)
                {
                    if (this.currentLoginPoint == null)
                    {
                        this.currentLoginPoint = LoginPoint.GetLoginPoint();
                        return InternalGetNewIsbApplication(connectionParams, storeInCache, this.currentLoginPoint);
                    }
                }
            }

            return InternalGetNewIsbApplication(connectionParams, storeInCache);
        }

        /// <summary>
        /// Получить объект приложения IS-Builder.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <returns>Объект приложения.</returns>
        /// <exception cref="FatalIsbInteropException">Возможное исключение.</exception>
        public IApplication GetApplicationByConnectionString(string connectionString)
        {
            var connectionParams = GetConnectionParams(connectionString);

            return this.GetApplication(connectionParams);
        }

        /// <summary>
        /// Получить объект приложения IS-Builder.
        /// </summary>
        /// <returns>Объект приложения.</returns>
        /// <exception cref="FatalIsbInteropException">Исключение при неудачной попытке получить Application.</exception>
        public IApplication GetApplication()
        {
            if (this.configConnectionParams == null)
            {
                lock (lockRoot)
                {
                    if (this.configConnectionParams == null)
                        this.configConnectionParams = GetConnectionParamsSetting();
                }
            }

            if (this.application == null)
            {
                lock (lockRoot)
                {
                    if (this.application == null)
                        this.application = InternalGetNewIsbApplicationEx(this.configConnectionParams);
                }
            }
            else
            {
                try
                {
                    int id = this.application.PID;
                }
                catch (Exception ex)
                {
                    throw new FatalIsbInteropException(Resources.CannotGetIsbApplication, ex);
                }
            }

            return this.application;
        }

        /// <summary>
        /// Получить новый объект приложения IS-Builder.
        /// </summary>
        /// <param name="currentLoginPoint">Текущая точка подключения.</param>
        /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш.</param>
        /// <param name="connectionParams">Параметры подключения.</param>
        private static IApplication InternalGetNewIsbApplication(string connectionParams, bool storeInCache = true, ILoginPoint currentLoginPoint = null)
        {
            IApplication application;

            try
            {
                if (currentLoginPoint != null)
                    application = currentLoginPoint.GetApplication(connectionParams, storeInCache);
                else
                {
                    using (var newloginPoint = LoginPoint.GetLoginPoint())
                    {
                        application = newloginPoint.GetApplication(connectionParams, storeInCache);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FatalIsbInteropException(Resources.CannotGetIsbApplication, ex);
            }

            return application;
        }

        /// <summary>
        /// Получить новый объект приложения IS-Builder.
        /// </summary>
        /// <param name="connectionParams">Параметры подключения.</param>
        private static IApplication InternalGetNewIsbApplicationEx(string connectionParams)
        {
            int errorCode = 0;
            IApplication application;

            try
            {
                using (var newLoginPoint = LoginPoint.GetLoginPoint())
                {
                    application = newLoginPoint.GetApplicationEx(connectionParams, out errorCode);
                }
            }
            catch (Exception ex)
            {
                throw new FatalIsbInteropException(Resources.CannotGetIsbApplication, ex);
            }

            if (application == null)
            {
                throw new FatalIsbInteropException(string.Format(Resources.CannotGetIsbApplicationTemplate,
                  string.Format(Resources.InternalErrorCodeStringTemplate, errorCode)));
            }

            return application;
        }

        /// <summary>
        /// Получить настройку параметров подключения.
        /// </summary>
        /// <returns>Строка с параметрами подключения.</returns>
        private static string GetConnectionParamsSetting()
        {
            var connectionString = ConfigurationUtils.GetConnectionString();

            return GetConnectionParams(connectionString);
        }

        /// <summary>
        /// Получить параметры подключения из строки подключения.
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

        #endregion
    }
}
