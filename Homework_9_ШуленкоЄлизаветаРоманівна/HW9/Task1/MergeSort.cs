namespace Task1
{
    internal static class MergeSort
    {
        public static int[] Sort(int[] array)
        {
            if (array.Length > 1)
            {
                int middle = array.Length / 2;

                var leftArray = array.Take(middle).ToArray();
                var rightArray = array.Skip(middle).ToArray();

                leftArray = Sort(leftArray);
                rightArray = Sort(rightArray);

                array = Merge(leftArray, rightArray);
            }

            return array;
        }

        public static int[] Merge(int[] leftArray, int[] rightArray)
        {
            var result = new int[leftArray.Length + rightArray.Length];

            var leftIndex = 0;
            var rightIndex = 0;
            var resultIndex = 0;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                {
                    result[resultIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = rightArray[rightIndex++];
                }
            }

            while (leftIndex < leftArray.Length)
            {
                result[resultIndex++] = leftArray[leftIndex++];
            }

            while (rightIndex < rightArray.Length)
            {
                result[resultIndex++] = rightArray[rightIndex++];
            }

            return result;
        }
    }
}
