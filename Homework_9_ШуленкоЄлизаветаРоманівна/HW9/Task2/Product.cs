namespace Task2
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\t Price: {Price}";
        }

        public Product Clone()
        {
            return new Product()
            {
                Name = this.Name,
                Price = this.Price,
            };
        }
    }
}
