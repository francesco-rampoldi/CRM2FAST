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
    
    public partial class CFG_Fermate
    {
        public int id { get; set; }
        public string codice { get; set; }
        public string descrizione { get; set; }
        public Nullable<int> ordinamento { get; set; }
        public Nullable<bool> abilitato { get; set; }
        public Nullable<bool> visibile { get; set; }
        public Nullable<bool> isDefault { get; set; }
    }
}
