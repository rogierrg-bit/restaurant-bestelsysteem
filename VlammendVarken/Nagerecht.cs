using System;
using System.Collections.Generic;

namespace VlammendVarken
{
    public class Nagerecht : Gerecht
    {
        public Nagerecht(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen, List<string>? ingredienten = null, bool vegetarisch = false)
            : base(naam, prijs, seizoen, allergenen, ingredienten, vegetarisch)
        {
        }
    }
}
