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
    
    public partial class dbRef_Dettaglio
    {
        public int IDContatore { get; set; }
        public string IDPrezzo { get; set; }
        public string Descrizione { get; set; }
        public Nullable<int> RiferimentoPadre { get; set; }
        public Nullable<decimal> Prezzo { get; set; }
        public string NoteTecniche { get; set; }
        public Nullable<int> Famiglia { get; set; }
        public string FormulaExcel { get; set; }
        public string FormulaFast { get; set; }
    }
}