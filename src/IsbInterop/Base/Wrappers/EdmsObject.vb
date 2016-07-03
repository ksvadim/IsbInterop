Imports IsbInterop.DataTypes.Enumerable

Namespace Base.Wrappers
  ''' <summary>
  ''' Обертка над IEdmsObject.
  ''' </summary>
  Friend MustInherit Class EdmsObject(Of TI As IObjectInfo)
    Inherits IsbObject(Of TI)
    Implements IEdmsObject(Of TI)

    ''' <summary>
    ''' Метод переводит объект в режим редактирования. 
    ''' При этом объект блокируется от изменений другими пользователями. 
    ''' Если объект уже заблокирован, то будет сгенерировано исключение.
    ''' </summary>
    ''' <remarks>Метод является системным, использовать его не рекомендуется. 
    ''' При обращении к объекту метод вызывается автоматически.</remarks>
    Public Sub EnterEditMode() Implements IEdmsObject(Of TI).EnterEditMode
      Me.InvokeRcwInstanceMethod("EnterEditMode")
    End Sub

    ''' <summary>
    ''' Метод переводит объект из режима редактирования в режим просмотра.
    ''' После выполнения метода объект становится доступным для изменения другим пользователям.
    ''' </summary>
    ''' <remarks>Метод является системным, использовать его не рекомендуется. 
    ''' При освобождении объекта метод вызывается автоматически.</remarks>
    Public Sub LeaveEditMode() Implements IEdmsObject(Of TI).LeaveEditMode
      Me.InvokeRcwInstanceMethod("LeaveEditMode")
    End Sub

    ''' <summary>
    ''' Проверить возможность редактирования объекта.
    ''' </summary>
    ''' <param name="editMode">Режим редактирования.</param>
    ''' <param name="errorMessage">системное сообщение об ошибке IS-Builder.</param>
    ''' <returns>True, если редактирование возможно в режиме editMode, иначе false.</returns>
    Public Function TryEdit(editMode As TEditMode, ByRef errorMessage As String) As Boolean Implements IEdmsObject(Of TI).TryEdit
      Dim methodParams As Object() = New Object() {CInt(editMode), Nothing}
      Dim canEdit As Boolean = CBool(Me.InvokeRcwInstanceMethod("TryEdit", methodParams))

      If canEdit Then
        errorMessage = String.Empty
      Else
        errorMessage = DirectCast(methodParams(1), String)
      End If

      Return canEdit
    End Function

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIEdmsObject">COM-объект IEdmsObject.</param>
    Protected Sub New(rcwIEdmsObject As Object)
      MyBase.New(rcwIEdmsObject)
    End Sub
  End Class
End Namespace