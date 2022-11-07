﻿using System.Collections;

namespace Task1
{
    internal class DairyProducts : Product, IComparer, IComparable
    {        
        public DateTime ExpirationDate { get; }

        public DairyProducts(string name, double price, Measure measure, double weight, DateTime expirationDate)
        {
            Name = name;
            Price = price;
            Measure = measure;
            Weight = weight;
            ExpirationDate = expirationDate;
        }

        public override void ChangePrice(double percent)
        {
            base.ChangePrice(percent);

            if (DateTime.Now.Month - ExpirationDate.Month > 2)
            {
                base.ChangePrice(-30);
            }
            else if (DateTime.Now.Month - ExpirationDate.Month > 6)
            {
                base.ChangePrice(-15);
            }
            else if (DateTime.Now.Month - ExpirationDate.Month > 12)
            {
                base.ChangePrice(-5);
            }
        }

        public override string ToString()
        {
            return $"ExpirationDate: {this.ExpirationDate}";
        }

        public override bool Equals(Object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                DairyProducts dp = (DairyProducts)obj;
                return (ExpirationDate == dp.ExpirationDate);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ExpirationDate);
        }

        public new int CompareTo(object? obj)
        {
            int result = base.CompareTo(obj);

            if (obj is DairyProducts product)
            {
                if (result != 0) return result;

                result = ExpirationDate.CompareTo(product.ExpirationDate);

                return result;
            }

            else throw new ArgumentException("Invalid value");
        }

        public new int Compare(object? x, object? y)
        {
            if (x is DairyProducts xProduct && y is DairyProducts yProduct)
            {
                return xProduct.CompareTo(yProduct);
            }

            else throw new ArgumentException("Invalid value");
        }
    }
}
