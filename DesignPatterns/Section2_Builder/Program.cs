using Section2_Builder.Patterns;

namespace Section2_Builder
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            Builder.Run();
            FluentBuilder.Run();
            FluentBuilderWithInheritance.Run();
        }
    }
}