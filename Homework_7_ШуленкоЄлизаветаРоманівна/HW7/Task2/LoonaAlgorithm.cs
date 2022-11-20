namespace Task2
{
    internal static class LoonaAlgorithm
    {
        public static bool IsValid(long cardNum)
        {
            var arr = cardNum.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();

            return LoonasCheck(arr);
        }
        public static bool LoonasCheck(int[] cardNum)
        {
            for (int i = cardNum.Length - 2; i >= 0; i -= 2)
            {
                cardNum[i] = SumDigits(cardNum[i] * 2);
            }

            if(SumDigits(cardNum) % 10 != 0)
            {
                return false;
            }

            return true;

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
        private static int SumDigits(int[] cardNum)
        {
            var sum = 0;

            foreach (var digit in cardNum)
            {
                sum += digit;
            }

            return sum;
        }
    }
}
