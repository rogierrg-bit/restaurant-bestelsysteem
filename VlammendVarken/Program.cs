namespace VlammendVarken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");

            // Gerechten aanmaken
            Gerecht varkenshaas = new Gerecht(
                "Gevulde Varkenshaas",
                22.50m,
                Seizoen.Winter,
                new List<string> { "gluten", "lactose", "selderij" }
            );

            Gerecht spareribs = new Gerecht(
                "Spareribs Vlammend",
                19.95m,
                Seizoen.Zomer,
                new List<string> { "gluten", "mosterd" }
            );

            Gerecht buikspek = new Gerecht(
                "Buikspek uit de Oven",
                18.75m,
                Seizoen.Herfst,
                new List<string>()
            );

            // Menukaart vullen en tonen
            Menukaart menukaart = new Menukaart();
            menukaart.VoegToe(varkenshaas);
            menukaart.VoegToe(spareribs);
            menukaart.VoegToe(buikspek);

            Console.WriteLine("=== Menukaart Vlammend Varken ===");
            menukaart.ToonAlles();

            // Filter op huidig seizoen
            Seizoen huidigSeizoen = Seizoen.Herfst;
            Console.WriteLine($"\n=== Beschikbaar in {huidigSeizoen} ===");
            foreach (Gerecht g in new[] { varkenshaas, spareribs, buikspek })
            {
                if (g.IsBeschikbaarInSeizoen(huidigSeizoen))
                {
                    Console.WriteLine(g);
                }
            }

            // Gast bestelt iets
            Console.WriteLine("\n=== Bestelling ===");
            buikspek.Bestel();
        }
    }
}
