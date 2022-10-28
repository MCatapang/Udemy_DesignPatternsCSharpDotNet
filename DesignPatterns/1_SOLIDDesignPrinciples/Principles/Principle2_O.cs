namespace Section1_SOLIDDesignPrinciples.Principle2_O
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        public string? Name;
        public Color Color;
        public Size Size;

        public Product(string? name, Color color, Size size)
        {
            if(name == null)
            {
                throw new ArgumentNullException("name");
            }
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(
            IEnumerable<Product> products,
            Size size
        )
        {
            foreach (var p in products)
            {
                if(p.Size == size) yield return p;
            }
        }

        public IEnumerable<Product> FilterByColor(
            IEnumerable<Product> products,
            Color color
        )
        {
            foreach (var p in products)
            {
                if (p.Color == color) yield return p;
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(
            IEnumerable<Product> products,
            Size size,
            Color color
        )
        {
            foreach (var p in products)
            {
                if (p.Size == size && p.Color == color) yield return p;
            }
        }
    }




    // Follows the Open-Closed Principle

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        public Color color;
        public ColorSpecification(Color color)
        {
            this.color = color; 
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class BetterFIlter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i)) yield return i;
            }
        }
    }
}