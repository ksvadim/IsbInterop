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
          return new Job(rcwObject);
         case (TCompType.ctNotice):
          return new Notice(rcwObject);
         case (TCompType.ctControlJob):
          return new ControlJob(rcwObject);
         default:
           return new DefaultCustomJob(rcwObject);
      }
    }

    /// <summary>
    /// Получить информацию об объекте.
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
          return new JobInfo(rcwObject);
        case (TCompType.ctNotice):
          return new NoticeInfo(rcwObject);
        case (TCompType.ctControlJob):
         return new ControlJobInfo(rcwObject);
        default:
          return new CustomJobInfo(rcwObject);
      }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwITaskFactory">COM-объект ITaskFactory.</param>
    public JobFactory(object rcwITaskFactory) : base(rcwITaskFactory) { }
  }
}
