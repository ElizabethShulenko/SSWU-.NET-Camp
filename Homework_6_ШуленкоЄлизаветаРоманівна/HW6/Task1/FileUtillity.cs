using System.Globalization;
using System.Text;

namespace Task1
{
    internal static class FileUtillity
    {
        private static readonly string _inputFolderPath = @"..\..\Input";
        private static readonly string _outputFolderPath = @"..\..\Output";

        private static CultureInfo _cultureInfo = new CultureInfo("uk-UA");
        private static DateTimeFormatInfo _dateTimeFormatInfo = _cultureInfo.DateTimeFormat;

        public static IEnumerable<Apartment> GetApartmentsPerQuarter(int quarter)
        {
            var apartments = new List<Apartment>();

            if (!Directory.Exists(_inputFolderPath))
            {
                Directory.CreateDirectory(_inputFolderPath);
            }

            var inputFilePathes = Directory.GetFiles(_inputFolderPath);

            foreach (var filePath in inputFilePathes)
            {
                apartments.AddRange(GetApartmentsFromFile(filePath, quarter));
            }

            return apartments;
        }

        public static IEnumerable<Apartment> GetApartmentsFromFile(string filePath, int quarter)
        {
            var result = new List<Apartment>();

            if (!File.Exists(filePath))
            {
                return result;
            }

            var fileData = File.ReadLines(filePath);
            var infoString = fileData.First();

            var quarterString = infoString.Split('|')[1].Trim();

            if (quarterString != quarter.ToString())
            {
                return result;
            }

            foreach (string line in fileData.Skip(1))
            {
                var apartment = ApartmentUtillity.CreateApartment(line);

                if (apartment != null && apartment.IsMetricsInQuarter(quarter))
                {
                    result.Add(apartment);
                }
            }

            return result;
        }

        public static void FillReportFile(IEnumerable<Apartment> apartments, int quarter, string? fileName = null)
        {
            var report = ApartmentUtillity.GetQuarterReport(apartments, quarter);

            WriteToReportFile($"{fileName ?? $"report {DateTime.Now.ToString("dd.MM.yy")}"}.txt", report);
        }

        public static void FillReportFile(Apartment apartment, int quarter, string? fileName = null)
        {
            var report = ApartmentUtillity.GetQuarterReport(apartment, quarter);

            WriteToReportFile($"{fileName ?? $"report {DateTime.Now.ToString("dd.MM.yy")} Apartment #{apartment.Number}"}.txt", report);
        }

        private static void WriteToReportFile(string fileName, string data)
        {
            if (!Directory.Exists(_outputFolderPath))
            {
                Directory.CreateDirectory(_outputFolderPath);
            }

            File.WriteAllText($"{_outputFolderPath}\\{fileName}", data);
        }

    }
}
