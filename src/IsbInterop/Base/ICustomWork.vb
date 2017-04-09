Imports IsbInterop.Tasks

Namespace Base

  ''' <summary>
  ''' Деловой процесс.
  ''' </summary>
  Public Interface ICustomWork(Of Out TI As IObjectInfo)
    Inherits IEdmsObject(Of TI)

    ''' <summary>
    ''' Получает список вложений.
    ''' </summary>
    ''' <param name="isForFamilyTask">Признак доступности вложений для семейства задач.
    ''' Возможные значения:
    ''' True – если нужно получить вложения, доступные из всех объектов семейства;
    ''' False – если нужно получить вложения, доступные только из текущей задачи или задания.
    ''' </param>
    ''' <returns>Список вложений.</returns>
    Function GetAttachments(isForFamilyTask As Boolean) As IAttachmentList
  End Interface
End Namespace