using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class Sha512
    {
        public static string HashIt(string password, string salt)
        {
            SHA512Managed sha512 = new SHA512Managed();
            Byte[] hashed512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(password, salt))); // hash the password with salt
            sha512.Clear(); // release resources used by sha managed method
            return Convert.ToBase64String(hashed512); // return string in hashed form
        }

        public static bool VerifyIt(string password, string salt)
        {
            string hashed512 = HashIt(password, salt); // hash attempted password for comparison
            try
            {
                string expected = ""; // READ FROM DATABASE

                if (hashed512.Equals(expected)) // is it the same?
                {
                    return true; // its a match.
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return false; // Did not find a match.
        }
    }
}
