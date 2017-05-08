using IsbInterop.Accessory.Proxies;

namespace IsbInterop.Data.Proxies
{
  /// <summary>
  /// Обертка над IPickRequisiteItems.
  /// </summary>
  internal class PickRequisiteItems : ForEach<IPickRequisiteItem>, IPickRequisiteItems
  {
    /// <summary>
    /// Получить ИД по значению.
    /// </summary>
    /// <param name="namedValue">Допустимое значение реквизита.</param>
    /// <returns>ИД допустимого значения реквизита типа «Признак» –
    /// внутреннее значение реквизита, хранящееся на сервере.</returns>
    public string IdByValue(string namedValue)
    {
      return (string)InvokeRcwInstanceMethod("IdByValue", namedValue);
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIPickRequisiteItems">COM-объект IPickRequisiteItems.</param>
    /// <param name="scope">Область видимости.</param>
    internal PickRequisiteItems(object rcwIPickRequisiteItems, IScope scope)
      : base(rcwIPickRequisiteItems, scope) { }
  }
}
