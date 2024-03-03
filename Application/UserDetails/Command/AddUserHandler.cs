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
    public class AddUserHandler : IRequestHandler<AddUserCommand, ReturnType<bool>>
    {
        private readonly IUserRepository _userRepository;
        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<ReturnType<bool>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.AddUser(request);
        }
    }
}
