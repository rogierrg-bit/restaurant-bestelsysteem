using System;
using System.Collections.Generic;

namespace VlammendVarken
{
    public class AlcoholischeDrank : Drank
    {
        public double AlcoholPercentage { get; set; }

        public AlcoholischeDrank(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen, double alcoholPercentage, List<string>? bestanddelen = null, bool vegetarisch = false)
            : base(naam, prijs, seizoen, allergenen, bestanddelen, vegetarisch)
        {
            AlcoholPercentage = alcoholPercentage;
        }

        public override string IngredientenRegel()
        {
            var basis = base.IngredientenRegel();
            var alc = $"   {AlcoholPercentage:0.0}% alcohol";
            if (string.IsNullOrEmpty(basis))
            {
                return alc;
            }
            return $"{basis}{Environment.NewLine}{alc}";
        }
    }
}
