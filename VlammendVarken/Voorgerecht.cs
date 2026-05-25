using System;
using System.Collections.Generic;
using System.Text;

namespace VlammendVarken
{
    public class Voorgerecht : Gerecht
    {
        Voorgerecht(string naam, decimal prijs)
            : base(naam, prijs) { }
    }
}
