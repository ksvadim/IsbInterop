﻿using Autofac;
using Autofac.Core.Registration;
using IsbInterop.Properties;
using System.Linq;
using System.Reflection;

namespace IsbInterop
{
  /// <summary>
  /// Резолвер объектов IS-Builder.
  /// </summary>
  public static class IsbObjectResolver
  {
    private static readonly IContainer Container;

    /// <summary>
    /// Конструктор.
    /// </summary>
    static IsbObjectResolver()
    {
      var builder = new ContainerBuilder();

      builder.RegisterType<BaseIsbObjectImp>()
        .As<IBaseIsbObject>();

      builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        .AssignableTo(typeof(BaseIsbObject))
        .As(t => t.GetInterfaces()
          .Where(i => i.Name.EndsWith(t.Name)))
        .InstancePerDependency();

      Container = builder.Build();
    }

    /// <summary>
    /// Получает экземпляр объекта.
    /// </summary>
    /// <typeparam name="TI">Интерфейс объекта.</typeparam>
    /// <param name="rcwObject">COM-объект.</param>
    /// <param name="scope">Область видимости.</param>
    /// <returns>Объект.</returns>
    //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
    public static TI Resolve<TI>(object rcwObject, IScope scope) where TI : IBaseIsbObject
    {
      TI result;
      try
      {
        result = Container.Resolve<TI>(
          new TypedParameter(typeof(object), rcwObject),
          new TypedParameter(typeof(IScope), scope));
      }
      catch (ComponentNotRegisteredException)
      {
        var error = string.Format(Resources.CannotCastResultToSpecifiedType, typeof(TI).Name);
        throw new IsbInteropException(error);
      }

      return result;
    }
  }
}
