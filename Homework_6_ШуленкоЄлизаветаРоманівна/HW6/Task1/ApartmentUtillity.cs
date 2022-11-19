using System.Globalization;
using System.Text;

namespace Task1
{
    internal static class ApartmentUtillity
    {
        private static CultureInfo _cultureInfo = new CultureInfo("uk-UA");
        private static DateTimeFormatInfo _dateTimeFormatInfo = _cultureInfo.DateTimeFormat;

        public static Apartment? CreateApartment(string line)
        {
            var data = line.Split('|');

            if (!int.TryParse(data[0], out int number)
                || !double.TryParse(data[3], out double inputValue))
            {
                return null;
            }

            var apartment = new Apartment(number, data[1], data[2]);

            apartment.ElectricityMeter.InputValue = inputValue;

            var firstMonth = ParseElectricyMetric(data[4], data[5]);

            if (firstMonth != null)
            {
                apartment.ElectricityMeter.FirstMonth = firstMonth;
            }

            var secondMonth = ParseElectricyMetric(data[6], data[7]);

            if (secondMonth != null)
            {
                apartment.ElectricityMeter.SecondMonth = secondMonth;
            }

            var thirdMonth = ParseElectricyMetric(data[8], data[9]);

            if (firstMonth != null)
            {
                apartment.ElectricityMeter.ThirdMonth = thirdMonth;
            }

            return apartment;
        }

        public static IOrderedEnumerable<Apartment> FindDebtors(IEnumerable<Apartment> apartments)
        {
            var result = apartments
                .OrderByDescending(m => m.ElectricityMeter.GetTotalPrice())
                .ThenBy(m => m.Owner)
                .ThenBy(m => m.Number);

            return result;
        }

        public static IOrderedEnumerable<Apartment> FindUnusedApartments(IEnumerable<Apartment> apartments)
        {
            var result = apartments
                .Where(m => m.ElectricityMeter.GetTotalPrice() / ElectricityMeter.WATT_PRICE < 10)
                .OrderBy(m => m.Number);

            return result;
        }

        public static string GetQuarterReport(IEnumerable<Apartment> apartments, int quarter)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Звіт за квартал {quarter}");

            sb.AppendLine($"Місяць: {_dateTimeFormatInfo.MonthNames[quarter]} - {_dateTimeFormatInfo.MonthNames[quarter + 2]}\n");

            foreach (var apartment in apartments)
            {
                sb.AppendLine(apartment.GetInfo());
            }

            return sb.ToString();
        }

        public static string GetQuarterReport(Apartment apartment, int quarter)
        {
            return GetQuarterReport(new List<Apartment> { apartment }, quarter);
        }


        private static Tuple<DateTime, double>? ParseElectricyMetric(string dateString, string mectricString)
        {
            if (DateTime.TryParse(dateString ?? String.Empty, _cultureInfo, DateTimeStyles.None, out DateTime date)
                && Double.TryParse(mectricString ?? String.Empty, out double metric))
            {
                return new Tuple<DateTime, double>(date, metric);
            }

            return null;
        }
    }
}
