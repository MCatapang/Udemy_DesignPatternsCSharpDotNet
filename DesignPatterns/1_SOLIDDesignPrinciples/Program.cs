using Section1_SOLIDDesignPrinciples.Principle1_S;
using Section1_SOLIDDesignPrinciples.Principle2_O;

namespace Section1_SOLIDDesignPrinciples
{
    class Demo
    {
        public static void Main(string[] args)
        {
            Call_S();
        }

        public static void Call_S()
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\michaelc\source\repos\Udemy_DesignPatternsCSharpDotNet\journal.txt";
            p.SaveToFile(j, filename, true);
        }

        public static void Call_O()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }
        }
    }
}