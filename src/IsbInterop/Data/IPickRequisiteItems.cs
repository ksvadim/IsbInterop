using IsbInterop.Accessory;

namespace IsbInterop.Data
{
  /// <summary>
  /// Список описаний допустимых значений реквизита типа «Признак».
  /// </summary>
  public interface IPickRequisiteItems : IForEach<IPickRequisiteItem>
  {
    /// <summary>
    /// Получить ИД по значению.
    /// </summary>
    /// <param name="namedValue">Допустимое значение реквизита.</param>
    /// <returns>ИД допустимого значения реквизита типа «Признак» –
    /// внутреннее значение реквизита, хранящееся на сервере.</returns>
    string IdByValue(string namedValue);
  }
}
