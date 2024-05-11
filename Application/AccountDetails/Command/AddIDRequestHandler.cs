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
    public class AddIDRequestHandler :IRequestHandler<AddIDRequestCommand,ReturnType<string>>
    {
        private readonly IIDRepository _userRepository;
        public AddIDRequestHandler(IIDRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ReturnType<string>> Handle(AddIDRequestCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.AddIDRequest(request);
        }
    }
}
