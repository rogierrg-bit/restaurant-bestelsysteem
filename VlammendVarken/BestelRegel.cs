using System;
using System.Collections.Generic;
using System.Linq;

namespace VlammendVarken
{
    /// <summary>
    /// Eén bestelde gerecht-instantie binnen een bestelling, inclusief de
    /// keuzes die de gast heeft gemaakt voor de <see cref="Aanpassing"/>en
    /// die op het gerecht zijn toegestaan.
    /// </summary>
    public class BestelRegel
    {
        /// <summary>Het bestelde gerecht.</summary>
        public Gerecht Gerecht { get; init; }

        private readonly List<GekozenAanpassing> gekozenAanpassingen;

        /// <summary>De keuzes die de gast bij dit gerecht heeft gemaakt.</summary>
        public IReadOnlyList<GekozenAanpassing> GekozenAanpassingen => gekozenAanpassingen;

        /// <summary>
        /// Totaalprijs van deze regel: basisprijs van het gerecht plus de
        /// toeslagen van alle gekozen opties.
        /// </summary>
        public decimal Totaalprijs => Gerecht.Prijs + gekozenAanpassingen.Sum(k => k.PrijsToeslag);

        /// <summary>
        /// Maakt een bestelregel. Valideert dat de meegegeven keuzes horen
        /// bij aanpassingen van het gerecht en dat per aanpassing het aantal
        /// keuzes binnen <see cref="Aanpassing.MinKeuzes"/> en
        /// <see cref="Aanpassing.MaxKeuzes"/> ligt. Verplichte aanpassingen
        /// moeten ten minste één keuze hebben; dezelfde optie mag niet twee
        /// keer binnen dezelfde aanpassing worden gekozen.
        /// </summary>
        public BestelRegel(Gerecht gerecht, IEnumerable<GekozenAanpassing>? keuzes = null)
        {
            if (gerecht == null)
            {
                throw new ArgumentNullException(nameof(gerecht));
            }

            var keuzesList = keuzes?.ToList() ?? new List<GekozenAanpassing>();

            foreach (var keuze in keuzesList)
            {
                if (keuze == null)
                {
                    throw new ArgumentException("Keuzes mogen geen null bevatten.", nameof(keuzes));
                }
                if (!gerecht.ToegestaneAanpassingen.Contains(keuze.Aanpassing))
                {
                    throw new ArgumentException(
                        $"Aanpassing '{keuze.Aanpassing.Naam}' is niet toegestaan op gerecht '{gerecht.Naam}'.",
                        nameof(keuzes));
                }
            }

            var perAanpassing = keuzesList.GroupBy(k => k.Aanpassing).ToList();

            foreach (var groep in perAanpassing)
            {
                var aanpassing = groep.Key;
                var aantal = groep.Count();

                if (aantal < aanpassing.MinKeuzes)
                {
                    throw new ArgumentException(
                        $"Aanpassing '{aanpassing.Naam}' vereist minimaal {aanpassing.MinKeuzes} keuze(s), maar er zijn er {aantal} gemaakt.",
                        nameof(keuzes));
                }
                if (aantal > aanpassing.MaxKeuzes)
                {
                    throw new ArgumentException(
                        $"Aanpassing '{aanpassing.Naam}' staat maximaal {aanpassing.MaxKeuzes} keuze(s) toe, maar er zijn er {aantal} gemaakt.",
                        nameof(keuzes));
                }

                var uniekeOpties = groep.Select(k => k.Optie).Distinct().Count();
                if (uniekeOpties != aantal)
                {
                    throw new ArgumentException(
                        $"Aanpassing '{aanpassing.Naam}' bevat dezelfde optie meerdere keren.",
                        nameof(keuzes));
                }
            }

            var gemaaktVoor = perAanpassing.Select(g => g.Key).ToHashSet();
            foreach (var verplicht in gerecht.ToegestaneAanpassingen.Where(a => a.IsVerplicht))
            {
                if (!gemaaktVoor.Contains(verplicht))
                {
                    throw new ArgumentException(
                        $"Aanpassing '{verplicht.Naam}' is verplicht maar er is geen keuze gemaakt.",
                        nameof(keuzes));
                }
            }

            Gerecht = gerecht;
            gekozenAanpassingen = keuzesList;
        }

        public override string ToString()
        {
            if (gekozenAanpassingen.Count == 0)
            {
                return $"{Gerecht.Naam} - {Totaalprijs:C}";
            }
            var keuzeStr = string.Join("; ", gekozenAanpassingen);
            return $"{Gerecht.Naam} ({keuzeStr}) - {Totaalprijs:C}";
        }
    }
}
