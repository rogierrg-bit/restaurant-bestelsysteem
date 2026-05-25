using System;
using System.Collections.Generic;
using System.Text;

namespace VlammendVarken
{
    public class Menukaart
    {
        private List<Gerecht> gerechten = new List<Gerecht>();

        public void VoegToe(Gerecht gerecht)
        {
            gerechten.Add(gerecht);
        }

        public void ToonAlles()
        {
            foreach (Gerecht g in gerechten)
            {
                Console.WriteLine($"{g.Naam} - {g.Prijs:C}");
            }
        }
    }
}
