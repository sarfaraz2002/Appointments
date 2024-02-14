using System.Text.RegularExpressions;

namespace Appointment.Utilities
{
    public class ValidationUtility
    {
        public static bool IsValidEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

            return regex.IsMatch(password);
        }
    }
}
