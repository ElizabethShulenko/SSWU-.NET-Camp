using Task1;
using Task1.Loggers;
using Task1.Models;
using Task1.Models.Products;

class Program
{
    static public void Main(String[] args)
    {
        var logger = new Logger(Console.WriteLine);

        Storage storage = new Storage();

        storage.FillStorage(new List<Product>()
        {
            new Product("Tomato", new Price(){Currency = Currency.Dollar, RegularPrice = 5 }, Measure.Kilogram, 25),
            new Product("Potato", new Price(){Currency = Currency.Hryvnia, RegularPrice = 30 }, Measure.Kilogram, 65),
            new Product("Apple", new Price(){Currency = Currency.Hryvnia, RegularPrice = 45 }, Measure.Kilogram, 50),
            new Product("", new Price(){Currency = Currency.Euro, RegularPrice = 150 }, Measure.Kilogram, 2),
            new Meat(Category.Sort1, Type.Pork, "Meat", new Price(){Currency = Currency.Dollar, RegularPrice = 10 }, Measure.Kilogram, 10),
            new Meat(Category.Extra, Type.Pork, "Meat", new Price(){Currency = Currency.Dollar, RegularPrice = 10 }, Measure.Kilogram, 10),
            new Meat(Category.Extra, Type.Lamb, "Meat", new Price(){Currency = Currency.Hryvnia, RegularPrice = 300 }, Measure.Kilogram, 0.5),
            new DairyProducts("Milk 'Victory'", new Price(){Currency = Currency.Hryvnia, RegularPrice = 100 }, Measure.Liter, 1, new DateTime(2023, 5, 1, 8, 30, 52)),
            new DairyProducts("Heavy cream 'MooCream'", new Price(){Currency = Currency.Dollar, RegularPrice = 6 }, Measure.Liter, 0.3, new DateTime(2023, 2, 20, 21, 30, 52))
        });

        storage.Add(new Product("Tomato", new Price() { Currency = Currency.Dollar, RegularPrice = 5 }, Measure.Kilogram, 15));
        storage.Add(new DairyProducts("Heavy cream 'MooCream'", new Price() { Currency = Currency.Dollar, RegularPrice = 6 }, Measure.Kilogram, 0.3, new DateTime(2023, 2, 20, 21, 30, 52)));

        var relatedGoods = FileUtillity.GetRelatedGoodsFromFile();

        var orders = FileUtillity.GetOrdersFromFile();

        storage.FailedOrderExecute += FileUtillity.FillReportFile;

        storage.ExecuteOrders(orders, relatedGoods);
    }
}