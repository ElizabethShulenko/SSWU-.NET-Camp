namespace Task2
{
    internal static class QuickSort
    {
        public static IEnumerable<Product> QuickSortFirst(this IList<Product> list)
        {
            if (!list.Any())
            {
                return new List<Product>();
            }

            var pivot = list.First();
            list.Remove(pivot);

            var smaller = list.Where(item => item.Price <= pivot.Price).ToList().QuickSortFirst();
            var larger = list.Where(item => item.Price > pivot.Price).ToList().QuickSortFirst();

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }

        public static IEnumerable<Product> QuickSortLast(this IList<Product> list)
        {
            if (!list.Any())
            {
                return new List<Product>();
            }

            var pivot = list.Last();
            list.Remove(pivot);

            var smaller = list.Where(item => item.Price <= pivot.Price).ToList().QuickSortLast();
            var larger = list.Where(item => item.Price > pivot.Price).ToList().QuickSortLast();

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }

        public static IEnumerable<Product> QuickSortRandom(this IList<Product> list)
        {
            if (!list.Any())
            {
                return new List<Product>();
            }

            var random = new Random();
            var pivot = list.ElementAt(random.Next(0, list.Count - 1));
            list.Remove(pivot);

            var smaller = list.Where(item => item.Price <= pivot.Price).ToList().QuickSortRandom();
            var larger = list.Where(item => item.Price > pivot.Price).ToList().QuickSortRandom();

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }

    }
}
