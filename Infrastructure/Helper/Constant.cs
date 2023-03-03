using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper
{
    public static class Constant
    {
        public const int ExpirationTimeInSecond = 30;
        public const string UserApiBaseUrl = "http://localhost:51970";
        public const string UserSecurityApiGetOtpUrl = "/api/Security/GetOneTimePassword";
        public const string UserSecurityApiIsOtpAlreadyGenratedUrl = "/api/Security/IsOtpAlreadyGenrated";

    }
}
