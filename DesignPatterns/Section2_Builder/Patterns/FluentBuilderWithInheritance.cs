using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Builder.Patterns
{
    public class FluentBuilderWithInheritance
    {
        public static void Run()
        {
            var me = Person.New
                .Called("dmitri")
                .WorksAsA("quant")
                .Build();
            Console.WriteLine(me);
        }

        public class Person
        {
            public string Name;
            public string Position;

            public class Builder : PersonJobBuilder<Builder>
            {

            }

            public static Builder New => new Builder();

            public override string ToString()
            {
                return $"{nameof(Name)} {Name}, {nameof(Position)}: {Position}";
            }
        }

        public abstract class PersonBuilder
        {
            protected Person person = new();
            public Person Build()
            {
                return person;
            }
        }

        public class PersonInfoBuilder<SELF> : PersonBuilder 
            where SELF : PersonInfoBuilder<SELF>
        {
            // You can't use the containing type as the return type with inheritance
            public SELF Called(string name)
            {
                person.Name = name;
                return (SELF)this;
            }
        }

        public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
            where SELF : PersonJobBuilder<SELF>
        {
            public SELF WorksAsA(string position)
            {
                person.Position = position;
                return (SELF)this;
            }
        }
    }
}
