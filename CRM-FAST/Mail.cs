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
    
    public partial class Mail
    {
        public int idMail { get; set; }
        public int idOfferta { get; set; }
        public string tipoMail { get; set; }
        public string inviataA { get; set; }
        public Nullable<System.DateTime> dataInvio { get; set; }
        public string inviataDa { get; set; }
        public string mailTo { get; set; }
        public string mailCC { get; set; }
        public string mailBCC { get; set; }
        public string mailSubject { get; set; }
        public string mailBody { get; set; }
        public Nullable<System.DateTime> ricevutaIl { get; set; }
        public string note { get; set; }
        public Nullable<int> revisione { get; set; }
        public string kaiUtente { get; set; }
    }
}
