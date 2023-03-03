using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper
{
    public static class SecurityHelper
    {
        public static int GenrateOneTimePassword(int userId, DateTime dateTime)
        {
            string key = userId.ToString() + dateTime;
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(key);
            Random rnd = new Random();
            int randomFactor = rnd.Next(100, 999);
            //buffer = System.Security.Cryptography.HMAC.Create().ComputeHash(buffer);
            int otp = 0;
            for(var i=0;i<buffer.Length;i++)
            {
                otp += buffer[i] * randomFactor;
                otp = otp % 10000;
            }
            var difference = otp.ToString().Length - 4;
            switch(difference)
            {
                case -1:
                    otp = Convert.ToInt32(otp.ToString() + rnd.Next(0, 9).ToString());
                    break;
                case -2:
                    otp = Convert.ToInt32(otp.ToString() + rnd.Next(10, 99).ToString());
                    break;
                case -3:
                    otp = Convert.ToInt32(otp.ToString() + rnd.Next(100, 999).ToString());
                    break;
                default:                    
                    break;
            }
            return otp;
        }
    }
}
