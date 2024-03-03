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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand,ReturnType<bool>>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ReturnType<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.DeleteUser(request);
        }
    }
}
