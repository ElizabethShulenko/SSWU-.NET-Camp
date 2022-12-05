using System.Collections;

namespace Task1.Models.Products
{
    internal class Meat : Product, IComparable, IComparer
    {
        public Category Category { get; set; }

        public Type Type { get; set; }

        public Meat() { }

        public Meat(Category category, Type type)
        {
            Category = category;
            Type = type;
        }

        public Meat(Category category, Type type, string name, Price price, Measure measure, double weight)
        {
            Category = category;
            Type = type;
            Name = name;
            Price = price;
            Measure = measure;
            Weight = weight;
        }

        public override void ChangePrice(double percent)
        {
            base.ChangePrice(percent);

            switch (Category)
            {
                case Category.Extra:
                    {
                        base.ChangePrice(10);
                        break;
                    }
                case Category.Sort1:
                    {
                        base.ChangePrice(5);
                        break;
                    }
                case Category.Sort2:
                    {
                        base.ChangePrice(3);
                        break;
                    }
                default: break;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\tPrice: {Price}\tWeight: {Weight}\tCategory: {Category}\tType: {Type}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Meat m = (Meat)obj;
                return Category == m.Category && Type == m.Type;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode, Category, Type);
        }

        public new int CompareTo(object? obj)
        {
            if (obj is Meat meat)
            {
                int result = base.CompareTo(obj);

                if (result != 0) return result;

                result = Category.CompareTo(meat.Category);

                if (result != 0) return result;

                result = Type.CompareTo(meat.Type);

                return result;
            }
            else throw new ArgumentException("Invalid value");
        }

        public new int Compare(object? x, object? y)
        {
            if (x is Meat xMeat && y is Meat yMeat)
            {
                return xMeat.CompareTo(yMeat);
            }
            else throw new ArgumentException("Invalid value");
        }

    }
}
