namespace Section1_SOLIDDesignPrinciples.Principle1_S
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
}