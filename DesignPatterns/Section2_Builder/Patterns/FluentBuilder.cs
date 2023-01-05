using System.Text;

namespace Section2_Builder.Patterns
{
    public class FluentBuilder
    {
        public static void Run()
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            sb.Clear();

            var words = new[] { "hello", "world" };
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>");
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            var builder = new HtmlBuilder("ul");
            // Chained methods are possible with the Fluent Builder pattern
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }

        private class HtmlElement
        {
            public string Name, Text;
            public List<HtmlElement> Elements = new();
            private const int indentSize = 2;

            public HtmlElement() { }

            public HtmlElement(string name, string text)
            {
                Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
                Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
            }

            private string ToStringImpl(int indent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', indentSize * indent);

                sb.AppendLine($"{i}<{Name}>");

                if (!string.IsNullOrWhiteSpace(Text))
                {
                    sb.Append(new string(' ', indentSize * (indent + 1)));
                    sb.AppendLine(Text);
                }

                foreach (var e in Elements)
                {
                    sb.Append(e.ToStringImpl(indent + 1));
                }

                sb.AppendLine($"{i}</{Name}>");
                return sb.ToString();
            }

            public override string ToString()
            {
                return ToStringImpl(0);
            }
        }

        private class HtmlBuilder
        {
            private readonly string rootName;
            HtmlElement root = new HtmlElement();

            public HtmlBuilder(string rootName)
            {
                this.rootName = rootName;
                root.Name = rootName;
            }

            // The current instance is being returned in a Fluent Builder pattern
            public HtmlBuilder AddChild(string childName, string childText)
            {
                var e = new HtmlElement(childName, childText);
                root.Elements.Add(e);
                return this;
            }

            public override string ToString()
            {
                return root.ToString();
            }

            public void Clear()
            {
                root = new HtmlElement() { Name = rootName };
            }
        }
    }
}
