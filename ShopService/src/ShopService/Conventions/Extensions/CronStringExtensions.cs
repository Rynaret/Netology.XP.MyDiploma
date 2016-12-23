namespace ShopService.Conventions.Extensions
{
    public static class CronStringExtensions
    {
        private const int SecondsSegment = 0;
        private const int MinutesSegment = 1;
        private const int HoursSegment = 2;
        private const int DaysSegment = 3;
        private const int MonthsSegment = 4;
        private const int DaysOfWeekSegment = 5;
        private const int YearsSegment = 6;

        public static string GetDays(this string cronString)
        {
            var segments = cronString.Split();

            return segments[DaysSegment].Replace(",",", ");
        }
    }
}