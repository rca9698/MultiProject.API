using Application.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserDetails.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ReturnType<string>>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ReturnType<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.UpdateUser(request);
        }
    }
}
