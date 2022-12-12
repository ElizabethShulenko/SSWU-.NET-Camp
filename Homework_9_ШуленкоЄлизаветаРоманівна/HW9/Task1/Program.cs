using Task1;

class Program
{
    public static void Main(String[] args)
    {
        var fileName = "RandomNums.txt";
        var partCount = 3;

        var sortedArray = SortArrayFromFile(fileName, partCount);

        WriteToFile(sortedArray);
    }

    private static int[] SortArrayFromFile(string fileName, int partCount)
    {
        int[] sortedArray = null;

        using (StreamReader reader = File.OpenText(fileName))
        {
            var fileLength = reader.BaseStream.Length;
            var partSize = (fileLength / partCount) + 1;

            for (int i = 0; i < partCount; i++)
            {
                var part = ReadPart(reader, partSize);
                var numsArray = ParseToIntArray(part);

                numsArray = MergeSort.Sort(numsArray);

                sortedArray = sortedArray != null
                    ? MergeSort.Merge(numsArray, sortedArray)
                    : numsArray;
            }
        }

        return sortedArray;
    }

    private static int[] ParseToIntArray(string text)
    {
        var stringNums = text.Split(' ');
        var result = new List<int>();

        foreach (var stringNum in stringNums)
        {
            if (Int32.TryParse(stringNum, out int num))
            {
                result.Add(num);
            }
        }

        return result.ToArray();
    }

    private static string ReadPart(StreamReader reader, long partSize)
    {
        var chars = new List<char>();
        var part = new char[partSize];

        reader.Read(part, 0, part.Length);

        chars.AddRange(part);

        while (chars.Last() != ' ' && !reader.EndOfStream)
        {
            var nextChar = reader.Read();
            chars.Add((char)nextChar);
        }

        return new string(chars.ToArray()).Trim();
    }

    public static void WriteToFile(int[] array)
    {
        using (StreamWriter writetext = new StreamWriter("RESULT.txt"))
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                writetext.WriteLine(array[i]);
            }
        }
    }
}
