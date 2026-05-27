using System;

namespace VlammendVarken
{
    /// <summary>
    /// Een door de gast gemaakte keuze: koppelt een <see cref="AanpassingOptie"/>
    /// aan zijn <see cref="Aanpassing"/>-definitie. Wordt opgeslagen op een
    /// <see cref="BestelRegel"/>.
    /// </summary>
    public class GekozenAanpassing
    {
        /// <summary>Definitie waar deze keuze bij hoort (bijvoorbeeld "Saus").</summary>
        public Aanpassing Aanpassing { get; init; }

        /// <summary>De gekozen optie binnen de aanpassing (bijvoorbeeld "extra curry").</summary>
        public AanpassingOptie Optie { get; init; }

        /// <summary>Meerprijs van de gekozen optie; doorgereikt vanuit <see cref="AanpassingOptie.PrijsToeslag"/>.</summary>
        public decimal PrijsToeslag => Optie.PrijsToeslag;

        public GekozenAanpassing(Aanpassing aanpassing, AanpassingOptie optie)
        {
            if (aanpassing == null)
            {
                throw new ArgumentNullException(nameof(aanpassing));
            }
            if (optie == null)
            {
                throw new ArgumentNullException(nameof(optie));
            }
            if (!aanpassing.BevatOptie(optie))
            {
                throw new ArgumentException(
                    $"Optie '{optie.Label}' hoort niet bij aanpassing '{aanpassing.Naam}'.",
                    nameof(optie));
            }

            Aanpassing = aanpassing;
            Optie = optie;
        }

        public override string ToString()
        {
            return $"{Aanpassing.Naam}: {Optie}";
        }
    }
}
