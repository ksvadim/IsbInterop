Imports IsbInterop.Base
Imports IsbInterop.Presentation

Namespace References
  ''' <summary>
  ''' Компонента.
  ''' </summary>
  Public Interface IComponent
    Inherits IObject(Of IObjectInfo)

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    ReadOnly Property EOF As Boolean

    ''' <summary>
    ''' Количество записей в наборе данных.
    ''' </summary>
    ReadOnly Property RecordCount As Integer

    ''' <summary>
    ''' Признак открытости записи набора данных.
    ''' </summary>
    ''' <remarks>
    ''' Свойство устанавливается в True после выполнения метода OpenRecord, в False – после выполнения метода CloseRecord.
    ''' </remarks>
    ReadOnly Property RecordOpened As Boolean

    ''' <summary>
    ''' Добавляет запись.
    ''' </summary>
    Sub Append()

    ''' <summary>
    ''' Закрывает набор данных компоненты.
    ''' </summary>
    Sub Close()

    ''' <summary>
    ''' Закрывает запись.
    ''' </summary>
    Sub CloseRecord()

    ''' <summary>
    ''' Получает форму-список.
    ''' </summary>
    ''' <returns>Форма-список.</returns>
    Function  GetComponentForm() As IForm

    ''' <summary>
    ''' Переходит на первую запись набора данных.
    ''' </summary>
    Sub First()

    ''' <summary>
    ''' Переходит на последнюю запись набора данных.
    ''' </summary>
    Sub Last()

    ''' <summary>
    ''' Переходит на следующую запись набора данных.
    ''' </summary>
    Sub [Next]()

    ''' <summary>
    ''' Открывает набор данных компоненты.
    ''' </summary>
    Sub Open()

    ''' <summary>
    ''' Открывает запись.
    ''' </summary>
    Sub OpenRecord()

    ''' <summary>
    ''' Переходит на предыдущую запись набора данных.
    ''' </summary>
    Sub Prior()
  End Interface
End NameSpace