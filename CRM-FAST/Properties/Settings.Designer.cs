﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.34209
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM_FAST.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Lo@3Mkl0")]
        public string SFDC_API_WS_Pwd {
            get {
                return ((string)(this["SFDC_API_WS_Pwd"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("francesco.rampoldi@topgraf.it")]
        public string fatalfailuresRpt_Email {
            get {
                return ((string)(this["fatalfailuresRpt_Email"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("test.CRM2FASTinterface@kone.com")]
        public string sender_email {
            get {
                return ((string)(this["sender_email"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CRM2FASTinterface - TEST ")]
        public string sender_name {
            get {
                return ((string)(this["sender_name"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10.32.32.32")]
        public string smtp_server {
            get {
                return ((string)(this["smtp_server"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2014-01-01")]
        public global::System.DateTime Opp_clean_import_start_date {
            get {
                return ((global::System.DateTime)(this["Opp_clean_import_start_date"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://test.salesforce.com/services/Soap/c/30.0/00Dm000000028uq")]
        public string CRM_FAST_API_SforceService {
            get {
                return ((string)(this["CRM_FAST_API_SforceService"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("fast.interface@kone.com.full")]
        public string SFDC_API_WS_Login {
            get {
                return ((string)(this["SFDC_API_WS_Login"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"SELECT id, name, OwnerId, Owner.EmployeeNumber ,Owner.FirstName , Owner.LastName, Owner.Email ,Owner.Alias, Owner.Sales_Office__c, Owner.UserName, Owner.Branch_Office__c, Owner.Camos_User__c, Business_Type__c, Opportunity_Category__c, Site_Country__c, KONE_Opportunity_Number__c, StageName, description, IsWon, IsClosed, Sales_Organization__c, Amount, CloseDate, Probability, Site_Street_Address__c, Site_City__c, Site_State_Province__c, Account.Fax, Account.Phone, AccountId, Account.Name, Account.NameLocal , Account.AccountNumber, Account.BillingCity, Account.BillingStreet, Account.BillingPostalCode, Account.BillingState, Account.BillingCountry, Account.Kone_Country__c, Account.Kone_City__c,  LastModifiedDate, (SELECT Partner__r.Fax, Partner__r.Phone, Partner__r.Name, Partner__r.NameLocal , Partner__r.AccountNumber, Partner__r.BillingCity, Partner__r.BillingStreet, Partner__r.BillingPostalCode, Partner__r.BillingState, Partner__r.BillingCountry, Partner__r.Kone_Country__c, Partner__r.Kone_City__c  FROM Partners__r WHERE Partner_role__c in ('Sold-to Party'))  FROM Opportunity  WHERE LastModifiedDate > {0} AND LastModifiedDate < {1} AND Site_Country__c = 'Italy'  ORDER BY LastModifiedDate ASC")]
        public string Opp_getOpportunities_select_query {
            get {
                return ((string)(this["Opp_getOpportunities_select_query"]));
            }
        }
    }
}