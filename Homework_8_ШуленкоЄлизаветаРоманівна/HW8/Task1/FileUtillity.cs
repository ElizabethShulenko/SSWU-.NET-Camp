using System.Text;
using Task1.Models.Orders;
using Task1.Models.Products;

namespace Task1
{
    internal static class FileUtillity
    {
        private static readonly string _inputFolderPath = @"..\..\Input";
        private static readonly string _outputFolderPath = @"..\..\Output";
        private static readonly string _relatedProductsFolderPath = @"..\..\RelatedGoods";

        public static List<Order> GetOrdersFromFile()
        {
            var result = new List<Order>();

            if (!Directory.Exists(_inputFolderPath))
            {
                Directory.CreateDirectory(_inputFolderPath);
            }

            var inputFilePathes = Directory.GetFiles(_inputFolderPath);

            foreach (var filePath in inputFilePathes)
            {
                result.AddRange(GetOrders(filePath));
            }

            return result;
        }

        private static IEnumerable<Order> GetOrders(string filePath)
        {
            var result = new List<Order>();

            var fileData = File.ReadLines(filePath);

            foreach (string line in fileData)
            {
                if (TryParseOrder(line, out Order order))
                {
                    result.Add(order);
                }
            }

            return result;
        }

        public static bool TryParseOrder(string orderString, out Order order)
        {
            order = null;

            var orderData = orderString.Split('|');

            if (orderData.Length != 3)
            {
                return false;
            }

            var companyNameString = orderData[0].Trim();
            var productNameString = orderData[1].Trim();
            var weightString = orderData[2].Trim();

            if (String.IsNullOrEmpty(productNameString) || !Double.TryParse(weightString, out double weight))
            {
                return false;
            }

            order = new Order(companyNameString, productNameString, weight);

            return true;
        }

        public static void FillReportFile(Order order, IEnumerable<Product> suitableProducts)
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

            WriteToReportFile($"{$"Report {order.CompanyName}"}.txt", sb.ToString());
        }

        private static void WriteToReportFile(string fileName, string data)
        {
            if (!Directory.Exists(_outputFolderPath))
            {
                Directory.CreateDirectory(_outputFolderPath);
            }

            File.WriteAllText($"{_outputFolderPath}\\{fileName}", data);
        }

        public static List<List<string>> GetRelatedGoodsFromFile()
        {
            var result = new List<List<string>>();

            if (!Directory.Exists(_relatedProductsFolderPath))
            {
                Directory.CreateDirectory(_relatedProductsFolderPath);
            }

            var filePath = Directory.GetFiles(_relatedProductsFolderPath);

            result = GetRelatedGoods(filePath[0]);            

            return result;
        }

        private static List<List<string>> GetRelatedGoods(string filePath)
        {
            var productNames = new List<List<string>>();

            var fileData = File.ReadLines(filePath);

            foreach (string line in fileData)
            {
                if (TryParseGoods(line, out List<string> goodNames))
                {
                    productNames.Add(goodNames);
                }
            }

            return productNames;
        }

        public static bool TryParseGoods(string orderString, out List<string> productNames)
        {
            productNames = new List<string>();

            var orderData = orderString.Split('|');

            if (orderData.Length == 0)
            {
                return false;
            }

            foreach (var productName in orderData)
            {
                productNames.Add(productName);
            }

            return true;
        }


    }
}