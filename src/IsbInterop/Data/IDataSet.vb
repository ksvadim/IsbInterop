Imports IsbInterop.DataTypes.Enumerable
Imports IsbInterop.References

Namespace Data

  ''' <summary>
  ''' Набор данных.
  ''' </summary>
  Public Interface IDataSet
    Inherits IQuery
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Имя таблицы детального раздела.
    ''' </summary>
    ReadOnly Property SqlTableName As String

    ''' <summary>
    ''' Состояние.
    ''' </summary>
    ReadOnly Property State As TDataSetState

    ''' <summary>
    ''' Применяет изменения.
    ''' </summary>
    ''' <remarks>
    ''' Метод сохраняет изменения набора данных: записывает все добавления,
    ''' изменения и удаления записей набора данных в базу данных.
    ''' После выполнения метода свойство State принимает значение dssBrowse.
    ''' Следует вызывать метод только для главного раздела набора данных.
    ''' Если вызвать метод для детального раздела, то будет сгенерировано исключение.
    ''' Метод инициирует процесс «Сохранение записи справочника».
    ''' </remarks>
    Sub ApplyUpdates()

    ''' <summary>
    ''' Получает компоненту.
    ''' </summary>
    ''' <returns>Компонента.</returns>
    Function GetComponent() As IComponent

    ''' <summary>
    ''' Получает реквизит.
    ''' </summary>
    ''' <param name="requisiteName">Имя реквизита.</param>
    ''' <returns>Реквизит.</returns>
    Function GetRequisite(requisiteName As String) As IRequisite

    ''' <summary>
    ''' Открывает запись.
    ''' </summary>
    Sub OpenRecord()

    ''' <summary>
    ''' Закрывает запись.
    ''' </summary>
    Sub CloseRecord()

    ''' <summary>
    ''' Добавляет запись.
    ''' </summary>
    Sub Append()

    ''' <summary>
    ''' Обновляет детальный раздел.
    ''' </summary>
    Sub Refresh()
  End Interface
End Namespace