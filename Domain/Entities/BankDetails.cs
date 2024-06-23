using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BankDetails
    {
        public long BankAccountDetailID { get; set; }
        public long UserId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string UpiId { get; set; }
        public string QrPath { get; set; }
        public string DocumentDetailId { get; set; }
        public string FileExtenstion { get; set; }
        public bool IsDefault { get; set; }
        public string AccountDisplayName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
