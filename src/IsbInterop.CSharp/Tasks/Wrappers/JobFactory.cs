using IsbInterop.Base;
using IsbInterop.Base.Wrappers;
using IsbInterop.DataTypes.Enumerable;

namespace IsbInterop.Tasks.Wrappers
{
  /// <summary>
  /// Обертка над IJobFactory.
  /// </summary>
  internal class JobFactory : EdmsObjectFactory<ICustomJob<ICustomJobInfo>, ICustomJobInfo>, IJobFactory
  {
    /// <summary>
    /// Получить объект по его ИД.
    /// </summary>
    /// <param name="id">ИД.</param>
    /// <returns>Объект.</returns>
    public override ICustomJob<ICustomJobInfo> GetObjectById(int id)
    {
      TCompType objectType;
      var rcwObject = this.GetRcwObjectById(id, out objectType);

      switch (objectType)
      {
        case (TCompType.ctJob):
          return new Job(rcwObject, this.Scope);
        case (TCompType.ctNotice):
          return new Notice(rcwObject, this.Scope);
        case (TCompType.ctControlJob):
          return new ControlJob(rcwObject, this.Scope);
        default:
          return new DefaultCustomJob(rcwObject, this.Scope);
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
      var rcwObject = this.GetRcwObjectInfo(id, out objectType);

      switch (objectType)
      {
        case (TCompType.ctJob):
          return new JobInfo(rcwObject, this.Scope);
        case (TCompType.ctNotice):
          return new NoticeInfo(rcwObject, this.Scope);
        case (TCompType.ctControlJob):
          return new ControlJobInfo(rcwObject, this.Scope);
        default:
          return new CustomJobInfo(rcwObject, this.Scope);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    /// <param name="scope">Область видимости.</param>
    public JobFactory(object rcwITaskFactory, IScope scope) : base(rcwITaskFactory, scope) { }
  }
}
