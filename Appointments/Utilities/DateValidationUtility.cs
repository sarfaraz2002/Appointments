namespace Appointments.Utilities
{
    public class DateValidationUtility
    {
        public static bool IsDateValid(DateTime date)
        {
            var pstTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTime currentDateTimeUtc = DateTime.UtcNow;
            DateTime currentDateTimePST = TimeZoneInfo.ConvertTimeFromUtc(currentDateTimeUtc, pstTimeZoneInfo);

            return date > currentDateTimePST.Date;
        }
    }
}

