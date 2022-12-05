namespace Task1.Models.Orders
{
    internal class OrderProduct
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public OrderProduct() { }

        public OrderProduct(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString() => $"Name: {Name}, Weight: {Weight}";
    }
}
