using System;

namespace SnelStart.B2B.Client.Operations
{
    /// <summary>
    /// De gegevenscontainer voor een kasboeking.
    /// </summary>
    public class KasboekingModel : IdentifierModel
    {
        /// <summary>
        /// Geeft de naam van deze gegevenscontainer terug.
        /// </summary>
        public const string ResourceName = "kasboekingen";

        /// <summary>
        /// Geeft een instantie van een <see cref="KasboekingModel"/> terug.
        /// </summary>
        public KasboekingModel() : base(ResourceName)
        {
        }

        
        public DateTime ModifiedOn { get; set; }

        
        
        
        public DateTime Datum { get; set; }

        
        public bool Markering { get; set; }

        
        
        public string Boekstuk { get; set; }

        
        public bool GewijzigdDoorAccountant { get; set; }

        
        
        public string Omschrijving { get; set; }

        
        public GrootboekBoekingsRegelModel[] GrootboekBoekingsRegels { get; set; } = new GrootboekBoekingsRegelModel[0];

        
        public InkoopBoekingVerantwoordingsRegelModel[] InkoopboekingBoekingsRegels { get; set; } = new InkoopBoekingVerantwoordingsRegelModel[0];

        
        public VerkoopBoekingVerantwoordingsRegelModel[] VerkoopboekingBoekingsRegels { get; set; } = new VerkoopBoekingVerantwoordingsRegelModel[0];

        
        public BtwBoekingregelModel[] BtwBoekingsregels { get; set; } = new BtwBoekingregelModel[0];

        
        
        public decimal BedragUitgegeven { get; set; }

        
        
        public decimal BedragOntvangen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public DagboekIdentifierModel Dagboek { get; set; }
    }
}