using System;
using System.Collections.Generic;

namespace VlammendVarken
{
    /// <summary>
    /// Definitie van een keuze die de gast kan maken bij een gerecht, bijvoorbeeld
    /// "Saus" of "Gaarheid". Eén Aanpassing kan worden hergebruikt op meerdere
    /// gerechten via <see cref="Gerecht.ToegestaneAanpassingen"/>.
    /// </summary>
    public class Aanpassing
    {
        /// <summary>Weergavenaam van de keuze, bijvoorbeeld "Gaarheid".</summary>
        public string Naam { get; set; }

        /// <summary>
        /// Minimaal aantal opties dat de gast moet kiezen. 0 betekent optioneel.
        /// Standaard 1.
        /// </summary>
        public int MinKeuzes { get; set; }

        /// <summary>
        /// Maximaal aantal opties dat de gast mag kiezen. Standaard 1.
        /// </summary>
        public int MaxKeuzes { get; set; }

        /// <summary>De beschikbare opties waaruit gekozen kan worden.</summary>
        public List<AanpassingOptie> Opties { get; set; }

        /// <summary>Geeft aan of de gast minstens één optie moet kiezen.</summary>
        public bool IsVerplicht => MinKeuzes >= 1;

        public Aanpassing(string naam, List<AanpassingOptie> opties, int minKeuzes = 1, int maxKeuzes = 1)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new ArgumentException("Naam mag niet leeg zijn.", nameof(naam));
            }
            if (opties == null || opties.Count == 0)
            {
                throw new ArgumentException("Een aanpassing moet ten minste één optie hebben.", nameof(opties));
            }
            if (minKeuzes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minKeuzes), "MinKeuzes mag niet negatief zijn.");
            }
            if (maxKeuzes < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxKeuzes), "MaxKeuzes moet minstens 1 zijn.");
            }
            if (maxKeuzes < minKeuzes)
            {
                throw new ArgumentException("MaxKeuzes mag niet kleiner zijn dan MinKeuzes.", nameof(maxKeuzes));
            }
            if (maxKeuzes > opties.Count)
            {
                throw new ArgumentException("MaxKeuzes mag niet groter zijn dan het aantal beschikbare opties.", nameof(maxKeuzes));
            }

            Naam = naam;
            Opties = opties;
            MinKeuzes = minKeuzes;
            MaxKeuzes = maxKeuzes;
        }

        /// <summary>
        /// Geeft true wanneer de opgegeven optie behoort tot deze aanpassing.
        /// Vergelijking gebeurt op referentie.
        /// </summary>
        public bool BevatOptie(AanpassingOptie optie)
        {
            return optie != null && Opties.Contains(optie);
        }

        public override string ToString()
        {
            var bereik = MinKeuzes == MaxKeuzes ? $"{MinKeuzes}" : $"{MinKeuzes}-{MaxKeuzes}";
            return $"{Naam} (kies {bereik} uit {Opties.Count})";
        }
    }
}
