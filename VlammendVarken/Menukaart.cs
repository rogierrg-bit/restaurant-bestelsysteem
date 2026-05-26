using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
                var details = g.IngredientenRegel();
                if (!string.IsNullOrEmpty(details))
                {
                    Console.WriteLine(details);
                }
            }
        }

        private const string VegLeafSvg = "<svg viewBox=\"0 0 24 24\" width=\"13\" height=\"13\" fill=\"#639922\" style=\"vertical-align: -2px; margin-right: 4px;\"><path d=\"M17 8C8 10 5.9 16.17 3.82 21.34l1.89.66.95-2.3c.48.17.98.3 1.34.3C19 20 22 3 22 3c-1 2-8 2.25-13 3.25S2 11.5 2 13.5s1.75 3.75 1.75 3.75C7 8 17 8 17 8z\"/></svg>";

        private static string LeesLogoAlsDataUri()
        {
            var pad = Path.Combine(AppContext.BaseDirectory, "logo.png");
            if (!File.Exists(pad))
            {
                pad = "logo.png";
                if (!File.Exists(pad)) return string.Empty;
            }
            try
            {
                var bytes = File.ReadAllBytes(pad);
                return "data:image/png;base64," + Convert.ToBase64String(bytes);
            }
            catch
            {
                return string.Empty;
            }
        }

        public void GenereerHTML(string bestandspad)
        {
            var voorgerechten = new List<Voorgerecht>();
            var hoofdgerechten = new List<Hoofdgerecht>();
            var nagerechten = new List<Nagerecht>();
            var alcoholisch = new List<AlcoholischeDrank>();
            var nonAlcoholisch = new List<NonAlcoholischeDrank>();
            var overig = new List<Gerecht>();

            foreach (Gerecht g in gerechten)
            {
                if (g is AlcoholischeDrank ad) alcoholisch.Add(ad);
                else if (g is NonAlcoholischeDrank nad) nonAlcoholisch.Add(nad);
                else if (g is Voorgerecht vg) voorgerechten.Add(vg);
                else if (g is Hoofdgerecht hg) hoofdgerechten.Add(hg);
                else if (g is Nagerecht ng) nagerechten.Add(ng);
                else overig.Add(g);
            }

            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"nl\">");
            sb.AppendLine("<head>");
            sb.AppendLine("  <meta charset=\"UTF-8\">");
            sb.AppendLine("  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.AppendLine("  <title>Menukaart - Vlammend Varken</title>");
            sb.AppendLine("  <link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
            sb.AppendLine("  <link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>");
            sb.AppendLine("  <link href=\"https://fonts.googleapis.com/css2?family=Lora:ital,wght@0,400;0,500;0,600;1,400&family=Playfair+Display:wght@400;500;700&display=swap\" rel=\"stylesheet\">");
            sb.AppendLine("  <style>");
            sb.AppendLine("    html, body { background: #F5F0E8; }");
            sb.AppendLine("    body { font-family: 'Lora', Georgia, serif; font-size: 16px; line-height: 1.6; margin: 0; padding: 2rem 0; color: #3D1F0F; }");
            sb.AppendLine("    main { max-width: 740px; margin: 2rem auto; background: #FFFFFF; border-radius: 18px; padding: 3rem 2.5rem; box-shadow: 0 4px 24px rgba(0,0,0,0.08); }");
            sb.AppendLine("    header { text-align: center; border-bottom: 1px solid #FED7AA; padding-bottom: 1.25rem; margin-bottom: 2.25rem; }");
            sb.AppendLine("    header img.logo { display: block; margin: 0 auto 0.75rem; max-width: 140px; height: auto; }");
            sb.AppendLine("    header h1 { font-family: 'Playfair Display', Georgia, serif; font-size: 36px; font-weight: 700; margin: 0; letter-spacing: 0.18em; color: #B91C1C; text-transform: uppercase; }");
            sb.AppendLine("    header .subtitle { font-family: 'Lora', Georgia, serif; font-style: italic; font-size: 14px; color: #78350F; text-align: center; margin-top: 0.5rem; }");
            sb.AppendLine("    section { margin-bottom: 1.75rem; margin-top: 2.25rem; }");
            sb.AppendLine("    section h2 { font-family: 'Playfair Display', Georgia, serif; font-size: 24px; font-weight: 500; color: #EA580C; text-align: center; margin-top: 2rem; margin-bottom: 1.5rem; padding: 0; border: none; letter-spacing: 0.12em; text-transform: uppercase; }");
            sb.AppendLine("    .item { margin-bottom: 1.25rem; }");
            sb.AppendLine("    .item-header { display: flex; justify-content: space-between; align-items: baseline; }");
            sb.AppendLine("    .item-naam { font-family: 'Lora', Georgia, serif; font-size: 17px; font-weight: 500; color: #3D1F0F; }");
            sb.AppendLine("    .item-prijs { font-family: 'Lora', Georgia, serif; font-size: 17px; font-weight: 500; color: #EA580C; }");
            sb.AppendLine("    .ingredienten { font-family: 'Lora', Georgia, serif; font-style: italic; font-size: 15px; color: #78350F; margin: 0.2rem 0 0.1rem; }");
            sb.AppendLine("    .allergenen { font-family: 'Lora', Georgia, serif; font-size: 12px; color: #A8978A; }");
            sb.AppendLine("    .alcohol { font-family: 'Lora', Georgia, serif; font-size: 13px; color: #B91C1C; font-variant: small-caps; letter-spacing: 0.05em; }");
            sb.AppendLine("    .veg-icon { color: #639922; margin-right: 0.35rem; font-size: 1.05em; }");
            sb.AppendLine("    .dranken-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 2rem; }");
            sb.AppendLine("    .dranken-col-header { font-family: 'Lora', Georgia, serif; font-style: italic; color: #B91C1C; margin-bottom: 0.8rem; font-size: 16px; }");
            sb.AppendLine("    .drank-item { margin-bottom: 1.2rem; }");
            sb.AppendLine("    .drank-naam { font-family: 'Lora', Georgia, serif; font-weight: 500; color: #3D1F0F; font-size: 17px; }");
            sb.AppendLine("    .drank-prijs { font-family: 'Lora', Georgia, serif; font-size: 17px; font-weight: 500; text-align: right; color: #EA580C; margin-top: 0.2rem; }");
            sb.AppendLine("    footer { text-align: center; font-family: 'Lora', Georgia, serif; font-style: italic; font-size: 13px; color: #A8978A; margin-top: 3rem; border-top: 1px solid #FED7AA; padding-top: 1rem; }");
            sb.AppendLine("    @media (max-width: 640px) {");
            sb.AppendLine("      main { padding: 1.5rem 1.25rem; border-radius: 12px; margin: 1rem auto; }");
            sb.AppendLine("      .dranken-grid { grid-template-columns: 1fr !important; gap: 1.5rem; }");
            sb.AppendLine("      h1 { font-size: 28px !important; }");
            sb.AppendLine("    }");
            sb.AppendLine("  </style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("  <main>");
            sb.AppendLine("  <header>");
            var logoDataUri = LeesLogoAlsDataUri();
            if (!string.IsNullOrEmpty(logoDataUri))
            {
                sb.AppendLine($"    <img class=\"logo\" src=\"{logoDataUri}\" alt=\"Vlammend Varken logo\">");
            }
            sb.AppendLine("    <h1>Vlammend Varken</h1>");
            sb.AppendLine("    <p class=\"subtitle\">duurzaam &middot; seizoensgebonden &middot; nose-to-tail</p>");
            sb.AppendLine("  </header>");

            SchrijfSectie(sb, "Voorgerechten", voorgerechten);
            SchrijfSectie(sb, "Hoofdgerechten", hoofdgerechten);
            SchrijfSectie(sb, "Nagerechten", nagerechten);
            SchrijfDrankenSectie(sb, alcoholisch, nonAlcoholisch);
            if (overig.Count > 0)
            {
                SchrijfSectie(sb, "Overig", overig);
            }

            sb.AppendLine("  <footer>Bon appétit &mdash; Vlammend Varken</footer>");
            sb.AppendLine("  </main>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText(bestandspad, sb.ToString(), Encoding.UTF8);
        }

        private static void SchrijfDrankenSectie(StringBuilder sb, List<AlcoholischeDrank> alcoholisch, List<NonAlcoholischeDrank> nonAlcoholisch)
        {
            if (alcoholisch.Count == 0 && nonAlcoholisch.Count == 0) return;

            sb.AppendLine("  <section>");
            sb.AppendLine("    <h2>Dranken</h2>");
            sb.AppendLine("    <div class=\"dranken-grid\">");

            sb.AppendLine("      <div class=\"dranken-col\">");
            sb.AppendLine("        <div class=\"dranken-col-header\">alcoholisch</div>");
            foreach (var d in alcoholisch)
            {
                SchrijfDrankItem(sb, d);
            }
            sb.AppendLine("      </div>");

            sb.AppendLine("      <div class=\"dranken-col\">");
            sb.AppendLine("        <div class=\"dranken-col-header\">non-alcoholisch</div>");
            foreach (var d in nonAlcoholisch)
            {
                SchrijfDrankItem(sb, d);
            }
            sb.AppendLine("      </div>");

            sb.AppendLine("    </div>");
            sb.AppendLine("  </section>");
        }

        private static void SchrijfDrankItem(StringBuilder sb, Drank d)
        {
            sb.AppendLine("        <div class=\"drank-item\">");
            sb.AppendLine($"          <div class=\"drank-naam\">{WebUtility.HtmlEncode(d.Naam)}</div>");

            if (d.Ingredienten != null && d.Ingredienten.Count > 0)
            {
                var ingr = string.Join(", ", d.Ingredienten);
                sb.AppendLine($"          <div class=\"ingredienten\">{WebUtility.HtmlEncode(ingr)}</div>");
            }

            if (d is AlcoholischeDrank ad)
            {
                sb.AppendLine($"          <div class=\"alcohol\">{ad.AlcoholPercentage:0.0}% alcohol</div>");
            }

            sb.AppendLine($"          <div class=\"drank-prijs\">{d.Prijs:C}</div>");

            if (d.Allergenen != null && d.Allergenen.Count > 0)
            {
                var all = string.Join(", ", d.Allergenen);
                sb.AppendLine($"          <div class=\"allergenen\">bevat: {WebUtility.HtmlEncode(all)}</div>");
            }

            sb.AppendLine("        </div>");
        }

        private static void SchrijfSectie<T>(StringBuilder sb, string titel, List<T> items) where T : Gerecht
        {
            if (items.Count == 0) return;

            sb.AppendLine($"  <section>");
            sb.AppendLine($"    <h2>{WebUtility.HtmlEncode(titel)}</h2>");
            foreach (T item in items)
            {
                sb.AppendLine("    <div class=\"item\">");
                sb.AppendLine("      <div class=\"item-header\">");
                var vegPrefix = item.IsVegetarisch ? VegLeafSvg : string.Empty;
                sb.AppendLine($"        <span class=\"item-naam\">{vegPrefix}{WebUtility.HtmlEncode(item.Naam)}</span>");
                sb.AppendLine($"        <span class=\"item-prijs\">{item.Prijs:C}</span>");
                sb.AppendLine("      </div>");

                if (item.Ingredienten != null && item.Ingredienten.Count > 0)
                {
                    var ingr = string.Join(", ", item.Ingredienten);
                    sb.AppendLine($"      <div class=\"ingredienten\">{WebUtility.HtmlEncode(ingr)}</div>");
                }

                if (item is AlcoholischeDrank ad)
                {
                    sb.AppendLine($"      <div class=\"alcohol\">{ad.AlcoholPercentage:0.0}% alcohol</div>");
                }

                if (item.Allergenen != null && item.Allergenen.Count > 0)
                {
                    var all = string.Join(", ", item.Allergenen);
                    sb.AppendLine($"      <div class=\"allergenen\">bevat: {WebUtility.HtmlEncode(all)}</div>");
                }

                sb.AppendLine("    </div>");
            }
            sb.AppendLine("  </section>");
        }
    }
}
