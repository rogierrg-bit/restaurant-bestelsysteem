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
        public List<string> Ingredienten { get; set; }
        public bool IsVegetarisch { get; set; }

        private readonly List<Aanpassing> toegestaneAanpassingen = new List<Aanpassing>();

        /// <summary>
        /// Aanpassingen die de gast bij dit gerecht mag kiezen, bijvoorbeeld
        /// "Saus" of "Gaarheid". Alleen muteerbaar via <see cref="VoegAanpassingToe"/>.
        /// </summary>
        public IReadOnlyList<Aanpassing> ToegestaneAanpassingen => toegestaneAanpassingen;

        public Gerecht(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen, List<string>? ingredienten = null, bool vegetarisch = false)
        {
            Naam = naam;
            Prijs = prijs;
            Seizoen = seizoen;
            Allergenen = allergenen ?? new List<string>();
            Ingredienten = ingredienten ?? new List<string>();
            IsVegetarisch = vegetarisch;
        }

        public Gerecht(string naam, decimal prijs)
            : this(naam, prijs, Seizoen.Lente, new List<string>(), new List<string>(), false)
        {
        }

        public bool IsBeschikbaarInSeizoen(Seizoen huidig)
        {
            return Seizoen == huidig;
        }

        /// <summary>
        /// Koppelt een <see cref="Aanpassing"/> aan dit gerecht. Dezelfde
        /// aanpassing mag niet twee keer worden toegevoegd; vergelijking
        /// gebeurt op referentie.
        /// </summary>
        public void VoegAanpassingToe(Aanpassing aanpassing)
        {
            if (aanpassing == null)
            {
                throw new ArgumentNullException(nameof(aanpassing));
            }
            if (toegestaneAanpassingen.Contains(aanpassing))
            {
                throw new ArgumentException(
                    $"Aanpassing '{aanpassing.Naam}' is al gekoppeld aan gerecht '{Naam}'.",
                    nameof(aanpassing));
            }

            toegestaneAanpassingen.Add(aanpassing);
        }

        public void Bestel()
        {
            Console.WriteLine($"Bestelling geplaatst: {Naam} - {Prijs:C}");
        }

        public virtual string IngredientenRegel()
        {
            if (Ingredienten == null || !Ingredienten.Any())
            {
                return string.Empty;
            }
            return $"   met {string.Join(", ", Ingredienten)}";
        }

        public override string ToString()
        {
            var allergeenStr = Allergenen.Any() ? string.Join(", ", Allergenen) : "geen";
            return $"{Naam} ({Prijs:C}) - seizoen: {Seizoen} - allergenen: {allergeenStr}";
        }
    }
}
