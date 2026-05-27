using System;

namespace VlammendVarken
{
    /// <summary>
    /// Eén kiesbare optie binnen een <see cref="Aanpassing"/>, bijvoorbeeld
    /// "medium" voor gaarheid of "extra curry" voor saus.
    /// </summary>
    public class AanpassingOptie
    {
        /// <summary>Weergave-label van de optie, getoond aan de gast.</summary>
        public string Label { get; set; }

        /// <summary>
        /// Eventuele meerprijs van deze optie boven op de prijs van het gerecht.
        /// Standaard 0; bijvoorbeeld 0,50 voor "extra saus".
        /// </summary>
        public decimal PrijsToeslag { get; set; }

        public AanpassingOptie(string label, decimal prijsToeslag = 0m)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentException("Label mag niet leeg zijn.", nameof(label));
            }
            if (prijsToeslag < 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(prijsToeslag), "Toeslag mag niet negatief zijn.");
            }

            Label = label;
            PrijsToeslag = prijsToeslag;
        }

        public override string ToString()
        {
            return PrijsToeslag > 0m ? $"{Label} (+{PrijsToeslag:C})" : Label;
        }
    }
}
