using System.Collections;

namespace Task1
{
    internal class Storage : IComparable, IComparer
    {
        protected Product[] _products;

        public Storage()
        {
            _products = new Product[10];
        }

        public Product this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public void Add(Product product)
        {
            var nullIndex = Array.FindIndex(_products, m => m == null);

            if (nullIndex != -1)
            {
                _products[nullIndex] = product;
            }
            else
            {
                Array.Resize(ref _products, _products.Length + _products.Length);
                _products[_products.Length / 2] = product;
            }
        }

        public Product GetProductByIndex(int productIndex)
        {
            return _products.ElementAt(productIndex);
        }

        public void FillStorageWithUser()
        {
            Console.WriteLine("Welcome to storage handler! \n\nWrite 'add' to add product or write 'end' too end");

            var input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                if (input.ToLower() != "add")
                {
                    Console.WriteLine("Wrong input! Please, try again");
                }

                var productName = GetProductName();

                if (productName.ToLower() == "meat")
                {
                    Category meatCategory = GetMeatCategory();
                    Type meatType = GetMeatType();
                    var meatPrice = GetProductPrice();
                    var meatMeasure = GetProductMeasure();
                    var meatWeight = GetProductWeight();

                    Add(new Meat(meatCategory, meatType, "Meat", meatPrice, meatMeasure, meatWeight));
                }
                else
                {
                    var productPrice = GetProductPrice();
                    var ProductMeasure = GetProductMeasure();
                    var productWeight = GetProductWeight();

                    Add(new Product(productName, productPrice, ProductMeasure, productWeight));
                }

                Console.WriteLine("Write 'add' to add product or press any key to end");

                input = Console.ReadLine();
            }
        }

        public void FillStorage(List<Product> products)
        {
            products.ForEach(m => Add(m));
        }

        public Currency GetProductsCurrency()
        {
            Currency? currency = null;

            do
            {
                Console.WriteLine("Product currency: \nDollar -> press 1\tEuro -> press 2\tHryvnia -> press3");

                var inputSort = Console.ReadLine();

                switch (inputSort.Trim())
                {
                    case "1":
                        {
                            currency = Currency.Dollar;
                            break;
                        }
                    case "2":
                        {
                            currency = Currency.Euro;
                            break;
                        }
                    case "3":
                        {
                            currency = Currency.Hryvnia;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input!");
                            break;
                        }
                }

            } while (!currency.HasValue);

            return currency.Value;
        }

        private string GetProductName()
        {
            Console.WriteLine("Product name: ");

            return Console.ReadLine();
        }

        private Measure GetProductMeasure()
        {
            Measure? measure = null;

            do
            {
                Console.WriteLine("Product measure: \nKilogram -> press 1\n Liter -> press 2\nPound -> press3");

                var inputSort = Console.ReadLine();

                switch (inputSort.Trim())
                {
                    case "1":
                        {
                            measure = Measure.Kilogram;
                            break;
                        }
                    case "2":
                        {
                            measure = Measure.Liter;
                            break;
                        }
                    case "3":
                        {
                            measure = Measure.Pound;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input!");
                            break;
                        }
                }

            } while (!measure.HasValue);

            return measure.Value;
        }

        private Category GetMeatCategory()
        {
            Category? category = null;

            do
            {
                Console.WriteLine("Meat category: \nExtra -> press 1\tSort1 -> press 2\tSort2 -> press3");

                var inputSort = Console.ReadLine();

                switch (inputSort.Trim())
                {
                    case "1":
                        {
                            category = Category.Extra;
                            break;
                        }
                    case "2":
                        {
                            category = Category.Sort1;
                            break;
                        }
                    case "3":
                        {
                            category = Category.Sort2;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input!");
                            break;
                        }
                }

            } while (!category.HasValue);

            return category.Value;
        }

        private Type GetMeatType()
        {
            Type? type = null;

            do
            {
                Console.WriteLine("Meat type: \nLamb -> press 1\tVeal -> press 2\tPork -> press 3, Chicken -> press 4");

                var inputSort = Console.ReadLine();

                switch (inputSort.Trim())
                {
                    case "1":
                        {
                            type = Type.Lamb;
                            break;
                        }
                    case "2":
                        {
                            type = Type.Veal;
                            break;
                        }
                    case "3":
                        {
                            type = Type.Pork;
                            break;
                        }
                    case "4":
                        {
                            type = Type.Chicken;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong input!");
                            break;
                        }
                }

            } while (!type.HasValue);

            return type.Value;
        }

        private double GetProductPrice()
        {
            double ptoductPrice = 0;

            do
            {
                Console.WriteLine("Product price: ");

                var inputPrice = Console.ReadLine();

                if (!double.TryParse(inputPrice, out ptoductPrice))
                {
                    Console.WriteLine("Wrong input!");
                }

            } while (ptoductPrice <= 0);

            return ptoductPrice;
        }

        private double GetProductWeight()
        {
            double productWeight = 0;

            do
            {
                Console.WriteLine("Product weight: ");

                var inputPrice = Console.ReadLine();

                if (!double.TryParse(inputPrice, out productWeight))
                {
                    Console.WriteLine("Wrong input!");
                }

            } while (productWeight <= 0);

            return productWeight;
        }

        public void DisplayProducts()
        {
            foreach (var product in _products)
            {
                if (product == null)
                {
                    continue;
                }
                Console.WriteLine(product.ToString());
            }
        }

        public List<Product> FindAllMeatProducts()
        {
            List<Product> meatList = new List<Product>();

            foreach (var product in _products)
            {
                if (product == null)
                {
                    continue;
                }
                if (product is Meat)
                {
                    meatList.Add(product);
                }
            }

            return meatList;
        }

        public void ChangePrice(double percent)
        {
            foreach(var product in _products)
            {
                if (product is Meat)
                {
                    var meatProduct = product as Meat;

                    meatProduct.ChangePrice(percent);
                }
                else if (product is DairyProducts)
                {
                    var dairyProduct = product as DairyProducts;

                    dairyProduct.ChangePrice(percent);
                }
                else
                {
                    product.ChangePrice(percent);
                }
            }
        }

        public void SortProducts()
        {
            Array.Sort(_products);
        }
        public override bool Equals(Object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Storage s = (Storage)obj;
                return (_products == s._products);
            }
        }
        public int CompareTo(object? obj)
        {
            if (obj is Storage storage)
            {
                int result = _products.Length.CompareTo(storage._products.Length);

                if (result != 0) return result;

                return result;
            }
            else throw new ArgumentException("Invalid value");
        }

        public int Compare(object? x, object? y)
        {
            if (x is Storage xStorage && y is Storage yStorage)
            {
                return xStorage.CompareTo(yStorage);
            }
            else throw new ArgumentException("Invalid value");
        }
    }
}
