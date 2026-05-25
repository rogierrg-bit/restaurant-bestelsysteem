using System;
using System.Collections.Generic;

namespace VlammendVarken
{
    public class Hoofdgerecht : Gerecht
    {
        public Hoofdgerecht(string naam, decimal prijs, Seizoen seizoen, List<string> allergenen, bool vegetarisch, List<string>? ingredienten = null)
            : base(naam, prijs, seizoen, allergenen, ingredienten, vegetarisch)
        {
        }
    }
}
