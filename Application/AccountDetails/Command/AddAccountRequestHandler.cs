using Application.Common.Interface;
using Application.UserDetails.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountDetails.Command
{
    public class AddAccountRequestHandler :IRequestHandler<AddAccountRequestCommand,ReturnType<string>>
    {
        private readonly IAccountRepository _userRepository;
        public AddAccountRequestHandler(IAccountRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ReturnType<string>> Handle(AddAccountRequestCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.AddAccountRequest(request);
        }
    }
}
