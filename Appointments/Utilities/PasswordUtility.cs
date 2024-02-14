using System.Security.Cryptography;

namespace Appointment.Utilities
{
    public class PasswordUtility
    {
        public static void createPassword(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var x= new HMACSHA512())
            {
                passwordSalt = x.Key;
                passwordHash=x.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool isPasswordValid(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var x = new HMACSHA512(passwordSalt))
            {

                return x.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)).SequenceEqual(passwordHash);

            }
        }
    }
}
