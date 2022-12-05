using System.Text;
using Task1.Models.Orders;

namespace Task1
{
    internal static class FileUtillity
    {
        private static readonly string _inputFolderPath = @"..\..\Input";
        private static readonly string _outputFolderPath = @"..\..\Output";
        private static readonly string _goodsFolderPath = @"..\..\RelatedGoods";

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
            var orders = new List<Order>();

            var fileData = File.ReadLines(filePath);

            foreach (string line in fileData)
            {
                if (TryParseOrder(line, out Order order))
                {
                    orders.Add(order);
                }
            }

            var groupedOrders = orders.GroupBy(m => m.CompanyName);

            var result = groupedOrders.Select(m => new Order(m.Key, m.SelectMany(o => o.Products)));

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

            order = new Order(companyNameString, new OrderProduct(productNameString, weight));

            return true;
        }

        public static void FillReportFile(Order order, string? fileName = null)
        {
            var report = GetOrderReport(order);

            WriteToReportFile($"{fileName ?? $"Report {order.CompanyName}"}.txt", report);
        }

        private static void WriteToReportFile(string fileName, string data)
        {
            if (!Directory.Exists(_outputFolderPath))
            {
                Directory.CreateDirectory(_outputFolderPath);
            }

            File.WriteAllText($"{_outputFolderPath}\\{fileName}", data);
        }

        public static string GetOrderReport(Order order)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Order info: ");
            sb.AppendLine(order.ToString());

            return sb.ToString();
        }

        public static List<List<string>> GetRelatedGoodsFromFile()
        {
            var result = new List<List<string>>();

            if (!Directory.Exists(_goodsFolderPath))
            {
                Directory.CreateDirectory(_goodsFolderPath);
            }

            var filePath = Directory.GetFiles(_goodsFolderPath);

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