﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplicationNAV.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.6.1.37:7047/DynamicsNAV90/WS/CRONUS%20Italia%20S.p.A./Page/SalesOrder")]
        public string ConsoleApplicationNAV_NAVWS_SalesOrder_Service {
            get {
                return ((string)(this["ConsoleApplicationNAV_NAVWS_SalesOrder_Service"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.6.1.37:7047/DynamicsNAV90/WS/CRONUS%20Italia%20S.p.A./Page/SalesOrder")]
        public string NAVWSURL {
            get {
                return ((string)(this["NAVWSURL"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://192.6.1.37:7047/DynamicsNAV90/WS/CRONUS%20Italia%20S.p.A./Page/SalesOrderL" +
            "Ines")]
        public string ConsoleApplicationNAV_NAVWS_SalesLines_SalesOrderLInes_Service {
            get {
                return ((string)(this["ConsoleApplicationNAV_NAVWS_SalesLines_SalesOrderLInes_Service"]));
            }
        }
    }
}