using System.Collections;

namespace Task1.Models
{
    internal class Product : IComparer, IComparable
    {
        public string? Name { get; set; }
        public Price Price { get; set; }
        public double Weight { get; set; }
        public Measure Measure { get; set; }

        public Product() : this(string.Empty, default, default, default) { }

        public Product(string name, Price price, Measure measure, double weigth)
        {
            Name = name;
            Price = price;
            Measure = measure;
            Weight = weigth;
        }

        public virtual void ChangePrice(double percent)
        {
            Price.RegularPrice += Price.RegularPrice * percent / 100;
        }

        public override string ToString()
        {
            return $"Name: {Name}\tPrice: {Price.RegularPrice}\tCurrency: {Price.Currency}\tWeight: {Weight} {Measure}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product p = (Product)obj;
                return Name == p.Name && Price.RegularPrice == p.Price.RegularPrice && Weight == p.Weight;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price.RegularPrice, Weight);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Product product)
            {
                int result = Name.CompareTo(product.Name);

                if (result != 0) return result;

                result = Price.RegularPrice.CompareTo(product.Price.RegularPrice);

                if (result != 0) return result;

                result = Weight.CompareTo(product.Weight);

                return result;
            }
            else throw new ArgumentException("Invalid value");
        }

        public int Compare(object? x, object? y)
        {
            if (x is Product xProduct && y is Product yProduct)
            {
                return xProduct.CompareTo(yProduct);
            }
            else throw new ArgumentException("Invalid value");
        }
    }
}
