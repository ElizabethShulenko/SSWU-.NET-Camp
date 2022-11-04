﻿using System.Collections;

namespace Task1
{
    internal class Meat : Product, IComparable, IComparer
    {
        public Category Category { get; set; }

        public Type Type { get; set; }

        public Meat(Category category, Type type)
        {
            Category = category;
            Type = type;
        }

        public Meat(Category category, Type type, string name, double price, double weight)
        {
            Category = category;
            Type = type;
            Name = name;
            Price = price;
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
            return $"Name: {this.Name}\tPrice: {this.Price}\tWeight: {this.Weight}\tCategory: {this.Category}\tType: {this.Type}";
        }

        public override bool Equals(Object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Meat m = (Meat)obj;
                return (Category == m.Category) && (Type == m.Type);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Category, Type);
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
