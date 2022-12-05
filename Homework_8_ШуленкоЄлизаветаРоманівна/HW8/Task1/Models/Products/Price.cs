namespace Task1.Models.Products
{
    internal class Price
    {
        private double _regularPrice;

        public Currency Currency { get; set; }

        public double RegularPrice
        {
            get
            {
                return _regularPrice;
            }
            set
            {
                if (value > 0)
                    _regularPrice = value;
            }
        }

        public Price() { }
    }
}
