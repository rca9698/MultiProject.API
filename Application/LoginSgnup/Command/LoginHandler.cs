using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LoginSgnup.Command
{
    public class LoginHandler : IRequestHandler<LoginCommand,ReturnType<UserDetail>>
    {
        private readonly ILoginSignupRepository _loginSignupRepository;
        public LoginHandler(ILoginSignupRepository loginSignupRepository)
        {
            _loginSignupRepository = loginSignupRepository;
        }

        public async Task<ReturnType<UserDetail>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ReturnType<UserDetail> result = new ReturnType<UserDetail>();
            try
            {
                return await _loginSignupRepository.Login(request);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
