//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM_FAST
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceItem
    {
        public int IDPriceItem { get; set; }
        public int IDConfiguratore { get; set; }
        public int IDPriceGroup { get; set; }
        public int IDPrice { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public string Type { get; set; }
        public string Kctref { get; set; }
        public string Tupla { get; set; }
        public string Formula { get; set; }
        public Nullable<int> VersioneTupla { get; set; }
        public string FoglioListino { get; set; }
        public string CellaListino { get; set; }
        public string NomeListino { get; set; }
    }
}
