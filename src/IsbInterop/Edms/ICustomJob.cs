namespace IsbInterop.Edms
{
  /// <summary>
  /// Базовое задание.
  /// </summary>
  public interface ICustomJob<out TI> : ICustomWork<TI> where TI : ICustomJobInfo
  {
  }
}
