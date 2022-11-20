using Task1.Loggers;

namespace Task1.Models
{
    internal class Shop
    {
        private Logger _logger;
        private Storage Storage { get; set; }
        private Basket Basket { get; set; }

        public Shop(Logger logger)
        {
            _logger = logger;
        }

        public void SetCurrency(Currency currency)
        {
            if (Basket.Products.Count != 0)
            {
                _logger.LogWarning("Currency was already setted");
            }
            else
            {
                Basket.Currency = currency;
                _logger.LogInfo("Currency was setted");
            }

        }

        public void Buy(Product product)
        {
            if (product.Price.Currency == Basket.Currency)
            {
                Basket.Add(product);
            }
        }

        public void DisplayProducts()
        {
            Storage.DisplayProducts();
        }

        public void DisplayWithParticularCurrency(Currency currency)
        {
            Storage.DisplayWithParticularCurrency(currency);
        }

        public void DisplayWithPriceFilter(double lowerPrice, double higherPrice, Currency currency)
        {
            Storage.DisplayWithPriceFilter(lowerPrice, higherPrice, currency);
        }
        public void DisplayWithPriceFilter(double higherPrice, Currency currency, double lowerPrice = 0)
        {
            Storage.DisplayWithPriceFilter(lowerPrice, higherPrice, currency);
        }
        public void DisplayWithPriceFilter(double lowerPrice, Currency currency)
        {
            Storage.DisplayWithPriceFilter(lowerPrice, currency);
        }
    }
}
