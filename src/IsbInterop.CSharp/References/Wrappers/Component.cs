using IsbInterop.Base;
using IsbInterop.Base.Wrappers;
using IsbInterop.Presentation;
using IsbInterop.Presentation.Wrappers;

namespace IsbInterop.References.Wrappers
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
    public bool EOF
    {
      get { return (bool)this.GetRcwProperty("EOF"); }
    }

    /// <summary>
    /// Количество записей в наборе данных.
    /// </summary>
    public int RecordCount
    {
      get { return (int)this.GetRcwProperty("RecordCount"); }
    }

    /// <summary>
    /// Признак открытости записи набора данных.
    /// </summary>
    public bool RecordOpened
    {
      get { return (bool)this.GetRcwProperty("RecordOpened"); }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Добавить запись.
    /// </summary>
    public void Append()
    {
      this.InvokeRcwInstanceMethod("Append");
    }

    /// <summary>
    /// Закрыть набор данных компоненты.
    /// </summary>
    public void Close()
    {
      this.InvokeRcwInstanceMethod("Close");
    }

    /// <summary>
    /// Закрыть запись.
    /// </summary>
    public void CloseRecord()
    {
      this.InvokeRcwInstanceMethod("CloseRecord");
    }

    /// <summary>
    /// Получить форму-список.
    /// </summary>
    /// <returns>Форма-список.</returns>
    public IForm GetComponentForm()
    {
      var rcwForm = this.GetRcwProperty("ComponentForm");
      return new Form(rcwForm, this.Scope);
    }

    /// <summary>
    /// Получить IObjectInfo.
    /// </summary>
    /// <returns>IObjectInfo.</returns>
    public override IObjectInfo GetInfo()
    {
      var rcwIObjectInfo = this.GetRcwObjectInfo();
      return new ObjectInfo(rcwIObjectInfo, this.Scope);
    }

    /// <summary>
    /// Перейти на первую запись набора данных.
    /// </summary>
    public void First()
    {
      this.InvokeRcwInstanceMethod("First");
    }

    /// <summary>
    /// Перейти на последнюю запись набора данных.
    /// </summary>
    public void Last()
    {
      this.InvokeRcwInstanceMethod("Last");
    }

    /// <summary>
    /// Перейти на следующую запись набора данных.
    /// </summary>
    public void Next()
    {
      this.InvokeRcwInstanceMethod("Next");
    }

    /// <summary>
    /// Открыть набор данных компоненты.
    /// </summary>
    public void Open()
    {
      this.InvokeRcwInstanceMethod("Open");
    }

    /// <summary>
    /// Открыть запись.
    /// </summary>
    public void OpenRecord()
    {
      this.InvokeRcwInstanceMethod("OpenRecord");
    }

    /// <summary>
    /// Перейти на предыдущую запись набора данных.
    /// </summary>
    public void Prior()
    {
      this.InvokeRcwInstanceMethod("Prior");
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
