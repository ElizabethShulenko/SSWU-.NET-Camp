namespace Task1.Models.Orders
{
    internal class Order
    {
        public string CompanyName { get; set; }

        public string ProductName { get; set; }

        public double ProductWeight { get; set; }

        public Order() { }

        public Order(string companyName, string productName, double productWeight)
        {
            CompanyName = companyName;
            ProductName = productName;
            ProductWeight = productWeight;
        }

        public override string ToString() => $"Company: {CompanyName}, Product name: {ProductName}, Weight: {ProductWeight}";
    }
}
