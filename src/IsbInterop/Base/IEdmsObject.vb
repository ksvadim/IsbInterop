Imports System.Runtime.InteropServices
Imports IsbInterop.DataTypes.Enumerable

Namespace Base

  ''' <summary>
  ''' Базовый объект ЭДО.
  ''' </summary>
  Public Interface IEdmsObject(Of Out TI As IObjectInfo)
    Inherits IObject(Of TI)

    ''' <summary>
    ''' Переводит объект в режим редактирования.
    ''' При этом объект блокируется от изменений другими пользователями.
    ''' Если объект уже заблокирован, то будет сгенерировано исключение.
    ''' </summary>
    ''' <remarks>
    ''' Метод является системным, использовать его не рекомендуется.
    ''' При обращении к объекту метод вызывается автоматически.
    ''' </remarks>
    Sub EnterEditMode()

    ''' <summary>
    ''' Переводит объект из режима редактирования в режим просмотра.
    ''' После выполнения метода объект становится доступным для изменения другим пользователям.
    ''' </summary>
    ''' <remarks>
    ''' Метод является системным, использовать его не рекомендуется.
    ''' При освобождении объекта метод вызывается автоматически.
    ''' </remarks>
    Sub LeaveEditMode()

    ''' <summary>
    ''' Проверяет возможность редактирования документа.
    ''' </summary>
    ''' <param name="editMode">Режим редактирования.</param>
    ''' <param name="errorMessage">Сообщение об ошибке</param>
    ''' <returns>True, если редактирование возможно, иначе false.</returns>
    Function TryEdit(editMode As TEditMode, <Out()> ByRef errorMessage As String) As Boolean
  End Interface
End Namespace