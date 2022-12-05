using System.Text;
using Task1.Models.Products;

namespace Task1.Models.Orders
{
    internal class Order
    {
        public string CompanyName { get; set; }

        public IEnumerable<OrderProduct> Products { get; set; }

        public Order()
        {
            Products = new List<OrderProduct>();
        }

        public Order(string companyName, IEnumerable<OrderProduct> products)
        {
            CompanyName = companyName;
            Products = products;
        }

        public Order(string companyName, OrderProduct product)
        {
            CompanyName = companyName;
            Products = new List<OrderProduct> { product };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine("Products in order:");

            foreach (var product in Products)
            {
                sb.AppendLine(product.ToString());
            }

            return sb.ToString();
        }
    }
}
