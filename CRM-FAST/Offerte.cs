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
    
    public partial class Offerte
    {
        public Offerte()
        {
            this.ImpiantiInOfferte = new HashSet<ImpiantiInOfferte>();
            this.AUTORIZZAZIONI = new HashSet<AUTORIZZAZIONI>();
            this.OneriOfferte = new HashSet<OneriOfferte>();
            this.PARERI = new HashSet<PARERI>();
            this.PianoFatturazione = new HashSet<PianoFatturazione>();
            this.QUOTAZIONI = new HashSet<QUOTAZIONI>();
        }
    
        public int IDOfferta { get; set; }
        public string NumeroOfferta { get; set; }
        public string PartyID { get; set; }
        public string BillTo_Party { get; set; }
        public string ShipTo_Party { get; set; }
        public string Payer_Party { get; set; }
        public Nullable<System.DateTime> DataCreazione { get; set; }
        public int Validita { get; set; }
        public Nullable<System.DateTime> DataPrevistaChiusura { get; set; }
        public Nullable<decimal> RSPValore { get; set; }
        public Nullable<float> CM2Percento { get; set; }
        public string StatusCorrente { get; set; }
        public string CategoriaPrevalente { get; set; }
        public Nullable<float> ProbabilitaAggiudicazione { get; set; }
        public Nullable<System.DateTime> DataEsitazione { get; set; }
        public string AcquisitaDa { get; set; }
        public Nullable<decimal> ValoreAcquisizione { get; set; }
        public Nullable<float> CM2PercentoAcquisizione { get; set; }
        public string CodiceTerminiFatturazione { get; set; }
        public Nullable<float> PenalePercento { get; set; }
        public Nullable<float> RitenutaGaranziaPercento { get; set; }
        public Nullable<float> FidejussionePercento { get; set; }
        public string AliquotaIva { get; set; }
        public string IDEnte { get; set; }
        public string IDVenditore { get; set; }
        public int progressivo { get; set; }
        public Nullable<int> Revisione { get; set; }
        public string xmlDetails { get; set; }
        public Nullable<System.DateTime> DataRichiestaQuotazione { get; set; }
        public Nullable<System.DateTime> DataQuotazione { get; set; }
        public Nullable<System.DateTime> DataEmissioneOfferta { get; set; }
        public Nullable<System.DateTime> DataEsportazione { get; set; }
        public Nullable<System.DateTime> DataEmissioneCO { get; set; }
        public string NumeroOrdineSAP { get; set; }
        public string ModalitaPagamento { get; set; }
        public Nullable<int> gara { get; set; }
        public Nullable<int> entepubblico { get; set; }
        public string CausaleEmissione { get; set; }
        public string CausaleAnnullamento { get; set; }
        public Nullable<int> listinoCliente { get; set; }
        public string Opportunity { get; set; }
        public Nullable<System.DateTime> DataAggPartyDaOpp { get; set; }
        public string Location_Party { get; set; }
    
        public virtual ICollection<ImpiantiInOfferte> ImpiantiInOfferte { get; set; }
        public virtual ICollection<AUTORIZZAZIONI> AUTORIZZAZIONI { get; set; }
        public virtual Parties Parties { get; set; }
        public virtual ICollection<OneriOfferte> OneriOfferte { get; set; }
        public virtual ICollection<PARERI> PARERI { get; set; }
        public virtual ICollection<PianoFatturazione> PianoFatturazione { get; set; }
        public virtual ICollection<QUOTAZIONI> QUOTAZIONI { get; set; }
    }
}
