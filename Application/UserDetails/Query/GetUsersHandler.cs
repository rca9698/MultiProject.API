using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserDetails.Query
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery,ReturnType<UserDetail>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ReturnType<UserDetail>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetUsers();
        }
    }
}
