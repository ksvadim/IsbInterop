using IsbInterop.Base;
using IsbInterop.Base.Proxies;
using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Tasks.Proxies
{
  /// <summary>
  /// Обертка над IJobFactory.
  /// </summary>
  internal class JobFactory : EdmsObjectFactory<ICustomJob<ICustomJobInfo>, ICustomJobInfo>, IJobFactory
  {
    /// <summary>
    /// Получает объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override ICustomJob<ICustomJobInfo> GetObjectById(int id)
    {
      TCompType objectType;
      var rcwObject = GetRcwObjectById(id, out objectType);

      switch (objectType)
      {
        case (TCompType.ctJob):
          return new Job(rcwObject, Scope);
        case (TCompType.ctNotice):
          return new Notice(rcwObject, Scope);
        case (TCompType.ctControlJob):
          return new ControlJob(rcwObject, Scope);
        default:
          return new DefaultCustomJob(rcwObject, Scope);
      }
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <param name="id">ИД объекта.</param>
    /// <returns>Info-объект.</returns>
    public override ICustomJobInfo GetObjectInfo(int id)
    {
      TCompType objectType;
      var rcwObject = GetRcwObjectInfo(id, out objectType);

      switch (objectType)
      {
        case (TCompType.ctJob):
          return new JobInfo(rcwObject, Scope);
        case (TCompType.ctNotice):
          return new NoticeInfo(rcwObject, Scope);
        case (TCompType.ctControlJob):
          return new ControlJobInfo(rcwObject, Scope);
        default:
          return new CustomJobInfo(rcwObject, Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    /// <param name="scope">Область видимости.</param>
    public JobFactory(object rcwITaskFactory, IScope scope)
      : base(rcwITaskFactory, scope) { }
  }
}
