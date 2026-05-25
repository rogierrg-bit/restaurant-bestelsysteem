using System;
using System.Collections.Generic;
using System.Linq;

namespace VlammendVarken
{
    public enum Seizoen
    {
        Lente,
        Zomer,
        Herfst,
        Winter
    }

    public class Gerecht
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public Seizoen Seizoen { get; set; }
        public List<string> Allergenen { get; set; }

        public Gerecht(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen)
        {
            Naam = naam;
            Prijs = prijs;
            Seizoen = seizoen;
            Allergenen = allergenen ?? new List<string>();
        }

        public Gerecht(string naam, decimal prijs)
            : this(naam, prijs, Seizoen.Lente, new List<string>())
        {
        }

        public bool IsBeschikbaarInSeizoen(Seizoen huidig)
        {
            return Seizoen == huidig;
        }

        public void Bestel()
        {
            Console.WriteLine($"Bestelling geplaatst: {Naam} - {Prijs:C}");
        }

        public override string ToString()
        {
            var allergeenStr = Allergenen.Any() ? string.Join(", ", Allergenen) : "geen";
            return $"{Naam} ({Prijs:C}) - seizoen: {Seizoen} - allergenen: {allergeenStr}";
        }
    }
}
