using System;
using System.Collections.Generic;

namespace VlammendVarken
{
    public class NonAlcoholischeDrank : Drank
    {
        public NonAlcoholischeDrank(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen, List<string>? bestanddelen = null, bool vegetarisch = false)
            : base(naam, prijs, seizoen, allergenen, bestanddelen, vegetarisch)
        {
        }
    }
}
