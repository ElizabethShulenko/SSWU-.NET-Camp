namespace Task2
{
    internal static class LoonaAlgorithm
    {
        public static bool LoonasCheck(int[] cardNum)
        {
            for (int i = cardNum.Length - 2; i >= 0; i -= 2)
            {
                cardNum[i] = SumDigits(cardNum[i] * 2);
            }

            return cardNum.Sum() % 10 == 0;
        }

        private static int SumDigits(int num)
        {
            var sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}
