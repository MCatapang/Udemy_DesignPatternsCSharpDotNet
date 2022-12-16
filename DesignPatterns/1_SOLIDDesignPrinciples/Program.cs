using Section1_SOLIDDesignPrinciples.Principle1_S;
using Section1_SOLIDDesignPrinciples.Principle2_O;
using Section1_SOLIDDesignPrinciples.Principle3_L;

namespace Section1_SOLIDDesignPrinciples
{
    class Demo
    {
        public static void Main(string[] args)
        {
            Call_D();
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

        public static void Call_L()
        {
            static int Area(Rectangle r) => r.Width * r.Height;

            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area of {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area of {Area(sq)}");
        }

        public static void Call_I()
        {
            // Not needed
        }

        public static void Call_D()
        {
            Principle5_D.BadImplementation.Research.Execute();
            Principle5_D.GoodImplementation.Research.Execute();
        }
    }
}