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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery,ReturnType<UserDetail>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ReturnType<UserDetail>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetUserById(request);
        }
    }
}
