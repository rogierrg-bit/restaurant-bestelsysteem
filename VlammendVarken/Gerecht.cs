using System;
using System.Collections.Generic;
using System.Text;

namespace VlammendVarken
{
    public class Gerecht
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }

        public Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }

        public void Bestel()
        {
            Console.WriteLine($"Bestelling geplaatst: {Naam} - €{Prijs}");
        }
    }
}