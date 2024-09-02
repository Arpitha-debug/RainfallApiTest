using System.Globalization;

namespace RainfallApiTest
{
    public static class DateUtils
    {
        public static string GetDate(string day)
        {
            DateTime date;

            if (string.IsNullOrWhiteSpace(day))
            {
                throw new ArgumentException("Input date string cannot be null or empty.", nameof(day));
            }

            switch (day.ToLower())
            {
                case "yesterday":
                    date = DateTime.UtcNow.AddDays(-1);
                    break;
                case "today":
                    date = DateTime.UtcNow;
                    break;
                default:
                    if (DateTime.TryParseExact(day, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        // Date successfully parsed
                    }
                    else
                    {
                        throw new ArgumentException("Input date string is not in a valid format. Expected format: dd-MM-yyyy.", nameof(day));
                    }
                    break;
            }

            // Return the date in the desired format
            return date.ToString("yyyy-MM-dd");
        }
    }

}
