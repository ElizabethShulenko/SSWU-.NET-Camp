using System.Text;

namespace Task1.Models
{
    internal class Basket
    {
        public List<Product> Products { get; set; }
        public Currency Currency { get; set; }

        public Basket()
        {
            Products = new List<Product>();
            Currency = Currency.Hryvnia;
        }

        public Basket(Currency currency, params Product[] products)
        {
            Products = new List<Product>();
            Currency = currency;

            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public Basket(Currency currency, List<Product> products)
        {
            Products = products;
            Currency = currency;
        }

        public void Add(Product product)
        {
            Products.Add(product); 
        }

        public double CountTotalPrice()
        {
            return Products.Sum(m => m.Price.RegularPrice);
        }

        public int CountProduct(string productName)
        {
            return Products.Where(m => m.Name.ToLower() == productName.ToLower()).Count();
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            foreach (var product in Products)
            {
                str.Append($"{product.ToString()}\n");
            }

            return str.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Basket b = (Basket)obj;
                return Products == b.Products;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Products);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Basket list)
            {
                return Products.Count.CompareTo(list.Products.Count);
            }

            else throw new ArgumentException("Invalid value");
        }

        public int Compare(object? x, object? y)
        {
            if (x is Basket xBuy && y is Basket yBuy)
            {
                return xBuy.CompareTo(yBuy);
            }

            else throw new ArgumentException("Invalid value");
        }
    }
}
