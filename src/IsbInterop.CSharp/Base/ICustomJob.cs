namespace IsbInterop.Base
{
  /// <summary>
  /// Базовое задание.
  /// </summary>
  public interface ICustomJob<out TI> : ICustomWork<TI> where TI : ICustomJobInfo
  {
  }
}
