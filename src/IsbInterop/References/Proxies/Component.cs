using IsbInterop.Base;
using IsbInterop.Base.Proxies;
using IsbInterop.Presentation;
using IsbInterop.Presentation.Proxies;

namespace IsbInterop.References.Proxies
{
  /// <summary>
  /// Обертка над IComponent.
  /// </summary>
  internal class Component : IsbObject<IObjectInfo>, IComponent
  {
    #region Поля и свойства

    /// <summary>
    /// Признак конца набора данных.
    /// </summary>
    public bool EOF => (bool)GetRcwProperty("EOF");

    /// <summary>
    /// Количество записей в наборе данных.
    /// </summary>
    public int RecordCount => (int)GetRcwProperty("RecordCount");

    /// <summary>
    /// Признак открытости записи набора данных.
    /// </summary>
    public bool RecordOpened => (bool)GetRcwProperty("RecordOpened");

    #endregion

    #region Методы

    /// <summary>
    /// Добавляет запись.
    /// </summary>
    public void Append()
    {
      InvokeRcwInstanceMethod("Append");
    }

    /// <summary>
    /// Закрывает набор данных компоненты.
    /// </summary>
    public void Close()
    {
      InvokeRcwInstanceMethod("Close");
    }

    /// <summary>
    /// Закрывает запись.
    /// </summary>
    public void CloseRecord()
    {
      InvokeRcwInstanceMethod("CloseRecord");
    }

    /// <summary>
    /// Получает форму-список.
    /// </summary>
    /// <returns>Форма-список.</returns>
    public IForm GetComponentForm()
    {
      var rcwForm = GetRcwProperty("ComponentForm");
      return new Form(rcwForm, Scope);
    }

    /// <summary>
    /// Получает информацию об объекте.
    /// </summary>
    /// <returns>Информация об объекте.</returns>
    public override IObjectInfo GetInfo()
    {
      var rcwIObjectInfo = GetRcwObjectInfo();
      return new ObjectInfo(rcwIObjectInfo, Scope);
    }

    /// <summary>
    /// Переходит на первую запись набора данных.
    /// </summary>
    public void First()
    {
      InvokeRcwInstanceMethod("First");
    }

    /// <summary>
    /// Переходит на последнюю запись набора данных.
    /// </summary>
    public void Last()
    {
      InvokeRcwInstanceMethod("Last");
    }

    /// <summary>
    /// Переходит на следующую запись набора данных.
    /// </summary>
    public void Next()
    {
      InvokeRcwInstanceMethod("Next");
    }

    /// <summary>
    /// Открывает набор данных компоненты.
    /// </summary>
    public void Open()
    {
      InvokeRcwInstanceMethod("Open");
    }

    /// <summary>
    /// Открывает запись.
    /// </summary>
    public void OpenRecord()
    {
      InvokeRcwInstanceMethod("OpenRecord");
    }

    /// <summary>
    /// Переходит на предыдущую запись набора данных.
    /// </summary>
    public void Prior()
    {
      InvokeRcwInstanceMethod("Prior");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="rcwIComponent">COM-объект IComponent.</param>
    /// <param name="scope">Область видимости.</param>
    public Component(object rcwIComponent, IScope scope) : base(rcwIComponent, scope) { }

    #endregion
  }
}
