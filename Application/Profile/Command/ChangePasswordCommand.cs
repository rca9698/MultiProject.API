using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profile.Command
{
    public class ChangePasswordCommand
    {
        public long UserId { get; set; }
        public string MobileNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string ChangePassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
