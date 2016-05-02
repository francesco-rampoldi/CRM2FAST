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
    
    public partial class Impianti
    {
        public Impianti()
        {
            this.ImpiantiInOfferte = new HashSet<ImpiantiInOfferte>();
            this.QUOTAZIONI = new HashSet<QUOTAZIONI>();
        }
    
        public string EQUIPMENT_NUMBER { get; set; }
        public string NumImpianto { get; set; }
        public string Tipo { get; set; }
        public string PrefissoIndirizzo { get; set; }
        public string Indirizzo { get; set; }
        public string Civico { get; set; }
        public string CAP { get; set; }
        public string Localita { get; set; }
        public string Paese { get; set; }
        public string Provincia { get; set; }
        public Nullable<float> Corsa { get; set; }
        public Nullable<int> Fermate { get; set; }
        public Nullable<int> Portata { get; set; }
        public string Azionamento { get; set; }
        public string Manovra { get; set; }
        public string xmlDetails { get; set; }
        public string IDParty { get; set; }
        public string IDVenditore { get; set; }
        public string Distretto { get; set; }
        public Nullable<System.DateTime> DataRichiestaAllineamento { get; set; }
        public Nullable<System.DateTime> DataAllineamento { get; set; }
        public Nullable<short> AccessiCabina { get; set; }
        public Nullable<double> Velocita { get; set; }
        public string Sollevamento { get; set; }
        public Nullable<int> Molteplicita { get; set; }
        public string TipoPortePiano { get; set; }
        public string Esecuzione { get; set; }
        public string GuideCTP { get; set; }
        public Nullable<System.DateTime> DataCollaudo { get; set; }
        public Nullable<System.DateTime> DataRichiestaCreazioneSAP { get; set; }
        public Nullable<System.DateTime> DataCreazioneSAP { get; set; }
        public string CreatoSAPDa { get; set; }
        public Nullable<System.DateTime> DataLastUpd { get; set; }
    
        public virtual Parties Parties { get; set; }
        public virtual ICollection<ImpiantiInOfferte> ImpiantiInOfferte { get; set; }
        public virtual ICollection<QUOTAZIONI> QUOTAZIONI { get; set; }
    }
}