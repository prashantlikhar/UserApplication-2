using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserSecurity
    {
        public int UserId { get; set; }
        public int? OneTimePassword { get; set; }
        public DateTime? PasswordExpiredTime { get; set; }
        public DateTime? PasswordGenratedTime { get; set; }
    }
}
