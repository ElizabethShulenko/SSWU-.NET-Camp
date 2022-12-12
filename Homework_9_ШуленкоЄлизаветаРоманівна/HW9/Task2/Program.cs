using Task2;

class Program
{
    public static void Main(String[] args)
    {
        var products = GenerateProductsList(500000);

        var watch = new System.Diagnostics.Stopwatch();

        var unsortedProducts1 = products.Select(a => a.Clone()).ToList();

        watch.Start();
        var sortedProducts1 = QuickSort.QuickSortFirst(unsortedProducts1);
        watch.Stop();

        Console.WriteLine($"Pivot on first element: {watch.ElapsedMilliseconds} ms");

        watch.Restart();

        var unsortedProducts2 = products.Select(a => a.Clone()).ToList();

        watch.Start();
        var sortedProducts2 = QuickSort.QuickSortLast(unsortedProducts2);
        watch.Stop();

        Console.WriteLine($"Pivot on last element: {watch.ElapsedMilliseconds} ms");
        
        watch.Restart();

        var unsortedProducts3 = products.Select(a => a.Clone()).ToList();

        watch.Start();
        var sortedProducts3 = QuickSort.QuickSortRandom(unsortedProducts3);
        watch.Stop();

        Console.WriteLine($"Pivot on random element: {watch.ElapsedMilliseconds} ms");
        
        watch.Restart();
    }

    public static List<Product> GenerateProductsList(int count)
    {
        var result = new List<Product>();
        Random rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            var product = new Product();
            product.Name = "Product" + i;
            product.Price = Math.Round(rnd.NextDouble() * 30, 2);

            result.Add(product);
        }

        return result;
    }
}

