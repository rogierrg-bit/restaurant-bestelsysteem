using System;
using System.Collections.Generic;

namespace VlammendVarken
{
    public class Voorgerecht : Gerecht
    {
        public Voorgerecht(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen, List<string>? ingredienten = null, bool vegetarisch = false)
            : base(naam, prijs, seizoen, allergenen, ingredienten, vegetarisch)
        {
        }
    }
}
