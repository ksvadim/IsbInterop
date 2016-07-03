namespace IsbInterop.Tests.Integration
{
  /// <summary>
  /// Конфигурация справочников.
  /// </summary>
  public static class ReferenceConfiguration
  {
    /// <summary>
    /// Общие реквизиты.
    /// </summary>
    public static class CommonRequisites
    {
      /// <summary>
      /// Состояние записи.
      /// </summary>
      public const string State = "Состояние";
    }

    /// <summary>
    /// Сценарии.
    /// </summary>
    public static class Scripts
    {
      /// <summary>
      /// Чтение и установка значения константы.
      /// </summary>
      public static class ConstantValue
      {
        public const string ScriptName = "ConstantValue";

        /// <summary>
        /// Параметры.
        /// </summary>
        public static class Params
        {
          /// <summary>
          /// Имя константы.
          /// </summary>
          public const string ConstName = "ConstName";
          
          /// <summary>
          /// Значение константы.
          /// </summary>
          public const string ConstValue = "ConstValue";
        }
      }
    }

    /// <summary>
    /// Типы карточек электронных документов.
    /// </summary>
    public static class DocumentCardTypes
    {
      public static class DefaultRecords
      {
        public static class ArbitraryFormDocuments
        {
          public const string Name = "ПЭА";
        }
      }
    }

    /// <summary>
    /// Виды электронных документов.
    /// </summary>
    public static class DocumentKinds
    {
      public static class DefaultRecords
      {
        public static class OtherDocuments
        {
          public const string Code = "Д000055";
        }
      }
    }

    /// <summary>
    /// Приложения-редакторы.
    /// </summary>
    public static class DocumentEditors
    {
      public static class DefaultRecords
      {
        public static class TextEditor
        {
          public const string Code = "EDOTXT";
        }
      }
    }

    /// <summary>
    /// Страны.
    /// </summary>
    public static class Organizations
    {
      /// <summary>
      /// Имя справочника "Организации".
      /// </summary>
      public const string ReferenceName = "ОРГ";

      /// <summary>
      /// Реквизиты.
      /// </summary>
      public static class Requisites
      {
        /// <summary>
        /// Наименование.
        /// </summary>
        public const string Name = "Наименование";

        /// <summary>
        /// Юридическое наименование организации.
        /// </summary>
        public const string JuridicalName = "Дополнение";

        /// <summary>
        /// ИНН организации.
        /// </summary>
        public const string Inn = "ИНН";

        /// <summary>
        /// КПП организации.
        /// </summary>
        public const string Kpp = "Ед_Изм";

        /// <summary>
        /// Примечание.
        /// </summary>
        public const string Note = "Дополнение3";
      }
    }
  }
}
