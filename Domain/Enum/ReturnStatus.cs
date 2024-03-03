using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum ReturnStatus
    {
        Success = 1,
        Failure = 0,
        RecordExist = 2,
        InActive = 3,
        No_Permission = -1,
        Invalid_Data = -2,
        Not_Found = -3,
        Invalid_Id = -4,
        RecordNotExists = -5,
        RulesetExists = 4,
        RuleExists = 5
    };
}
