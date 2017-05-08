namespace IsbInterop.DataTypes.Enumerable
{
  /// <summary>
  /// Режим доступа к объекту.
  /// </summary>
  public enum TEditMode
  {
    /// <summary>
    /// Блокировка на сервере приложений.
    /// </summary>
    emLock = 0,

    /// <summary>
    /// Изменение.
    /// </summary>
    emEdit = 1,

    /// <summary>
    /// Подписание.
    /// </summary>
    emSign = 2,

    /// <summary>
    /// Экспорт с блокировкой.
    /// </summary>
    emExportWithLock = 3,

    /// <summary>
    /// Импорт с разблокировкой.
    /// </summary>
    emImportWithUnlock = 4,

    /// <summary>
    /// Изменение примечания к версии.
    /// </summary>
    emChangeVersionNote = 5,

    /// <summary>
    /// Открытие в приложении-редакторе для изменения.
    /// </summary>
    emOpenForModify = 6,

    /// <summary>
    /// Изменение стадии жизненного цикла.
    /// </summary>
    emChangeLifeStage = 7,

    /// <summary>
    /// Удаление.
    /// </summary>
    emDelete = 8,

    /// <summary>
    /// Создание версии.
    /// </summary>
    emCreateVersion = 9,

    /// <summary>
    /// Импорт.
    /// </summary>
    emImport = 10,

    /// <summary>
    /// ???
    /// </summary>
    emUnlockExportedWithLock = 11,

    /// <summary>
    /// Старт задачи.
    /// </summary>
    emStart = 12,

    /// <summary>
    /// Прекращение задачи.
    /// </summary>
    emAbort = 13,

    /// <summary>
    /// Рестарт задачи.
    /// </summary>
    emReInit = 14,

    /// <summary>
    /// Пометка задания как прочитанного.
    /// </summary>
    emMarkAsReaded = 15,

    /// <summary>
    /// Gометка задания как не прочитанного.
    /// </summary>
    emMarkAsUnreaded = 16,

    /// <summary>
    /// Выполнение задания.
    /// </summary>
    emPerform = 17,

    /// <summary>
    /// Принятие задачи.
    /// </summary>
    emAccept = 18,

    /// <summary>
    /// Отправка задачи на доработку.
    /// </summary>
    emResume = 19,

    /// <summary>
    /// Изменение прав на объект.
    /// </summary>
    emChangeRights = 20,

    /// <summary>
    /// Изменение маршрута задачи.
    /// </summary>
    emEditRoute = 21,

    /// <summary>
    /// Изменение наблюдателей задачи.
    /// </summary>
    emEditObserver = 22,

    /// <summary>
    /// Восстановление документа из локальной копии.
    /// </summary>
    emRecoveryFromLocalCopy = 23,

    /// <summary>
    /// Изменение типа прав на задачу.
    /// </summary>
    emChangeWorkAccessType = 24,

    /// <summary>
    /// Изменение типа шифрования на шифрование сертификатом.
    /// </summary>
    emChangeEncodeTypeToCertificate = 25,

    /// <summary>
    /// Изменение типа шифрования на шифрование паролем.
    /// </summary>
    emChangeEncodeTypeToPassword = 26,

    /// <summary>
    /// Отключение шифрования.
    /// </summary>
    emChangeEncodeTypeToNone = 27,

    /// <summary>
    /// Изменение типа шифрования на шифрование сертификатом и паролем.
    /// </summary>
    emChangeEncodeTypeToCertificatePassword = 28,

    /// <summary>
    /// Изменение типового маршрута задачи.
    /// </summary>
    emChangeStandardRoute = 29,

    /// <summary>
    /// Получение объекта.
    /// </summary>
    emGetText = 30,

    /// <summary>
    /// ???
    /// </summary>
    emOpenForView = 31,

    /// <summary>
    /// Перемещение в другое хранилище.
    /// </summary>
    emMoveToStorage = 32,

    /// <summary>
    /// Создание объекта.
    /// </summary>
    emCreateObject = 33,

    /// <summary>
    /// Изменение признака скрытия версии документа.
    /// </summary>
    emChangeVersionHidden = 34,

    /// <summary>
    /// Удаление версии документа.
    /// </summary>
    emDeleteVersion = 35,

    /// <summary>
    /// Изменение стадии жизненного цикла документа.
    /// </summary>
    emChangeLifeCycleStage = 36,

    /// <summary>
    /// Подписание утверждающей подписью.
    /// </summary>
    emApprovingSign = 37,

    /// <summary>
    /// Экспорт.
    /// </summary>
    emExport = 38,

    /// <summary>
    /// Возобновление задачи.
    /// </summary>
    emContinue = 39,

    /// <summary>
    /// Блокировка документа.
    /// </summary>
    emLockFromEdit = 40,

    /// <summary>
    /// Разблокировка документа.
    /// </summary>
    emUnLockForEdit = 41,

    /// <summary>
    /// Закрепление документа для сервера.
    /// </summary>
    emLockForServer = 42,

    /// <summary>
    /// Снятие закрепления документа для сервера.
    /// </summary>
    emUnlockFromServer = 43,

    /// <summary>
    /// Передача прав доступа на документ.
    /// </summary>
    emDelegateAccessRights = 44,
  }
}
