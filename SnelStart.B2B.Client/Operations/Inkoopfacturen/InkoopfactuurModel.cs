using System;

namespace SnelStart.B2B.Client.Operations
{
    /// <summary>
    /// 
    /// </summary>
    public class InkoopfactuurModel : IdentifierModel
    {

        public InkoopfactuurModel(string resource) : base(resource)
        {
        }

        /// <summary>
        /// Geeft de naam van deze gegevenscontainer terug.
        /// </summary>
        public const string ResourceName = "inkoopfacturen";
        /// <summary>
        /// Het tijdstip waarop de inkoopfactuur voor het laatst is gewijzigd.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Het openstaand saldo van de inkoopfactuur.
        /// Deze wordt alleen bij uitlezen gevuld
        /// </summary>
        public decimal OpenstaandSaldo { get; set; }

        /// <summary>
        /// Het factuurnummer.
        /// </summary>
        public string Factuurnummer { get; set; }

        /// <summary>
        /// Het tijdstip waarop de factuur is of zal vervallen
        /// </summary>
        public DateTime? VervalDatum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RelatieIdentifierModel Relatie { get; set; }
        /// <summary>
        /// De datum waarop de factuur is aangemaakt
        /// </summary>
        public DateTime? FactuurDatum { get; set; }
        /// <summary>
        /// Het totaal bedrag van de factuur
        /// </summary>
        public decimal FactuurBedrag { get; set; }
    }
}