using System.Diagnostics;

namespace DesignPatterns
{
    /* 
     * The following outlines a good example of the S principle in SOLID.
     * The Persistence class performs the tasks that would've added way too many responsibilities
     * to the Journal class.
    */

    public class Journal
    {
        private readonly List<string> entries = new();
        public static int count { get; set; }

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    public class Demo
    {
        public static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\michaelc\source\repos\Udemy_DesignPatternsCSharpDotNet\1_SOLIDDesignPrinciples\Principle_S\journal.txt";
            p.SaveToFile(j, filename, true);
        }
    }
}