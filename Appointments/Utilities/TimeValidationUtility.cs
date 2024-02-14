namespace Appointments.Utilities
{
    public class TimeValidationUtility
    {
        public DateTime GenerateRandomTimeWithinRange(int startHour, int endHour)
        {
            Random random = new Random();
            DateTime currentDate = DateTime.UtcNow.Date;

            int randomHour = random.Next(startHour, endHour);
            int randomMinute = random.Next(0, 60);

            return currentDate.AddHours(randomHour).AddMinutes(randomMinute);
        }
    }
}
