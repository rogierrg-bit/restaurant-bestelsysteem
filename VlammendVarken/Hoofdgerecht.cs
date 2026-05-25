using System;
using System.Collections.Generic;
using System.Text;

namespace VlammendVarken
{
    public class Hoofdgerecht : Gerecht
    {
        public bool IsVegetarisch { get; set; }

        public Hoofdgerecht(string naam, decimal prijs, bool vegetarisch)
            : base(naam, prijs)
        {
            IsVegetarisch = vegetarisch;
        }
    }
}