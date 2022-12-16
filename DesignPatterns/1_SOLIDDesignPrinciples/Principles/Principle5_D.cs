using Section1_SOLIDDesignPrinciples.Principle5_D.BadImplementation;

namespace Section1_SOLIDDesignPrinciples.Principle5_D
{
    /* The following namespace shows the bad implementation */
    namespace BadImplementation
    {
        public enum Relationship
        {
            Parent, Child, Sibling
        }

        public class Person
        {
            public string? Name { get; set; }
        }

        // low-level module
        public class Relationships
        {
            private List<(Person, Relationship, Person)> _relations = new();

            public void AddParentAndChild(Person parent, Person child)
            {
                _relations.Add((parent, Relationship.Parent, child));
                _relations.Add((child, Relationship.Child, child));
            }

            public List<(Person, Relationship, Person)> Relations => _relations;
        }

        // high-level module
        public class Research
        {
            public Research(Relationships relationships)
            {
                var relations = relationships.Relations;
                foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
                {
                    Console.WriteLine($"John has a child called {r.Item3.Name}");
                }
            }

            public static void Execute()
            {
                var parent = new Person() { Name = "John" };
                var child1 = new Person() { Name = "Chris" };
                var child2 = new Person() { Name = "Mary" };

                var relationships = new Relationships();
                relationships.AddParentAndChild(parent, child1);
                relationships.AddParentAndChild(parent, child2);

                new Research(relationships);
            }
        }
    }

    /* The following namespace shows the better implementation */
    namespace GoodImplementation
    {
        public class Person
        {
            public string? Name { get; set; }
        }

        public interface IRelationshipBrowser
        {
            IEnumerable<Person> FindAllChildrenOf(string name);
        }

        // Now, instead of depending on a low-level module (i.e., `Relationships`)
        // we are depending on an abstraction (i.e., `IRelationshipBrowser`)
        public class Relationships : IRelationshipBrowser
        {
            private List<(Person, Relationship, Person)> _relations = new();

            public void AddParentAndChild(Person parent, Person child)
            {
                _relations.Add((parent, Relationship.Parent, child));
                _relations.Add((child, Relationship.Child, child));
            }

            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return (IEnumerable<Person>)_relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent);
            }
        }

        // This dependency on an abstraction instead of a low-level module can be seen here
        // where the our high-level module (i.e., `Research`) takes in the interface instance,
        // `browser`, instead of the `Relationship` instance, `relationships`.
        public class Research
        {
            public Research(IRelationshipBrowser browser)
            {
                foreach (var c in browser.FindAllChildrenOf("John"))
                {
                    Console.WriteLine($"John has a child called {c.Name}");
                }
            }

            public static void Execute()
            {
                var parent = new Person() { Name = "John" };
                var child1 = new Person() { Name = "Chris" };
                var child2 = new Person() { Name = "Mary" };

                var relationships = new Relationships();
                relationships.AddParentAndChild(parent, child1);
                relationships.AddParentAndChild(parent, child2);

                new Research(relationships);
            }
        }
    }
}
