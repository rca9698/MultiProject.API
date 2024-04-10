using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserDetails.Command
{
    public class AddUserCommand : IRequest<ReturnType<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public long SessionUser { get; set; }
    }
}
