namespace VlammendVarken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");

            Menukaart menukaart = new Menukaart();

            // --- Voorgerechten ---
            Voorgerecht pate = new Voorgerecht(
                "Paté van Varkenslever met Uienconfijt",
                9.50m,
                Seizoen.Winter,
                new List<string> { "gluten" },
                new List<string> { "varkenslever", "rode ui", "tijm", "cognac", "boerenbrood" }
            );

            Voorgerecht bouillon = new Voorgerecht(
                "Heldere Bouillon van Mergpijp",
                7.95m,
                Seizoen.Winter,
                new List<string> { "selderij" },
                new List<string> { "mergpijp", "winterpeen", "knolselderij", "laurier", "peterselie" }
            );

            Voorgerecht bietenCarpaccio = new Voorgerecht(
                "Carpaccio van Bietenrood",
                8.75m,
                Seizoen.Lente,
                new List<string> { "lactose", "noten" },
                new List<string> { "rode biet", "geitenkaas", "walnoot", "honing", "veldsla" },
                vegetarisch: true
            );

            Voorgerecht tartaar = new Voorgerecht(
                "Tartaar van Eigen Slacht",
                11.50m,
                Seizoen.Herfst,
                new List<string> { "ei", "mosterd" },
                new List<string> { "varkenshaas", "kwartelei", "augurk", "kappertjes", "mosterd" }
            );

            Voorgerecht forel = new Voorgerecht(
                "Gerookte Forel uit Eigen Rokerij",
                10.25m,
                Seizoen.Zomer,
                new List<string> { "vis", "lactose" },
                new List<string> { "forel", "mierikswortelcrème", "dille", "citroen", "roggebrood" }
            );

            // --- Hoofdgerechten ---
            Hoofdgerecht varkenshaas = new Hoofdgerecht(
                "Gevulde Varkenshaas",
                22.50m,
                Seizoen.Winter,
                new List<string> { "gluten", "lactose", "selderij" },
                false,
                new List<string> { "varkenshaas", "spek", "champignons", "rode wijn", "tijm" }
            );

            Hoofdgerecht spareribs = new Hoofdgerecht(
                "Spareribs Vlammend",
                19.95m,
                Seizoen.Zomer,
                new List<string> { "gluten", "mosterd" },
                false,
                new List<string> { "spareribs", "appelstroop", "mosterd", "paprika", "knoflook" }
            );

            Hoofdgerecht buikspek = new Hoofdgerecht(
                "Buikspek uit de Oven",
                18.75m,
                Seizoen.Herfst,
                new List<string>(),
                false,
                new List<string> { "buikspek", "appel", "ui", "rozemarijn", "venkelzaad" }
            );

            Hoofdgerecht wildzwijn = new Hoofdgerecht(
                "Wild Zwijn Stoofpot",
                24.50m,
                Seizoen.Herfst,
                new List<string> { "gluten", "selderij" },
                false,
                new List<string> { "wild zwijn", "rode wijn", "jeneverbes", "pastinaak", "ontbijtkoek" }
            );

            Hoofdgerecht mergpijpRisotto = new Hoofdgerecht(
                "Mergpijp Risotto met Knolselderij",
                21.00m,
                Seizoen.Winter,
                new List<string> { "lactose", "selderij" },
                false,
                new List<string> { "arboriorijst", "mergpijp", "knolselderij", "parmezaan", "salie" }
            );

            // --- Nagerechten ---
            Nagerecht stoofpeertjes = new Nagerecht(
                "Stoofpeertjes met Boerentijm",
                7.25m,
                Seizoen.Herfst,
                new List<string>(),
                new List<string> { "stoofpeer", "kaneel", "rode wijn", "tijm", "kruidnagel" },
                vegetarisch: true
            );

            Nagerecht pannaCotta = new Nagerecht(
                "Karnemelk Panna Cotta",
                7.95m,
                Seizoen.Zomer,
                new List<string> { "lactose" },
                new List<string> { "karnemelk", "room", "vanille", "aardbei", "munt" },
                vegetarisch: true
            );

            Nagerecht crumble = new Nagerecht(
                "Appel-Walnoot Crumble",
                7.50m,
                Seizoen.Herfst,
                new List<string> { "gluten", "lactose", "noten" },
                new List<string> { "appel", "walnoot", "havermout", "boter", "kaneel" },
                vegetarisch: true
            );

            Nagerecht vlierSorbet = new Nagerecht(
                "Vlierbessen Sorbet",
                6.75m,
                Seizoen.Zomer,
                new List<string>(),
                new List<string> { "vlierbes", "citroen", "rietsuiker", "munt" },
                vegetarisch: true
            );

            Nagerecht speculaas = new Nagerecht(
                "Speculaas Parfait",
                8.25m,
                Seizoen.Winter,
                new List<string> { "gluten", "lactose", "ei" },
                new List<string> { "speculaas", "room", "eierdooier", "kaneel", "anijs" },
                vegetarisch: true
            );

            // --- Alcoholische dranken ---
            AlcoholischeDrank kruidenbitter = new AlcoholischeDrank(
                "Kruidenbitter Veluws",
                4.50m,
                Seizoen.Winter,
                new List<string>(),
                35.0,
                new List<string> { "alcohol", "wilde tijm", "engelwortel", "duizendblad" },
                vegetarisch: true
            );

            AlcoholischeDrank tripel = new AlcoholischeDrank(
                "Streek Tripel uit Achterhoek",
                5.95m,
                Seizoen.Herfst,
                new List<string> { "gluten" },
                8.5,
                new List<string> { "gerst", "hop", "koriander", "sinaasappelschil" },
                vegetarisch: true
            );

            AlcoholischeDrank pinotNoir = new AlcoholischeDrank(
                "Pinot Noir Achterhoek",
                6.75m,
                Seizoen.Herfst,
                new List<string> { "sulfiet" },
                12.5,
                new List<string> { "pinot noir druif" },
                vegetarisch: true
            );

            AlcoholischeDrank cider = new AlcoholischeDrank(
                "Cider van Schurfappels",
                4.95m,
                Seizoen.Herfst,
                new List<string> { "sulfiet" },
                6.0,
                new List<string> { "schurfappel", "wilde gist" },
                vegetarisch: true
            );

            AlcoholischeDrank korenwijn = new AlcoholischeDrank(
                "Korenwijn Oude Stijl",
                5.50m,
                Seizoen.Winter,
                new List<string> { "gluten" },
                38.0,
                new List<string> { "rogge", "mout", "jeneverbes" },
                vegetarisch: true
            );

            // --- Non-alcoholische dranken ---
            NonAlcoholischeDrank vlierLimonade = new NonAlcoholischeDrank(
                "Vlierbloesem Limonade",
                3.75m,
                Seizoen.Lente,
                new List<string>(),
                new List<string> { "vlierbloesem", "citroen", "honing", "bronwater" },
                vegetarisch: true
            );

            NonAlcoholischeDrank verveine = new NonAlcoholischeDrank(
                "Verveine Kruidenthee",
                3.25m,
                Seizoen.Zomer,
                new List<string>(),
                new List<string> { "citroenverbena", "munt", "kamille" },
                vegetarisch: true
            );

            NonAlcoholischeDrank karnemelk = new NonAlcoholischeDrank(
                "Karnemelk met Boerenhoning",
                3.50m,
                Seizoen.Winter,
                new List<string> { "lactose" },
                new List<string> { "karnemelk", "honing", "kaneel" },
                vegetarisch: true
            );

            NonAlcoholischeDrank appelsap = new NonAlcoholischeDrank(
                "Streekappel Sap, Troebel",
                3.50m,
                Seizoen.Herfst,
                new List<string>(),
                new List<string> { "elstar appel", "goudreinet" },
                vegetarisch: true
            );

            NonAlcoholischeDrank bronwaterMunt = new NonAlcoholischeDrank(
                "Bronwater met Verse Munt",
                2.75m,
                Seizoen.Zomer,
                new List<string>(),
                new List<string> { "bronwater", "munt", "limoen" },
                vegetarisch: true
            );

            // --- Aanpassingen ---
            Aanpassing gaarheid = new Aanpassing(
                "Gaarheid",
                new List<AanpassingOptie>
                {
                    new AanpassingOptie("rare"),
                    new AanpassingOptie("medium"),
                    new AanpassingOptie("well-done")
                });

            Aanpassing saus = new Aanpassing(
                "Saus",
                new List<AanpassingOptie>
                {
                    new AanpassingOptie("jus"),
                    new AanpassingOptie("peperroomsaus", 1.50m),
                    new AanpassingOptie("champignonsaus", 1.25m)
                });

            Aanpassing bijgerecht = new Aanpassing(
                "Bijgerecht",
                new List<AanpassingOptie>
                {
                    new AanpassingOptie("frieten"),
                    new AanpassingOptie("aardappelpuree"),
                    new AanpassingOptie("seizoensgroente"),
                    new AanpassingOptie("salade")
                },
                minKeuzes: 1,
                maxKeuzes: 2);

            varkenshaas.VoegAanpassingToe(gaarheid);
            varkenshaas.VoegAanpassingToe(saus);
            varkenshaas.VoegAanpassingToe(bijgerecht);

            spareribs.VoegAanpassingToe(saus);
            spareribs.VoegAanpassingToe(bijgerecht);

            buikspek.VoegAanpassingToe(saus);
            buikspek.VoegAanpassingToe(bijgerecht);

            // Menukaart vullen
            menukaart.VoegToe(pate);
            menukaart.VoegToe(bouillon);
            menukaart.VoegToe(bietenCarpaccio);
            menukaart.VoegToe(tartaar);
            menukaart.VoegToe(forel);

            menukaart.VoegToe(varkenshaas);
            menukaart.VoegToe(spareribs);
            menukaart.VoegToe(buikspek);
            menukaart.VoegToe(wildzwijn);
            menukaart.VoegToe(mergpijpRisotto);

            menukaart.VoegToe(stoofpeertjes);
            menukaart.VoegToe(pannaCotta);
            menukaart.VoegToe(crumble);
            menukaart.VoegToe(vlierSorbet);
            menukaart.VoegToe(speculaas);

            menukaart.VoegToe(kruidenbitter);
            menukaart.VoegToe(tripel);
            menukaart.VoegToe(pinotNoir);
            menukaart.VoegToe(cider);
            menukaart.VoegToe(korenwijn);

            menukaart.VoegToe(vlierLimonade);
            menukaart.VoegToe(verveine);
            menukaart.VoegToe(karnemelk);
            menukaart.VoegToe(appelsap);
            menukaart.VoegToe(bronwaterMunt);

            Console.WriteLine("=== Menukaart Vlammend Varken ===");
            menukaart.ToonAlles();

            // Filter op huidig seizoen
            Seizoen huidigSeizoen = Seizoen.Herfst;
            Console.WriteLine($"\n=== Beschikbaar in {huidigSeizoen} ===");
            Gerecht[] alle = {
                pate, bouillon, bietenCarpaccio, tartaar, forel,
                varkenshaas, spareribs, buikspek, wildzwijn, mergpijpRisotto,
                stoofpeertjes, pannaCotta, crumble, vlierSorbet, speculaas,
                kruidenbitter, tripel, pinotNoir, cider, korenwijn,
                vlierLimonade, verveine, karnemelk, appelsap, bronwaterMunt
            };
            foreach (Gerecht g in alle)
            {
                if (g.IsBeschikbaarInSeizoen(huidigSeizoen))
                {
                    Console.WriteLine(g);
                }
            }

            // Gast bestelt iets
            Console.WriteLine("\n=== Bestelling ===");
            buikspek.Bestel();

            // Gast bestelt met aanpassingen
            Console.WriteLine("\n=== Bestelling met aanpassingen ===");
            BestelRegel varkenshaasRegel = new BestelRegel(varkenshaas, new[]
            {
                new GekozenAanpassing(gaarheid, gaarheid.Opties[1]),
                new GekozenAanpassing(saus, saus.Opties[1]),
                new GekozenAanpassing(bijgerecht, bijgerecht.Opties[0]),
                new GekozenAanpassing(bijgerecht, bijgerecht.Opties[2])
            });

            BestelRegel spareribsRegel = new BestelRegel(spareribs, new[]
            {
                new GekozenAanpassing(saus, saus.Opties[2]),
                new GekozenAanpassing(bijgerecht, bijgerecht.Opties[0])
            });

            Console.WriteLine(varkenshaasRegel);
            Console.WriteLine(spareribsRegel);
            Console.WriteLine($"Totaal: {varkenshaasRegel.Totaalprijs + spareribsRegel.Totaalprijs:C}");

            // HTML-menukaart genereren
            string htmlPad = "menukaart.html";
            menukaart.GenereerHTML(htmlPad);
            Console.WriteLine($"\nHTML-menukaart weggeschreven naar: {System.IO.Path.GetFullPath(htmlPad)}");
        }
    }
}
