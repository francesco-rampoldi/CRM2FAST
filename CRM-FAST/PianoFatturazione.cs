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
    
    public partial class PianoFatturazione
    {
        public int idOfferta { get; set; }
        public string milestone { get; set; }
        public int progressivo { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public Nullable<float> percentuale { get; set; }
        public Nullable<double> valore { get; set; }
        public string termine { get; set; }
        public int idMilestone { get; set; }
    
        public virtual Offerte Offerte { get; set; }
    }
}
