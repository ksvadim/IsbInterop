namespace IsbInterop.Accessory
{
  /// <summary>
  /// Интерфейс ILoginPoint.
  /// </summary>
  public interface ILoginPoint : IIsbComObjectWrapper
  {
    /// <summary>
    /// ИД процесса.
    /// </summary>
    int PID { get; }

    /// <summary>
    /// Получает объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="storeInCache">Признак необходимости добавления информации о соединении в кэш:
    /// True, если нужно добавить информацию, иначе False.</param>
    /// <returns>Объект приложения IApplication, или null.</returns>
    IApplication GetApplication(string connectionParams, bool storeInCache = true);

    /// <summary>
    /// Получает объект приложения.
    /// </summary>
    /// <param name="connectionParams">Параметры подключения.</param>
    /// <param name="errorCode">Код ошибки.</param>
    /// <returns>Объект приложения IApplication, или null.</returns>
    /// <remarks>Данный метод работает не визуально и не отображает никаких диалогов.
    /// Метод не кэширует информацию о соединениях.</remarks>
    IApplication GetApplicationEx(string connectionParams, out int errorCode);
  }
}
