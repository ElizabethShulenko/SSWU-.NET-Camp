using Task1.Models;

namespace Task1
{
    internal static class Check
    {
        public static void Print(Basket buy, Action<string> action)
        {
            action(buy.ToString());
        }

        public static void Print(Product product, Action<string> action)
        {
            action(product.ToString());
        }
    }
}
