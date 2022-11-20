using Task1.Loggers;
using Task1.Models;

class Program
{
    static public void Main(String[] args)
    {
        var logger = new Logger(Console.WriteLine);

        Storage storage = new Storage();

        var listProducts = new List<Product>()
        {
            new Product("Tomato", new Price(){Currency = Currency.Dollar, RegularPrice = 5 }, Measure.Kilogram, 2),
            new Product("Potato", new Price(){Currency = Currency.Hryvnia, RegularPrice = 30 }, Measure.Kilogram, 7),
            new Product("Apple", new Price(){Currency = Currency.Hryvnia, RegularPrice = 45 }, Measure.Kilogram, 2),
            new Product("", new Price(){Currency = Currency.Euro, RegularPrice = 150 }, Measure.Kilogram, 2),
            new Meat(Category.Sort1, Type.Pork, "Meat", new Price(){Currency = Currency.Dollar, RegularPrice = 10 }, Measure.Kilogram, 1),
            new Meat(Category.Extra, Type.Lamb, "Meat", new Price(){Currency = Currency.Hryvnia, RegularPrice = 300 }, Measure.Kilogram, 0.5),
            new DairyProducts("Milk", new Price(){Currency = Currency.Hryvnia, RegularPrice = 100 }, Measure.Liter, 1, new DateTime(2023, 5, 1, 8, 30, 52)),
            new DairyProducts("Heavy cream", new Price(){Currency = Currency.Dollar, RegularPrice = 6 }, Measure.Kilogram, 0.3, new DateTime(2023, 2, 20, 21, 30, 52))
        };

        Basket b = new Basket(Currency.Dollar, listProducts);

        var currency = storage.GetProductsCurrency();
        storage.FillStorageWithUser();
        storage.FillStorage(listProducts);
        storage.DisplayProducts();

        Basket b2 = new Basket(currency, storage.GetProductByIndex(3), storage.GetProductByIndex(5), storage.GetProductByIndex(1));

        var searchProduct = storage.GetProductByIndex(3);
        var meatList = storage.FindAllMeatProducts();

        var m1 = new Meat(Category.Sort1, Type.Pork, "Meat", new Price() { Currency = Currency.Dollar, RegularPrice = 10 }, Measure.Kilogram, 1);
        var m2 = new Meat(Category.Extra, Type.Lamb, "Meat", new Price() { Currency = Currency.Hryvnia, RegularPrice = 300 }, Measure.Kilogram, 0.5);

        var result = m1.CompareTo(m2);
    }
}