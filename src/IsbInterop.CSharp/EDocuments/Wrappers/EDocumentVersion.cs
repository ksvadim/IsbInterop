using IsbInterop.DataTypes.Enumerable;
using System;

namespace IsbInterop.EDocuments.Wrappers
{
  /// <summary>
  /// Обертка над IEDocumentVersion.
  /// </summary>
  internal class EDocumentVersion : IsbComObjectWrapper, IEDocumentVersion
  {
    /// <summary>
    /// Текущее сосотяние версии.
    /// </summary>
    public TEDocumentVersionState CurrentState
    {
      get
      {
        int state = (int)this.GetRcwProperty("CurrentState");

        if (Enum.IsDefined(typeof(TEDocumentVersionState), state))
          return (TEDocumentVersionState)state;
        else
          return TEDocumentVersionState.vsUnknown;
      }
    }

    /// <summary>
    /// Скрытая версия.
    /// </summary>
    public bool IsHidden
    {
      get { return (bool)this.GetRcwProperty("IsHidden"); }
    }

    /// <summary>
    /// Номер версии.
    /// </summary>
    public int Number
    {
      get { return (int)this.GetRcwProperty("Number"); }
    }

    /// <summary>
    /// Размер версии.
    /// </summary>
    public int Size
    {
      get { return (int)this.GetRcwProperty("Size"); }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="version">Версия документа.</param>
    /// <param name="scope">Область видимости.</param>
    public EDocumentVersion(object version, IScope scope) : base(version, scope) { }
  }
}
