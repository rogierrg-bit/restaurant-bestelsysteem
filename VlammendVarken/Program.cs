namespace VlammendVarken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gerecht pizza = new Gerecht("Pizza", 7.99m);
            pizza.Bestel();

            Gerecht hamburger = new Gerecht("Hamburger", 6.49m);
            hamburger.Bestel();
        }
    }
}
