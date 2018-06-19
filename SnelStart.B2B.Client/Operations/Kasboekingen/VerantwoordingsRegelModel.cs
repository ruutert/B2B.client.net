using System;

namespace SnelStart.B2B.Client.Operations
{
    public class VerantwoordingsRegelModel
    {
        public string Omschrijving { get; set; }
        
        public decimal Debet { get; set; }
        
        public decimal Credit { get; set; }
    }
}