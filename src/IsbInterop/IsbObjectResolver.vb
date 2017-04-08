Imports System.Reflection
Imports Autofac
Imports Autofac.Core.Registration

''' <summary>
''' Резолвер объектов IS-Builder.
''' </summary>
Public Module IsbObjectResolver
  Private ReadOnly container As IContainer

  ''' <summary>
  ''' Получить экземпляр объекта.
  ''' </summary>
  ''' <typeparam name="TI">Интерфейс объекта.</typeparam>
  ''' <param name="rcwObject">COM-объект.</param>
  ''' <param name="scope">Область видимости.</param>
  ''' <returns>Объект.</returns>
  Public Function Resolve(Of TI As IIsbComObjectWrapper)(rcwObject As Object, scope As IScope) As TI
    Dim result As TI
    Try
      result = container.Resolve(Of TI)(
        New TypedParameter(GetType(Object), rcwObject),
        New TypedParameter(GetType(IScope), scope))
    Catch generatedExceptionName As ComponentNotRegisteredException
      Dim [error] = String.Format(My.Resources.Resources.CannotCastResultToSpecifiedType, GetType(TI).Name)
      Throw New IsbInteropException([error])
    End Try

    Return result
  End Function

  ''' <summary>
  ''' Конструктор.
  ''' </summary>
  Sub New()
    Dim builder = New ContainerBuilder()

    builder.RegisterType(Of BaseIsbObjectWrapper)().[As](Of IIsbComObjectWrapper)()

    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
      AssignableTo(GetType(IsbComObjectWrapper)).
      [As](Function(t) t.GetInterfaces().
      Where(Function(i) i.Name.EndsWith(t.Name))).
      InstancePerDependency()

    container = builder.Build()
  End Sub

End Module
