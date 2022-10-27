using Section1_SOLIDDesignPrinciples.Principle1_S;

namespace Section1_SOLIDDesignPrinciples
{
    class Demo
    {
        public static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\michaelc\source\repos\Udemy_DesignPatternsCSharpDotNet\journal.txt";
            p.SaveToFile(j, filename, true);
        }
    }
}