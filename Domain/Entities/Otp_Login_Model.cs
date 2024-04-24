using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Otp_Login_Model
    {
        public string Otp { get; set; }
        public string ApiKey { get; set; }
        public string Message { get; set; }
        public string Sid { get; set; }
        public string MobileNumber { get; set; }
    }
}
