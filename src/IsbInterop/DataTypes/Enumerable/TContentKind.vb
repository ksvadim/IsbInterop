Namespace DataTypes.Enumerable

    ''' <summary>
    ''' Тип содержимого.
    ''' </summary>
    Public Enum TContentKind
        ''' <summary>
        ''' Папка.
        ''' </summary>
        ckFolder = 0

        ''' <summary>
        ''' Электронный документ.
        ''' </summary>
        ckEDocument = 1

        ''' <summary>
        ''' Задача.
        ''' </summary>
        ckTask = 2

        ''' <summary>
        ''' Задание.
        ''' </summary>
        ckJob = 3

        ''' <summary>
        ''' Вариант запуска компоненты.
        ''' </summary>
        ckComponentToken = 4

        ''' <summary>
        ''' Произвольный объект.
        ''' </summary>
        ckAny = 5

        ''' <summary>
        ''' Справочник.
        ''' </summary>
        ckReference = 6

        ''' <summary>
        ''' Сценарий.
        ''' </summary>
        ckScript = 7

        ''' <summary>
        ''' Отчет.
        ''' </summary>
        ckReport = 8

        ''' <summary>
        ''' Неизвестный тип объекта.
        ''' </summary>
        ckUnknown = -1
    End Enum
End Namespace