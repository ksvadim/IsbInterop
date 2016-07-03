Imports IsbInterop.Base
Imports IsbInterop.Base.Wrappers
Imports IsbInterop.Presentation
Imports IsbInterop.Presentation.Wrappers

Namespace References.Wrappers
  ''' <summary>
  ''' Обертка над IComponent.
  ''' </summary>
  Friend Class Component
    Inherits IsbObject(Of IObjectInfo)
    Implements IComponent

#Region "Поля и свойства"

    ''' <summary>
    ''' Признак конца набора данных.
    ''' </summary>
    Public ReadOnly Property EOF() As Boolean Implements IComponent.EOF
      Get
        Return CBool(Me.GetRcwProperty("EOF"))
      End Get
    End Property

    ''' <summary>
    ''' Количество записей в наборе данных.
    ''' </summary>
    Public ReadOnly Property RecordCount() As Integer Implements IComponent.RecordCount
      Get
        Return CInt(Me.GetRcwProperty("RecordCount"))
      End Get
    End Property

    ''' <summary>
    ''' Признак открытости записи набора данных.
    ''' </summary>
    Public ReadOnly Property RecordOpened() As Boolean Implements IComponent.RecordOpened
      Get
        Return CBool(Me.GetRcwProperty("RecordOpened"))
      End Get
    End Property

#End Region

#Region "Методы"

    ''' <summary>
    ''' Добавить запись.
    ''' </summary>
    Public Sub Append() Implements IComponent.Append
      Me.InvokeRcwInstanceMethod("Append")
    End Sub

    ''' <summary>
    ''' Закрыть набор данных компоненты.
    ''' </summary>
    Public Sub Close() Implements IComponent.Close
      Me.InvokeRcwInstanceMethod("Close")
    End Sub

    ''' <summary>
    ''' Закрыть запись.
    ''' </summary>
    Public Sub CloseRecord() Implements IComponent.CloseRecord
      Me.InvokeRcwInstanceMethod("CloseRecord")
    End Sub

    ''' <summary>
    ''' Получить форму-список.
    ''' </summary>
    ''' <returns>Форма-список.</returns>
    Public Function GetComponentForm() As IForm Implements IComponent.GetComponentForm
      Dim rcwForm = Me.GetRcwProperty("ComponentForm")
      Return New Form(rcwForm)
    End Function

    ''' <summary>
    ''' Получить IObjectInfo.
    ''' </summary>
    ''' <returns>IObjectInfo.</returns>
    Public Overrides Function GetInfo() As IObjectInfo
      Dim rcwIObjectInfo = Me.GetRcwObjectInfo()
      Return New ObjectInfo(rcwIObjectInfo)
    End Function

    ''' <summary>
    ''' Перейти на первую запись набора данных.
    ''' </summary>
    Public Sub First() Implements IComponent.First
      Me.InvokeRcwInstanceMethod("First")
    End Sub

    ''' <summary>
    ''' Перейти на последнюю запись набора данных.
    ''' </summary>
    Public Sub Last() Implements IComponent.Last
      Me.InvokeRcwInstanceMethod("Last")
    End Sub

    ''' <summary>
    ''' Перейти на следующую запись набора данных.
    ''' </summary>
    Public Sub [Next]() Implements IComponent.Next
      Me.InvokeRcwInstanceMethod("Next")
    End Sub

    ''' <summary>
    ''' Открыть набор данных компоненты.
    ''' </summary>
    Public Sub Open() Implements IComponent.Open
      Me.InvokeRcwInstanceMethod("Open")
    End Sub

    ''' <summary>
    ''' Открыть запись.
    ''' </summary>
    Public Sub OpenRecord() Implements IComponent.OpenRecord
      Me.InvokeRcwInstanceMethod("OpenRecord")
    End Sub

    ''' <summary>
    ''' Перейти на предыдущую запись набора данных.
    ''' </summary>
    Public Sub Prior() Implements IComponent.Prior
      Me.InvokeRcwInstanceMethod("Prior")
    End Sub

#End Region

#Region "Конструкторы"

    ''' <summary>
    ''' Конструктор.
    ''' </summary>
    ''' <param name="rcwIComponent">COM-объект IComponent.</param>
    Public Sub New(rcwIComponent As Object)
      MyBase.New(rcwIComponent)
    End Sub

#End Region

  End Class
End Namespace