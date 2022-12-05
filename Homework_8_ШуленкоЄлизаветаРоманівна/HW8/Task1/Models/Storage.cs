using System.Text;
using Task1.Models.Orders;
using Task1.Models.Products;

namespace Task1.Models
{
    internal class Storage
    {
        public delegate void OrderNotifyHandler(Order order, IEnumerable<Product> suitableProducts);

        public event OrderNotifyHandler? OrderNotifySuccess;
        public event OrderNotifyHandler? OrderNotifyFailed;

        protected Product[] _products;

        public Product[] Products { get { return _products; } }

        public Storage()
        {
            _products = new Product[10];

            OrderNotifySuccess += OrderCompleted;
            OrderNotifyFailed += OrderFailed;
        }

        public Product this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public void Add(Product product)
        {
            //TODO
            if (IsInStorage(product.Name))
            {
                AddExistedProduct(product);
            }
            else
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
        }

        public void FillStorage(List<Product> products)
        {
            products.ForEach(m => Add(m));
        }

        private bool IsInStorage(string productName)
        {
            foreach (var item in Products)
            {
                if (item?.Name == productName)
                {
                    return true;
                }
            }

            return false;
        }

        private void AddExistedProduct(Product product)
        {
            foreach (var item in Products)
            {
                if (item?.GetHashCode() == product.GetHashCode())
                {
                    item.Weight += product.Weight;
                }
            }
        }

        private Product? GetProductByName(string productName)
        {
            return Products.FirstOrDefault(m => m?.Name == productName);
        }

        public void ExecuteOrders(List<Order> orders, List<List<string>> relatedProductGroups)
        {
            orders.ForEach(m => ExecuteOrder(m, relatedProductGroups));
        }

        private void ExecuteOrder(Order order, IEnumerable<IEnumerable<string>> relatedProductGroups)
        {
            var suitableProducts = new List<Product>();

            var product = GetProductByName(order.ProductName);

            if (product != null)
            {
                suitableProducts.Add(product);
            }

            if (product == null || product.Weight < order.ProductWeight)
            {
                var relatedProductNames = relatedProductGroups.SelectMany(m => m.Where(names => names.Contains(order.ProductName)));

                var relatedProducts = FindRelatedProducts(relatedProductNames);
            }

            if (order.ProductWeight > suitableProducts.Sum(m => m.Weight))
            {
                OrderNotifyFailed?.Invoke(order, suitableProducts);
            }
            else
            {
                OrderNotifySuccess?.Invoke(order, suitableProducts);
            }
        }

        private IEnumerable<Product> FindRelatedProducts(IEnumerable<string> relatedProductNames)
        {
            var result = new List<Product>();

            foreach (var productName in relatedProductNames)
            {
                var product = GetProductByName(productName);

                if (product != null)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        private void OrderCompleted(Order order, IEnumerable<Product> suitableProducts)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Order completed!\n");
            sb.AppendLine($"{order}\n");

            sb.AppendLine("Suitable products:");

            foreach (var product in suitableProducts)
            {
                sb.AppendLine(product.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        private void OrderFailed(Order order, IEnumerable<Product> suitableProducts)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Order failed!\n");
            sb.AppendLine($"{order}\n");

            if (suitableProducts.Count() > 0)
            {
                sb.AppendLine("Suitable products:");

                foreach (var product in suitableProducts)
                {
                    sb.AppendLine(product.ToString());
                }
            }
            else
            {
                sb.AppendLine("Product not found!");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
