﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsbInterop.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IsbInterop.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;Не удалось преобразовать результат к типу {0}.&quot;.
        /// </summary>
        internal static string CannotCastResultToSpecifiedType {
            get {
                return ResourceManager.GetString("CannotCastResultToSpecifiedType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось выполнить метод {0} объекта {1}..
        /// </summary>
        internal static string CannotExecuteObjectMethodTemplate {
            get {
                return ResourceManager.GetString("CannotExecuteObjectMethodTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка получения объекта приложения IS-Builder..
        /// </summary>
        internal static string CannotGetIsbApplication {
            get {
                return ResourceManager.GetString("CannotGetIsbApplication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка получения объекта приложения. {0}.
        /// </summary>
        internal static string CannotGetIsbApplicationTemplate {
            get {
                return ResourceManager.GetString("CannotGetIsbApplicationTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось получить свойство {0} объекта {1}..
        /// </summary>
        internal static string CannotGetObjectProperyTemplate {
            get {
                return ResourceManager.GetString("CannotGetObjectProperyTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось установить свойство {0} объекта {1}..
        /// </summary>
        internal static string CannotSetObjectProperyTemplate {
            get {
                return ResourceManager.GetString("CannotSetObjectProperyTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Внутренний код ошибки: {0}..
        /// </summary>
        internal static string InternalErrorCodeStringTemplate {
            get {
                return ResourceManager.GetString("InternalErrorCodeStringTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка удаления установленного ранее ограничения &apos;AddWhere&apos; для набора записей детального раздела справочника..
        /// </summary>
        internal static string UnableToDeleteDetailDataSetQueryConstraint {
            get {
                return ResourceManager.GetString("UnableToDeleteDetailDataSetQueryConstraint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось получить параметры подключения к базе данных..
        /// </summary>
        internal static string UnableToGetDBConnectionParams {
            get {
                return ResourceManager.GetString("UnableToGetDBConnectionParams", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось получить объект SBLogon.LoginPoint..
        /// </summary>
        internal static string UnableToGetLoginPoint {
            get {
                return ResourceManager.GetString("UnableToGetLoginPoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не удалось получить объект {0}..
        /// </summary>
        internal static string UnableToGetObject {
            get {
                return ResourceManager.GetString("UnableToGetObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ошибка получения sql-значения поля реквизита из именованного значения.
        ///Реквизит: {0}. Именованное значение: {1}.&quot;.
        /// </summary>
        internal static string UnableToGetRequisiteSqlFieldValueTemplate {
            get {
                return ResourceManager.GetString("UnableToGetRequisiteSqlFieldValueTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Возникло исключение при попытке ограничить набор записей детального раздела компоненты {0}. Текст запроса AddWhere:
        ///&apos;{1}&apos;..
        /// </summary>
        internal static string UnableToSpecifyDataSetQueryTemplate {
            get {
                return ResourceManager.GetString("UnableToSpecifyDataSetQueryTemplate", resourceCulture);
            }
        }
    }
}
